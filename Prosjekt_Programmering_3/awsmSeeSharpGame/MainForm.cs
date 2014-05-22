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

namespace awsmSeeSharpGame
{


	public partial class MainForm : Form
	{
		#region Fields

		private GameTimer timer; //Timeren som holder styr på hvor lenge det er igjen av spillrunden.
		private Boolean isGameRunning;
		private ThreadStart threadStartInfoPanel;
		private Thread threadInfoPanel;
		private GamePanel gamePanel;
		private LoginControl login;//UserControl med logginn muligheter
		private NewUserControl newUser;//UserControl for å registrere ny bruker
		private StartPageControl startPage;//UserControl med hovedmeny
		private GameInfoControl gameInfo;//GameInfoControll med informasjon om gjeldende spill
        private HighScoreControl highScore;//HighscoreControl med en liste over de med høyest score.
        private PersonalHighScoreControl highScorePersonal;//HighScoreControl med en liste over høyeste personlige score.

        private awsm_SoundPlayer introMusic, gameMusic, btnCancelSound, logInSuccess, registerSuccess, highScoreSound, btnRegisterNewUserClick, personalHighScoreSound;
		public static bool isLoggedIn = false;
		public static awsm_Users currentUser;
   //     public static GameInfo currentGameInfo = new GameInfo();
        

		#endregion

		/// <summary>
		/// Konstruktør
		/// </summary>

		public MainForm()
		{
			InitializeComponent();
			isGameRunning = false;
			//startSpill();

			//Instansierer de forskjellige panelene
			login = new LoginControl();
			newUser = new NewUserControl();
			startPage = new StartPageControl();
			gameInfo = new GameInfoControl();
            highScore = new HighScoreControl();
            highScorePersonal = new PersonalHighScoreControl();

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

			pnlMainForm.Controls.Add(login);//Legger LoginControl form på panelet
			login.Dock = DockStyle.Bottom;//Legger LoginControl form nederst på mainform
			login.Show();//viser LoginControl form

			//Starter musikk til hovedmeny
			introMusic = new awsm_SoundPlayer("introMusicMuse.mp3");

		}


		#region Spillrelaterte metoder
		/// <summary>
		/// Starter et nytt spill
		/// </summary>
		private void startSpill()
		{
			gamePanel = new GamePanel();
			pnlMainForm.Controls.Add(gamePanel);
            

	  /*      TimeSpan spillTid = new TimeSpan(0, 5, 0); //Setter spilltiden til 5 minutter
			timer = new GameTimer(spillTid); //starter en ny timer
			isGameRunning = true; */
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

		#endregion

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
		
		private void MenuItemHovedmeny_Click(object sender, EventArgs e)
		{
			if (isLoggedIn == true)
			{

				stoppSpill();
				pnlMainForm.Controls.Remove(gamePanel);
				pnlMainForm.Controls.Remove(gameInfo);
				pnlMainForm.Controls.Remove(login);
				pnlMainForm.Controls.Remove(newUser);
				pnlMainForm.Controls.Add(startPage);
				startPage.Left = (this.ClientSize.Width - startPage.Width) / 2;
				startPage.Top = ((this.ClientSize.Height - startPage.Height) / 2) - 40;
				btnCancelSound = new awsm_SoundPlayer("Cancel.wav");

				if (gameMusic != null)
				{
					gameMusic.Stop();
				}

				introMusic.Start();

			}
			else WarningMessages.noAccessWarning();
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
		    btnRegisterNewUserClick = new awsm_SoundPlayer("come_get_some_x.wav");
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
				logInSuccess = new awsm_SoundPlayer("ready_4_action.wav");
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
			introMusic.Stop();
			gameMusic = new awsm_SoundPlayer("GameMusic.mp3");

			gameInfo = new GameInfoControl();
			pnlMainForm.Controls.Remove(startPage);
            pnlMainForm.Controls.Remove(highScore);
            pnlMainForm.Controls.Remove(highScorePersonal);
			pnlMainForm.Controls.Add(gameInfo);
			startSpill();
		}

		private void btn_logOut_Click(object sender, EventArgs e)
		{
			pnlMainForm.Controls.Remove(startPage);
            pnlMainForm.Controls.Remove(highScore);
            pnlMainForm.Controls.Remove(highScorePersonal);
			pnlMainForm.Controls.Add(login);
			isLoggedIn = false;
			btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
		}

		private void btn_Terminate_Click(object sender, EventArgs e)
		{
			btnCancelSound = new awsm_SoundPlayer("Cancel.wav");
			this.Close();
			
		}

		private void btnRegisterNewUserNewUserControl_Click(object sender, EventArgs e)
		{
			registerSuccess = new awsm_SoundPlayer("out_of_gum_x.wav");
			pnlMainForm.Controls.Remove(newUser);
			pnlMainForm.Controls.Add(login);
		}

		private void btn_Highscores_Click(object sender, EventArgs e)
		{
            
            pnlMainForm.Controls.Add(highScore);
            highScore.Left = 700;
            highScore.Top = 60;
            highScoreSound = new awsm_SoundPlayer("you_suck.wav");
		}

        private void btn_PersonalRecords_Click(object sender, EventArgs e)
        {
            pnlMainForm.Controls.Add(highScorePersonal);
            highScorePersonal.Left = 30;
            highScorePersonal.Top = 60;
            personalHighScoreSound = new awsm_SoundPlayer("good.wav");
        }

		#endregion

	  
	}
}
