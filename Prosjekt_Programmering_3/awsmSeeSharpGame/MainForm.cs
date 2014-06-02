using awsmSeeSharpGame.Classes;
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
using System.Diagnostics;

namespace awsmSeeSharpGame
{

    /// <summary>
    /// Skrevet av Dag Ivarsøy og Pål Skogsrud
    /// </summary>
	public partial class MainForm : Form
	{
		#region Fields

		private GamePanel gamePanel;
		private LoginControl login;//UserControl med logginn muligheter
		private NewUserControl newUser;//UserControl for å registrere ny bruker
		private StartPageControl startPage;//UserControl med hovedmeny
		private HighScoreControl highScore;//HighscoreControl med en liste over de med høyest score.
		private PersonalHighScoreControl highScorePersonal;//HighScoreControl med en liste over høyeste personlige score.
		private SettingsControl settings;//UserControl for innstillinger
		private HowToPlayControl howToPlay;//UserCotrol som viser hvordan man spiller spillet.

		private awsm_SoundPlayer introMusic, gameMusic, btnCancelSound, logInSuccess, registerSuccess, highScoreSound, btnRegisterNewUserClick, personalHighScoreSound, menuItemHowToPlaySound;

		
		public static bool isLoggedIn = false;//Sjekk på om bruker er logget inn
		public static bool isHighScoreShowing = false;//Sjekk på om highscore tavlen vises
		public static bool isPersonalHighScoreShowing = false;//Sjekk på om personalHighScore tavlen vises
		public static bool isSettingsShowing = false;//Sjekk på om settings tavlen skal vises


 //       public static int user_id;
//        public static string userName = "Dag";
		public static awsm_Users currentUser;
		

		#endregion

		/// <summary>
		/// Konstruktør
		/// </summary>

		public MainForm()
		{
			InitializeComponent();

        //    startSpill();

			//Instansierer de forskjellige panelene
			login = new LoginControl();
			newUser = new NewUserControl();
			startPage = new StartPageControl();
			highScore = new HighScoreControl();
			settings = new SettingsControl();
			howToPlay = new HowToPlayControl();
			//highScorePersonal = new PersonalHighScoreControl();

			// Abbonnerer på events fra de forskjellige panelene
			login.newUserEvent += new LoginControl.loginControlDelegate(btnNewUserLoginControl_Click);//Abonnerer på event i LoginControl
			newUser.cancelEvent += new NewUserControl.cancelDelegate(btnCancelNewUserControl_Click);//Abonnerer på event i newUserControl
			login.loginEvent += new LoginControl.loginControlDelegate(btnLoginLoginControl_Click);//Abonnerer på loginEvent i LoginControl
			startPage.startgameEvent += new StartPageControl.startPageDelegate(btn_StartGame_Click);//Abonnerer på startgameEvent i StartPageControl
			startPage.logOutEvent += new StartPageControl.startPageDelegate(btn_logOut_Click);//Abonnerer på logOutEvent i StartPageControl
			startPage.terminateEvent += new StartPageControl.startPageDelegate(btn_Terminate_Click);//Abonnerer på terminateEvent i StartPageControl
			newUser.redirectNewUserEvent += new NewUserControl.cancelDelegate(btnRegisterNewUserNewUserControl_Click);//Abonnerer på redirectNewUserEvent i newUserControl
			startPage.highScoreEvent += new StartPageControl.startPageDelegate(btn_Highscores_Click);//Abonnerer på highScoreEventi StartPageControl
			startPage.personalHighScoreEvent += new StartPageControl.startPageDelegate(btn_PersonalRecords_Click);
			startPage.settingsEvent += new StartPageControl.startPageDelegate(btn_Settings_Click);//Abonnerer på settingsEvent i StartPageControl
            howToPlay.howToPlayEvent += new HowToPlayControl.howToPlayDelegate(tsMenuItemHowToPlay_Click);

			pnlMainForm.Controls.Add(login);//Legger LoginControl form på panelet
			login.Dock = DockStyle.Bottom;//Legger LoginControl form nederst på mainform
			login.Show();//viser LoginControl form
			

		}

