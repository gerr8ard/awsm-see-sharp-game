using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame;
using System.Threading;
using awsmSeeSharpGame.Classes;
using awsmSeeSharpGame.Models;
using System.Timers;

namespace awsmSeeSharpGame.UserControls
{
    public partial class GameInfoControl : UserControl
    {
        ThreadStart threadStartInfoControl;
        Thread threadInfoControl;

        public static GameInfo currentGameInfo;

        private StartPageControl startPage;

 //       public delegate void GameInfoControlDelegate(object sender, EventArgs e);
  //      public event GameInfoControlDelegate GameInfoControlLoad;

        public GameInfoControl()
        {
            InitializeComponent();

            threadStartInfoControl = new ThreadStart(InfoPanelDraw);
            threadInfoControl = new Thread(threadStartInfoControl);
            threadInfoControl.IsBackground = true;
            threadInfoControl.Start();

            startPage = new StartPageControl();
            startPage.startgameEvent += new StartPageControl.startPageDelegate(btn_StartGame_Click);//Abonnerer på startgameEvent i StartPageControl

        }


        public void GameInfoControl_Update()
        {


     //       currentGameInfo.timer.sekundOppdatering += new GameTimer.sekundOppdateringHandler();

            lbl_name.Text = currentGameInfo.userName;
            lbl_levelValue.Text = currentGameInfo.level.ToString();
            lbl_livesValue.Text = currentGameInfo.lives.ToString();
            lbl_PointsValue.Text = currentGameInfo.score.ToString();
            lbl_personalHighScore.Text = currentGameInfo.personalHighScore.ToString();
          //  lbl_remainingTime.Text = 
            

        }
    
        private void InfoPanelDraw()
        {
            while (true)
            {
               // GameInfoControl_Paint();
                Thread.Sleep(17); 
            }
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            currentGameInfo = new GameInfo(MainForm.currentUser);
            GameInfoControl_Update();
            currentGameInfo.timer.sekundOppdatering += new GameTimer.sekundOppdateringHandler(GameInfoControl_Paint);
        }

        /// <summary>
        /// Paint metode for Info panelet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameInfoControl_Paint(object source, ElapsedEventArgs e)
        {
            lbl_remainingTime.Text = currentGameInfo.timer.GetTid().ToString(); // Oppdater tidslabelen.


            //lbl_remainingTime.Text = MainForm.currentGameInfo.timer.GetTid().ToString(); // Oppdater tidslabelen.


        }  
    }
}
