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

namespace awsmSeeSharpGame.UserControls
{
    public partial class GameInfoControl : UserControl
    {
        ThreadStart threadStartInfoControl;
        Thread threadInfoControl;

 //       public delegate void GameInfoControlDelegate(object sender, EventArgs e);
  //      public event GameInfoControlDelegate GameInfoControlLoad;

        public GameInfoControl()
        {
            InitializeComponent();

            threadStartInfoControl = new ThreadStart(InfoPanelDraw);
            threadInfoControl = new Thread(threadStartInfoControl);
            threadInfoControl.IsBackground = true;
            threadInfoControl.Start(); 

            GameInfoControl_Load();

        }

        public void GameInfoControl_Load()
        {
            lbl_name.Text = MainForm.currentGameInfo.userName;
            lbl_levelValue.Text = MainForm.currentGameInfo.level.ToString();
            lbl_livesValue.Text = MainForm.currentGameInfo.lives.ToString();
            lbl_PointsValue.Text = MainForm.currentGameInfo.score.ToString();
            lbl_personalHighScore.Text = MainForm.currentGameInfo.personalHighScore.ToString();
          //  lbl_remainingTime.Text = 

        }
    
        private void InfoPanelDraw()
        {
            while (true)
            {
                GameInfoControl_Paint();
                Thread.Sleep(17); 
            }
        }

        /// <summary>
        /// Paint metode for Info panelet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameInfoControl_Paint()
        {

            //lbl_remainingTime.Text = MainForm.currentGameInfo.timer.GetTid().ToString(); // Oppdater tidslabelen.


        }  
    }
}
