﻿using awsmSeeSharpGame.Classes;
using awsmSeeSharpGame.UserControls;
using awsmSeeSharpGame.Models;
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
using NAudio;
using NAudio.Wave;

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
        StartPageControl startPage = new StartPageControl();//UserControl med hovedmeny
        GameInfoControl gameInfo = new GameInfoControl();//GameInfoControll med informasjon om gjeldende spill
        SoundPlayer introMusic = new SoundPlayer(Properties.Resources.Metallica_Orion_8_bit);//Legger til sang fra recources.
        IWavePlayer waveOutDevice, waveOutDevice2;
        AudioFileReader audioFileReader, audioFileReader2; 
        

        public static bool isLoggedIn = false;
        public static awsm_Users currentUser;
        public static GameInfo currentGameInfo = new GameInfo();

        /* pål sin
        Thread song = new Thread(myFun1);
        Thread song2 = new Thread(myFun2);

        static void myFun1()
        {
             new System.Threading.Thread(() => {
                var c = new SoundPlayer(Properties.Resources.Metallica_Orion_8_bit);
                    c.Play();
                }).Start();
        }

        static void myFun2()
        {
            new System.Threading.Thread(() =>
            {
                var c = new SoundPlayer(Properties.Resources.Metallica_Orion_8_bit);
                c.Play();
            }).Start();
         * 
        }*/
        #endregion

        /// <summary>
        /// Konstruktør
        /// </summary>
   
        public MainForm()
        {
            InitializeComponent();
            isGameRunning = false;
           // startSpill();

            //pål song.Start();


            login.newUserEvent += new LoginControl.loginControlDelegate(btnNewUserLoginControl_Click);//Abbonerer på event i LoginControl
            newUser.cancelEvent += new NewUserControl.cancelDelegate(btnCancelNewUserControl_Click);
            login.loginEvent += new LoginControl.loginControlDelegate(btnLoginLoginControl_Click);//Abonnerer på loginEvent i LoginControl
            startPage.startgameEvent += new StartPageControl.startPageDelegate(btn_StartGame_Click);//Abonnerer på startgameEvent i StartPageControl
            startPage.logOutEvent += new StartPageControl.startPageDelegate(btn_logOut_Click);//Abonnerer på logOutEvent i StartPageControl
            startPage.terminateEvent += new StartPageControl.startPageDelegate(btn_Terminate_Click);//Abonnerer på terminateEvent i StartPageControl

            pnlMainForm.Controls.Add(login);//Legger LoginControl form på panelet
            login.Dock = DockStyle.Bottom;//Legger LoginControl form nederst på mainform
            login.Show();//viser LoginControl form

            //introMusic.Play();//Spiller av introMusic
            waveOutDevice = new WaveOut();
            waveOutDevice2 = new WaveOut();
            audioFileReader = new AudioFileReader(@"Resources\back_2_work_y.wav");
            audioFileReader2 = new AudioFileReader(@"C:\Users\Gerr8ard\Google Drive\Programmering3\Music\Music\Metallica-Orion 8 bit.wav");
            waveOutDevice.Init(audioFileReader);
            waveOutDevice2.Init(audioFileReader2);
            waveOutDevice.Play();
            waveOutDevice2.Play();
            
        }
        #region Spillrelaterte metoder
        /// <summary>
        /// Starter et nytt spill
        /// </summary>
        private void startSpill()
        {
            gamePanel = new GamePanel();
            pnlMainForm.Controls.Add(gamePanel);

            TimeSpan spillTid = new TimeSpan(0, 5, 0); //Setter spilltiden til 5 minutter
            timer = new GameTimer(spillTid); //starter en ny timer
            isGameRunning = true;

   /*         threadStartInfoPanel = new ThreadStart(InfoPanelDraw);
            threadInfoPanel = new Thread(threadStartInfoPanel);
            threadInfoPanel.IsBackground = true;
            threadInfoPanel.Start();  */
            
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
   /*     private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            lblTid.Text = timer.GetTid().ToString(); // Oppdater tidslabelen.

        }  */

        /// <summary>
        /// Metode som blir kjørt når programmet lukkes. Stopper kjørende spill og tråder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoppSpill();
         //   threadInfoPanel.Abort();
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
            //pål song2.Start();
            pnlMainForm.Controls.Remove(login);
            pnlMainForm.Controls.Add(newUser);
            newUser.Dock = DockStyle.Bottom;
        }

        private void btnLoginLoginControl_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {
                pnlMainForm.Controls.Remove(login);
                startPage.Left = (this.ClientSize.Width - startPage.Width) / 2;
                startPage.Top = ((this.ClientSize.Height - startPage.Height) / 2) - 40;
                pnlMainForm.Controls.Add(startPage);
            }
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

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                currentGameInfo = new GameInfo(currentUser);

            }
            gameInfo = new GameInfoControl();
            pnlMainForm.Controls.Remove(startPage);
            pnlMainForm.Controls.Add(gameInfo);
            startSpill();
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Remove(startPage);
            pnlMainForm.Controls.Add(login);
            isLoggedIn = false;
        }

        private void btn_Terminate_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion
    }
}
