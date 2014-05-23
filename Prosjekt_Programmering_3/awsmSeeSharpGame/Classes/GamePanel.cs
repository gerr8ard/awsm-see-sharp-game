﻿using awsmSeeSharpGame.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Klasse som viser selve spillet. 
    /// </summary>
    public class GamePanel : PictureBox
    {
        private DrawShapes drawShapes; // Klasse som tar for seg opptegningen av objektene

        // Lister med objektene
        private List<Enemy> enemyList;
        private List<Bullet> bulletList;
        private List<Obstacle> obstacleList;
        private List<Target> targetList;
        private List<Meteor> meteorList;
        private Rocket rocket;
        private UserControls.GameInfoControl gameInfoControl;

        public Label lblFps; // Label for FPS
        Point lblFpsLocation = new Point(10, 200); //Setter posisjonen til FPS labelen!
        
        ThreadStart threadStartGamePanel; //Threadmetode som kjører oppdatering av OnPaint metoden 
        Thread threadGamePanel; // Thread som oppdaterer OnPaint metoden

        public event UpdateLivesDelegate UpdateLivesEvent;
        public delegate void UpdateLivesDelegate(object sender, EventArgs e);

        private string resourceUrl = System.Windows.Forms.Application.StartupPath + "\\Resources\\";
        Font fontDavid = new Font("Arial", 11.0F);
        /// <summary>
        /// Konstruktør som setter opp objektene, objektlistene, FPSlabel og starter oppdateringene av OnPaint metoden
        /// </summary>
        public GamePanel()
        {
            //gameInfoControl = new GameInfoControl();
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;

            // Setter opp labelen som viser FPS
            lblFps = new Label();
            lblFps.Location = new Point (50, 10);
            lblFps.ForeColor = Color.White;
            lblFps.BackColor = Color.Transparent;
            lblFps.Text = string.Empty;
            lblFps.Font = fontDavid;
            this.Controls.Add(lblFps);

            // Setter opp labelen som viser Navn
            Label lblNavn = new Label();
            lblNavn.Location = new Point(250, 10);
            lblNavn.ForeColor = Color.White;
            lblNavn.BackColor = Color.Transparent;
            lblNavn.Text = "Navn";
            lblNavn.Font = fontDavid;
            this.Controls.Add(lblNavn);

            // Setter opp labelen som viser antall liv
            Label lblLives = new Label();
            lblLives.Text = "3 lives";
            lblLives.Location = new Point(450, 10);
            lblLives.ForeColor = Color.White;
            lblLives.BackColor = Color.Transparent;
            lblLives.Font = fontDavid;
            this.Controls.Add(lblLives);

            // Setter opp labelen som viser gjenstående tid
            Label lblTime = new Label();
            lblTime.Text = "05:00";
            lblTime.Location = new Point(650, 10);
            lblTime.ForeColor = Color.White;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = fontDavid;
            this.Controls.Add(lblTime);

            // Setter opp labelen som viser Poeng
            Label lblScore = new Label();
            lblScore.Text = "0";
            lblScore.Location = new Point(850, 10);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = fontDavid;
            this.Controls.Add(lblScore);

            // Setter opp labelen som viser din rekord
            Label lblRecord = new Label();
            lblRecord.Text = "1000";
            lblRecord.Location = new Point(1050, 10);
            lblRecord.ForeColor = Color.White;
            lblRecord.BackColor = Color.Transparent;
            lblRecord.Font = fontDavid;
            this.Controls.Add(lblRecord);

            this.PreviewKeyDown += new PreviewKeyDownEventHandler(previewKeyEventHandler);

            //this.BackColor = Color.Black;
            //this.BackgroundImage = awsmSeeSharpGame.Properties.Resources.spaceBackground;
            this.Dock = DockStyle.Fill; // Hmmm... Nå fyller Gamepanel helle vinduet, og infoPanelet og menyen ligger over gamepanelet
            //this.Image = Image.FromFile(resourceUrl + "stars.gif");
            this.Image = Image.FromFile(resourceUrl + "space-background.jpg");


            //Setter opp alle objekt listene
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            obstacleList = new List<Obstacle>();
            targetList = new List<Target>();
            meteorList = new List<Meteor>();

            Point[] rocketMap = ShapeMaps.RocketDesign2();

            rocket = new Rocket(200,400,0, rocketMap);

 


            //Lager et test objekt og legger det til i obstacle lista
            Obstacle obstackle1 = new Obstacle(200, 200, 200, 200, Color.White);
            Obstacle obstackle2 = new Obstacle(600, 300, 150, 150, Color.White);

            obstacleList.Add(obstackle1);
            obstacleList.Add(obstackle2);

            //Lage nye metorer
            Meteor meteor1 = new Meteor(1000, 400, 10, 0,ShapeMaps.Meteor());
            meteorList.Add(meteor1);

            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            drawShapes = new DrawShapes(this, enemyList, bulletList, obstacleList, targetList, meteorList, rocket);

            // Setter opp og starter oppdatering av OnPaint metoden
            threadStartGamePanel = new ThreadStart(GamePanelDraw);
            threadGamePanel = new Thread(threadStartGamePanel);
            threadGamePanel.IsBackground = true;
            threadGamePanel.Start();

        }

        private void previewKeyEventHandler(object sender, PreviewKeyDownEventArgs e)
        {
           
            if (e.KeyCode == Keys.Left)
            {
                rocket.Rotation -= 5;
            }

            else if (e.KeyCode == Keys.Right)
            {
                rocket.Rotation += 5;
            }
            else if (e.KeyCode == Keys.Down)
            {
                rocket.Thrust += 0.3f;
            }
            else if (e.KeyCode == Keys.Space)
            {
                   // Skyte pang! pang!
            }
        }


        /// <summary>
        /// Kaller On Paint metoden ca 60 ganger i sekundet
        /// </summary>
        private void GamePanelDraw()
        {
            while (true)
            {
                this.Invalidate();
                Thread.Sleep(17);
            }
        }
        // OnPaint metoden for GamePanel
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            base.OnPaint(e);
            drawShapes.Draw(e); //Kaller Draw metoden som tegner opp alle objektene i Gamepanelet
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
     
    }
}