		/// <summary>
		/// Hentet fra http://stackoverflow.com/questions/2612487/how-to-fix-the-flickering-in-user-controls for å stoppe flimmer på bilde.
		/// Gjør flyten i spillet dårligere. Blir mest sannsynligvis ikke brukt.
		/// </summary>
		/// 
	    
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}

		}

		#region Spillrelaterte metoder
		/// <Forfatter>
		/// Dag Ivarsøy og Pål Skogsrud
		/// </Forfatter>

		/// <summary>
		/// Starter et nytt spill
		/// </summary>
		private void startSpill()
		{
			gamePanel = new GamePanel(this);
			pnlMainForm.Controls.Add(gamePanel);
            //gamePanel.isGameRunning = true;
		}

		/// <summary>
		/// Stopper et spill
		/// </summary>
		public void stoppSpill()
		{
			//if (gamePanel.isGameRunning)
			{
				gamePanel.threadGamePanel.Abort();
				pnlMainForm.Controls.Remove(gamePanel);
                gamePanel.Dispose();
                //gamePanel.isGameRunning = false;
                gameMusic.Stop();
                
                introMusic.Start();
				//gamePanel = null;
                loadStartMenu();
               
			}
		}

        public void loadStartMenu() 
        {
            startPage.Left = (this.ClientSize.Width - startPage.Width) / 2;
            startPage.Top = ((this.ClientSize.Height - startPage.Height) / 2) - 40;
            pnlMainForm.Controls.Add(startPage);
        }
		
		/// <summary>
		/// Metode som blir kjørt når programmet lukkes. Stopper kjørende spill og tråder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try 
			{ 
			stoppSpill();
			}
			catch(NullReferenceException)
			{
               
			}
		}

		#endregion

		

		
		#region MenuItem Metoder
		/// <Forfatter>
		/// Pål Skogsrud
		/// Metoder som tar seg av hva som skjer når en av menuItem sine elementer blir trykket.
		/// </Forfatter>

        private void tsMenuItemQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsMenuItemAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }

        private void tsMenuItemMainMenu_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {

                if (gamePanel != null)
                {
                    if (gamePanel.isGameRunning)
                    {
                        stoppSpill();
                        gamePanel.isGameRunning = false;
                    }

                    pnlMainForm.Controls.Remove(gamePanel);
                    pnlMainForm.Controls.Remove(login);
                    pnlMainForm.Controls.Remove(newUser);
                    pnlMainForm.Controls.Remove(howToPlay);
                    btnCancelSound = new awsm_SoundPlayer("Cancel.wav");

                    if (gameMusic != null)
                    {
                        gameMusic.Stop();
                    }

                    introMusic.Start();
                }

                loadStartMenu();
                pnlMainForm.Controls.Remove(howToPlay);
            }
            else WarningMessages.noAccessWarning();


        }

        private void tsMenuItemHowToPlay_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {
                howToPlay.Left = 300;
                howToPlay.Top = 20;
                pnlMainForm.Controls.Add(howToPlay);
                pnlMainForm.Controls.Remove(login);
                pnlMainForm.Controls.Remove(newUser);
                pnlMainForm.Controls.Remove(startPage);
                pnlMainForm.Controls.Remove(highScore);
                pnlMainForm.Controls.Remove(highScorePersonal);
                pnlMainForm.Controls.Remove(settings);
                menuItemHowToPlaySound = new awsm_SoundPlayer("mess.wav");
            }
            else WarningMessages.noAccessWarning();
        }
		
		#endregion	   
		
		#region Button click events
		/// <Forfatter>
		/// Pål Skogsrud
		/// Metoder som tar seg av hva som skal skje når en knapp blir tykket.
		/// </summary>
		

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
			btnRegisterNewUserClick = new awsm_SoundPlayer("come_get_some_x.wav");

            
		}
		
		private void btnLoginLoginControl_Click(object sender, EventArgs e)
		{
			if (isLoggedIn == true)
			{
				pnlMainForm.Controls.Remove(login);
				startPage.Left = (this.ClientSize.Width - startPage.Width) / 2;
				startPage.Top = ((this.ClientSize.Height - startPage.Height) / 2) - 40;
				pnlMainForm.Controls.Add(startPage);
                //Starter musikk til hovedmeny
                introMusic = new awsm_SoundPlayer("introMusicMuse.mp3");
				logInSuccess = new awsm_SoundPlayer("ready_4_action.wav");
				highScorePersonal = new PersonalHighScoreControl();
				
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
			btnCancelSound= new awsm_SoundPlayer("Cancel.wav");
		}

		private void btn_StartGame_Click(object sender, EventArgs e)
		{
		  /*  if (currentUser != null)
			{
				currentGameInfo = new GameInfo(currentUser);
				currentGameInfo.timer.sekundOppdatering += new GameTimer.sekundOppdateringHandler()

			} */

			//Stopper hovedmenymusikk og starter spillmusikk.
			if (introMusic != null)
			{
				introMusic.Stop();
			}
			pnlMainForm.Controls.Remove(startPage);
			pnlMainForm.Controls.Remove(highScore);
			pnlMainForm.Controls.Remove(highScorePersonal);
			pnlMainForm.Controls.Remove(settings);

            startSpill();
			gameMusic = new awsm_SoundPlayer("GameMusic.mp3");
		}

		private void btn_logOut_Click(object sender, EventArgs e)
		{
			pnlMainForm.Controls.Remove(startPage);
			pnlMainForm.Controls.Remove(highScore);
			pnlMainForm.Controls.Remove(highScorePersonal);
			pnlMainForm.Controls.Remove(settings);
			pnlMainForm.Controls.Add(login);
			isLoggedIn = false;
			btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
            introMusic.Stop();
		}

		private void btn_Terminate_Click(object sender, EventArgs e)
		{
			btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
			this.Close();
			
		}

		private void btnRegisterNewUserNewUserControl_Click(object sender, EventArgs e)
		{
			pnlMainForm.Controls.Remove(newUser);
			pnlMainForm.Controls.Add(login);
			registerSuccess = new awsm_SoundPlayer("out_of_gum_x.wav");
		}

		private void btn_Highscores_Click(object sender, EventArgs e)
		{			
			
			if (isHighScoreShowing == true)
			{
                highScore = new HighScoreControl();
				pnlMainForm.Controls.Add(highScore);
                highScore.Left = 700;
                highScore.Top = 30;
				highScoreSound = new awsm_SoundPlayer("you_suck.wav");
			}
			else
			{
				pnlMainForm.Controls.Remove(highScore);
				btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
			} 
				
		}

		private void btn_PersonalRecords_Click(object sender, EventArgs e)
		{		
			if (isPersonalHighScoreShowing == true)
			{
                highScorePersonal = new PersonalHighScoreControl();
				pnlMainForm.Controls.Add(highScorePersonal);
                highScorePersonal.Left = 30;
                highScorePersonal.Top = 30;
				personalHighScoreSound = new awsm_SoundPlayer("good.wav");
			}
			else
			{
				pnlMainForm.Controls.Remove(highScorePersonal);
				btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
			}

		}

		private void btn_Settings_Click(object sender, EventArgs e)
		{
			settings.Left = 500;
			settings.Top = 400;

			if (isSettingsShowing == true)
			{
				pnlMainForm.Controls.Add(settings);
				personalHighScoreSound = new awsm_SoundPlayer("payback_time.wav");
			}
			else
			{
				pnlMainForm.Controls.Remove(settings);
				btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
			}
		}

		#endregion









	   

	  
	}
}
