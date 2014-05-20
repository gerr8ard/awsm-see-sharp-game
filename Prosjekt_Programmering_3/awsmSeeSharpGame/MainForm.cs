using awsmSeeSharpGame.Classes;
using awsmSeeSharpGame.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame
{
    public partial class MainForm : Form
    {
        #region Fields
        GameTimer timer; //Timeren som holder styr på hvor lenge det er igjen av spillrunden.
        Boolean isGameRunning;
        ThreadStart threadStartInfoPanel;
        Thread threadInfoPanel;
        GamePanel gamePanel;
        LoginControl login = new LoginControl();//UserControl med logginn muligheter
        NewUserControl newUser = new NewUserControl();//UserControl for å registrere ny bruker
        SoundPlayer introMusic = new SoundPlayer(Properties.Resources.darkgalactica);//Legger til sang fra recources.
        public static bool isLoggedIn = false;
        #endregion

        /// <summary>
        /// Konstruktør
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            isGameRunning = false;
            
            startSpill();

            login.newUserEvent += new LoginControl.newUserDelegate(btnNewUserLoginControl_Click);//Abbonerer på event i LoginControl
            newUser.cancelEvent += new NewUserControl.cancelDelegate(btnCancelNewUserControl_Click);
           
            //pnlMainForm.Controls.Add(login);//Legger LoginControl form på panelet
            //login.Dock = DockStyle.Bottom;//Legger LoginControl form nederst på mainform
            //login.Show();//viser LoginControl form

            //introMusic.Play();//Spiller av introMusic

            threadStartInfoPanel = new ThreadStart(InfoPanelDraw);
            threadInfoPanel = new Thread(threadStartInfoPanel);
            threadInfoPanel.IsBackground = true;
            threadInfoPanel.Start();
            
            TimeSpan spillTid = new TimeSpan(0, 5, 0); //Setter spilltiden til 5 minutter
            timer = new GameTimer(spillTid); //starter en ny timer
            isGameRunning = true;
        }
        #region Spillrelaterte metoder
        /// <summary>
        /// Starter et nytt spill
        /// </summary>
        private void startSpill()
        {
            gamePanel = new GamePanel();
            //Controls.Remove(pnlMainForm);
            //Controls.Add(gamePanel);
            pnlMainForm.Controls.Add(gamePanel);
            //gamePanel.Show();

            //pnlMainForm.Visible = false;

            
        }

        /// <summary>
        /// Stopper et spill
        /// </summary>
        private void stoppSpill()
        {
            timer = null;
            isGameRunning = false;
        }

        /// <summary>
        /// Tegner opp Info panelet
        /// </summary>
        private void InfoPanelDraw()
        {
            while (true)
            {
                pnlInfo.Invalidate();
                Thread.Sleep(17); 
            }
        }

        /// <summary>
        /// Paint metode for Info panelet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            lblTid.Text = timer.GetTid().ToString(); // Oppdater tidslabelen.

        }

        /// <summary>
        /// Metode som blir kjørt når programmet lukkes. Stopper kjørende spill og tråder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoppSpill();
            threadInfoPanel.Abort();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion

        #region MenuItem Metoder
        private void MenuItemAvslutt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }
        #endregion


       

        #region Button click events
        /// <summary>
        /// Metode som blir kjørt når "Registrer ny bruker" knapp trykkes.
        /// Fjerner LoginControl og legger til NewUserControl til pnlMainForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewUserLoginControl_Click(object sender, EventArgs e)
        {

            pnlMainForm.Controls.Remove(login);
            pnlMainForm.Controls.Add(newUser);
            newUser.Dock = DockStyle.Bottom;
        }

        /// <summary>
        /// Metode som blir kjørt når "avbryt" knapp på NewUserControl blir trykket.
        /// Fjerner NewUserControl og legger til LoginControl i pnlMainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelNewUserControl_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Remove(newUser);
            pnlMainForm.Controls.Add(login);
        }
        #endregion
    }
}
