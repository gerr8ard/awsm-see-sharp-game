﻿using awsmSeeSharpGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class Queries
    {
        /// <summary>
        /// Skrevet av Pål Skogsrud og Dag Ivarsøy
        /// Spørring som henter ut en brukers info ved hjelp av brukernavn
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Info om bruker</returns>
        static public awsm_Users GetUserByUserName(string userName)
        {
            using (var context = new Context())
            {
                var user = context.Users
                            .Where(users => users.UserName == userName)
                            .FirstOrDefault();
                return user;

            }
        }

        /// <summary>
        /// Spørring som henter ut en liste med de ti beste poengsummene
        /// </summary>
        /// <returns>En liste med de ti høeste poengsummene</returns>
        static public List<awsm_Score> GetTopTenScores()
        {
            using (var context = new Context())
            {
                var highScoreListe = context.Score
                                    .Include("Users")
                                    .OrderByDescending(s => s.Score)
                                    .Take(10)
                                    .ToList();
                return highScoreListe;

            }
        }
        /// <summary>
        /// Spørring som henter ut den høyeste poengsummen til innlogget bruker
        /// </summary>
        /// <returns></returns>
        static public awsm_Score getHighestScore()
        {
            using (var context = new Context())
            {
                var score = context.Score
                            .OrderByDescending(s => s.Score)
                            .FirstOrDefault();
                return score;
            }
        }

        /// <summary>
        /// Spørring som henter ut de ti høyeste poengsummene til innlogget bruker.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        static public List<awsm_Score> GetTopTenPersonalScores(string userName)
        {
            using (var context = new Context())
            {
                var personalHighScoreList = context.Score
                                                .Include("Users")
                                                .Where(users => users.Users.UserName == userName)
                                                .OrderByDescending(s => s.Score)
                                                .Take(10)
                                                .ToList();
                return personalHighScoreList;
            }
        }
    }
}
