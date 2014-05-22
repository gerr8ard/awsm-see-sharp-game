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


        }
    }
}
