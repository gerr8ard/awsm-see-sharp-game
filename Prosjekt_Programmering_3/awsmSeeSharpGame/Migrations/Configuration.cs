namespace awsmSeeSharpGame.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using awsmSeeSharpGame.Models;
    using System.Collections.Generic;
    using System.Collections;
    using awsmSeeSharpGame.Classes;
    
   
       
    internal sealed class Configuration : DbMigrationsConfiguration<awsmSeeSharpGame.Models.Context>
    {

        /// <summary>
        /// Skrevet av Pål Skogsrud og Dag Ivarsøy
        /// Klasse som genererer litt innhold i databasen
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(awsmSeeSharpGame.Models.Context context)
        {
            
            var privileges = new List<awsm_Privilege> {
                new awsm_Privilege {
                    Privilege = "Administrator"
                },
                new awsm_Privilege {
                    Privilege = "Bruker"
                }
            };

            privileges.ForEach(element => context.Privilege.AddOrUpdate(privilege => privilege.Privilege, element));
            context.SaveChanges();

            Hashtable HashAndSaltBruker1 = Hash.GetHashAndSalt("appelsinFarge5");
            Hashtable HashAndSaltBruker2 = Hash.GetHashAndSalt("appelsinFarge5");
            string HashBruker1 = (string)HashAndSaltBruker1["hash"];
            string SaltBruker1 = (string)HashAndSaltBruker1["salt"];
            string HashBruker2 = (string)HashAndSaltBruker2["hash"];
            string SaltBruker2 = (string)HashAndSaltBruker2["salt"];

            awsm_Privilege adminPrivilege = context.Privilege.FirstOrDefault(privilege => privilege.Privilege == "Administrator");
            awsm_Privilege brukerPrivilege = context.Privilege.FirstOrDefault(privilege => privilege.Privilege == "Bruker");

            var user = new List<awsm_Users>{
                new awsm_Users{
                    UserName = "Sjefen",
                    SureName = "Duck",
                    FirstName = "Donald",
                    Password = HashBruker1,
                    Salt = SaltBruker1,
                    Created = DateTime.Now.AddDays(-40),
                    Privilege_id = adminPrivilege.Privilege_id
                },
            
                new awsm_Users{
                    UserName = "MrBean",
                    SureName = "Bean",
                    FirstName = "Mr",
                    Password = HashBruker2,
                    Salt = SaltBruker2,
                    Created = DateTime.Now.AddDays(-20),
                    Privilege_id = brukerPrivilege.Privilege_id
                }
            };

            user.ForEach(element => context.Users.AddOrUpdate(users => users.UserName, element));
            context.SaveChanges();


            var user1 = context.Users.Where(users => users.UserName == "MrBean").FirstOrDefault();
            var user2 = context.Users.Where(users => users.UserName == "Sjefen").FirstOrDefault();

            var score = new List<awsm_Score>
            {
                new awsm_Score
                {
                    Score = 120,
                    Created = DateTime.Now.AddDays(-31),
                    User_id = user1.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 1000,
                    Created = DateTime.Now.AddDays(-32),
                    User_id = user2.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 1,
                    Created = DateTime.Now.AddDays(-33),
                    User_id = user1.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 150,
                    Created = DateTime.Now.AddDays(-34),
                    User_id = user2.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 250,
                    Created = DateTime.Now.AddDays(-35),
                    User_id = user1.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 260,
                    Created = DateTime.Now.AddDays(-36),
                    User_id = user2.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 270,
                    Created = DateTime.Now.AddDays(-37),
                    User_id = user1.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 360,
                    Created = DateTime.Now.AddDays(-38),
                    User_id = user2.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 1500,
                    Created = DateTime.Now.AddDays(-39),
                    User_id = user1.User_id,
                    
                },

                new awsm_Score
                {
                    Score = 800,
                    Created = DateTime.Now.AddDays(-40),
                    User_id = user2.User_id,
                    
                },

            };

            score.ForEach(element => context.Score.AddOrUpdate(scores => scores.Created, element));
            context.SaveChanges();


        }
    }
}
