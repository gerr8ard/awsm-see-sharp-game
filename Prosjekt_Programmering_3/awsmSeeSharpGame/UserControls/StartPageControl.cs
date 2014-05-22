using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.UserControls
{
    public partial class StartPageControl : UserControl
    {
        public delegate void startPageDelegate(object sender, EventArgs e);
        public event startPageDelegate startgameEvent;
        public event startPageDelegate startgameEventForGameInfo;
        public event startPageDelegate logOutEvent;
        public event startPageDelegate terminateEvent;
        public event startPageDelegate highScoreEvent;
        public event startPageDelegate personalHighScoreEvent;

        public StartPageControl()
        {
            InitializeComponent();
            
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            startgameEvent(sender, e);
            //startgameEventForGameInfo(sender, e);
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            logOutEvent(sender, e);
        }

        private void btn_Terminate_Click(object sender, EventArgs e)
        {
            terminateEvent(sender, e);
        }

        private void btn_Highscores_Click(object sender, EventArgs e)
        {

            if (btn_Highscores.Text == "Rekorder")
            {
                btn_Highscores.Text = "Skjul Rekorder";
            }
            else if (btn_Highscores.Text == "Skjul Rekorder")
            {
                btn_Highscores.Text = "Rekorder";
            }
            highScoreEvent(sender, e);
        }

        private void btn_PersonalRecords_Click(object sender, EventArgs e)
        {
            personalHighScoreEvent(sender, e);
        }
    }
}
