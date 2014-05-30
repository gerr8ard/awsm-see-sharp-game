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
    /// <Forfatter>
    /// Pål Skogsrud og Silje Hauknes
    /// </Forfatter>
    /// <summary>
    /// Klasse som viser hovedmenyen i spillet.
    /// </summary>
    public partial class StartPageControl : UserControl
    {
        public delegate void startPageDelegate(object sender, EventArgs e);
        public event startPageDelegate startgameEvent;
        public event startPageDelegate logOutEvent;
        public event startPageDelegate terminateEvent;
        public event startPageDelegate highScoreEvent;
        public event startPageDelegate personalHighScoreEvent;
        public event startPageDelegate settingsEvent;

        public StartPageControl()
        {
            InitializeComponent();
            
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            startgameEvent(sender, e);;
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
                MainForm.isHighScoreShowing = true;
            }
            else if (btn_Highscores.Text == "Skjul Rekorder")
            {
                btn_Highscores.Text = "Rekorder";
                MainForm.isHighScoreShowing = false;
            }
            highScoreEvent(sender, e);
        }

        private void btn_PersonalRecords_Click(object sender, EventArgs e)
        {

            if (btn_PersonalRecords.Text == "Mine Rekorder")
            {
                btn_PersonalRecords.Text = "Skjul Mine Rekorder";
                MainForm.isPersonalHighScoreShowing = true;
            }
            else if (btn_PersonalRecords.Text == "Skjul Mine Rekorder")
            {
                btn_PersonalRecords.Text = "Mine Rekorder";
                MainForm.isPersonalHighScoreShowing = false;
            }

            personalHighScoreEvent(sender, e);
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (btn_Settings.Text == "Innstillinger")
            {
                btn_Settings.Text = "Skjul Innstillinger";
                MainForm.isSettingsShowing = true;
            }
            else if (btn_Settings.Text == "Skjul Innstillinger")
            {
                btn_Settings.Text = "Innstillinger";
                MainForm.isSettingsShowing = false;
            }

            settingsEvent(sender, e);
        }

    }
}
