using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using awsmSeeSharpGame.Models;
using awsmSeeSharpGame.Classes;

namespace awsmSeeSharpGame.Classes
{
    public class GameInfo
    {
        public string userName;
        public int level;
        public int lives;
        public int score;
        public GameTimer timer;
        public int personalHighScore;

        public GameInfo()
        {
            userName = "";
        }

        public GameInfo(awsm_Users user)
        {
            userName = user.UserName.ToString();
            level = 1;
            lives = 3;
            score = 0;
            personalHighScore = 0;

            timer = new GameTimer(new TimeSpan(0, 5, 0));
        }

    }
}
