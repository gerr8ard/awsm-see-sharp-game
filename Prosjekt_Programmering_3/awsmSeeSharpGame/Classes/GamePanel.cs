using awsmSeeSharpGame.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private List<AlienHead> alienHeadList;
        private Rocket rocket;
        private UserControls.GameInfoControl gameInfoControl;
        private Label lblNavn;
        private Label lblLives;
        private Label lblTime;
        private Label lblScore;
        private Label lblRecord;
        private TimeSpan timeLeft;
        private Boolean isGameRunning;
        private GameTimer gameTimer;

        public int numberOfAlienHead { get; set; }
        public int numberOfMeteors { get; set; }
        public int numberOfPlanets { get; set; }

        private Random random;
        public int score { get; set; }
        public int numberOfLivesLeft { get; set; }

        public Label lblFps; // Label for FPS
        Point lblFpsLocation = new Point(10, 200); //Setter posisjonen til FPS labelen!
        
        public ThreadStart threadStartGamePanel; //Threadmetode som kjører oppdatering av OnPaint metoden 
        public Thread threadGamePanel; // Thread som oppdaterer OnPaint metoden
        

        private string resourceUrl = System.Windows.Forms.Application.StartupPath + "\\Resources\\";
        Font fontDavid = new Font("Arial", 11.0F); //Font som blir brukt til informasjonen om spillet øverst på skjermen.

        /// <summary>
        /// Konstruktør som setter opp objektene, objektlistene, FPSlabel og starter oppdateringene av OnPaint metoden
        /// </summary>
        public GamePanel()
        {
            //gameInfoControl = new GameInfoControl();
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
            numberOfLivesLeft = 3;
            timeLeft = new TimeSpan(0, 5, 0); //Setter spilltiden til 5 minutter
            random = new Random(); // Setter opp et random objekt for å kalkulere flere parametre på objektene som skal dukke opp i spillet


            #region Game info Panel
            // Setter opp labelen som viser FPS
            lblFps = new Label();
            lblFps.Location = new Point (50, 10);
            lblFps.ForeColor = Color.White;
            lblFps.BackColor = Color.Transparent;
            lblFps.Font = fontDavid;
            this.Controls.Add(lblFps);

            // Setter opp labelen som viser Navn
            lblNavn = new Label();
            lblNavn.Location = new Point(250, 10);
            lblNavn.ForeColor = Color.White;
            lblNavn.BackColor = Color.Transparent;
            lblNavn.Font = fontDavid;
            this.Controls.Add(lblNavn);

            // Setter opp labelen som viser antall liv
            lblLives = new Label();
            lblLives.Location = new Point(450, 10);
            lblLives.ForeColor = Color.White;
            lblLives.BackColor = Color.Transparent;
            lblLives.Font = fontDavid;
            this.Controls.Add(lblLives);

            // Setter opp labelen som viser gjenstående tid
            lblTime = new Label();
            lblTime.Location = new Point(650, 10);
            lblTime.Size = new Size(150, 15);
            lblTime.ForeColor = Color.White;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = fontDavid;
            this.Controls.Add(lblTime);

            // Setter opp labelen som viser Poeng
            lblScore = new Label();
            lblScore.Location = new Point(850, 10);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = fontDavid;
            this.Controls.Add(lblScore);

            // Setter opp labelen som viser din rekord
            lblRecord = new Label();
            lblRecord.Location = new Point(1050, 10);
            lblRecord.ForeColor = Color.White;
            lblRecord.BackColor = Color.Transparent;
            lblRecord.Font = fontDavid;
            this.Controls.Add(lblRecord);

            #endregion

            StartNewGame(); //Setter variabler for et nytt spill

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
            alienHeadList = new List<AlienHead>();

            Point[] rocketMap = ShapeMaps.RocketDesign2();
            rocket = new Rocket(200,400,0, rocketMap);

            //Lager et test objekt og legger det til i obstacle lista
            Obstacle obstackle1 = new Obstacle(200, 200, 200, 200, Color.White);
            Obstacle obstackle2 = new Obstacle(600, 300, 150, 150, Color.White);

            obstacleList.Add(obstackle1);
            obstacleList.Add(obstackle2);

            //Lager nye metorer
            Meteor meteor1 = new Meteor(1000, 400, 300, 0,ShapeMaps.Meteor());
            meteorList.Add(meteor1);

            //Lager nye alienhead
            AlienHead alienHead1 = new AlienHead(1600, 200, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead2 = new AlienHead(2000, 400, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead3 = new AlienHead(2500, 700, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead4 = new AlienHead(3200, 100, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead5 = new AlienHead(3600, 400, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead6 = new AlienHead(5000, 50, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead7 = new AlienHead(6000, 250, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead8 = new AlienHead(6500, 200, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead9 = new AlienHead(7600, 500, 100, 0, ShapeMaps.alienHead());
            AlienHead alienHead10 = new AlienHead(8600, 200, 100, 0, ShapeMaps.alienHead());


            alienHeadList.Add(alienHead1);
            alienHeadList.Add(alienHead2);
            alienHeadList.Add(alienHead3);
            alienHeadList.Add(alienHead4);
            alienHeadList.Add(alienHead5);
            alienHeadList.Add(alienHead6);
            alienHeadList.Add(alienHead7);
            alienHeadList.Add(alienHead8);
            alienHeadList.Add(alienHead9);
            alienHeadList.Add(alienHead10);


            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            drawShapes = new DrawShapes(this, enemyList, bulletList, obstacleList, targetList, meteorList, alienHeadList, rocket);

            // Setter opp og starter oppdatering av OnPaint metoden
            threadStartGamePanel = new ThreadStart(GamePanelDraw);
            threadGamePanel = new Thread(threadStartGamePanel);
            threadGamePanel.IsBackground = true;
            threadGamePanel.Name = "gamePanelDraw";
            threadGamePanel.Start();

        }
        private List<Shape> MakeObjectList(int _numberOfObjects, TimeSpan _time, bool _useRotation, int speed, Type typeObject)
        {
            List<Shape> objectList = new List<Shape>();
            for (int i = 0; i < _numberOfObjects; i++)
            {

            }
            return objectList;
        } 

        GamePanel (int _NumberOflives, TimeSpan _time) :base() 
        {
            numberOfLivesLeft = _NumberOflives;
            timeLeft = _time;
        }

        private void StartNewGame()
        {
            lblNavn.Text = MainForm.userName;
            lblTime.Text = string.Format("Time left: 05:00");
            lblLives.Text = string.Format("Lives left: {0}", numberOfLivesLeft);
            lblScore.Text = "Score: 0";
            lblRecord.Text = "Record: 1000";
            gameTimer = new GameTimer(timeLeft); //starter en ny timer
            isGameRunning = true;
            gameTimer.sekundOppdatering += new GameTimer.sekundOppdateringHandler(sekundOppdateringEventHandler);
        }
        private void sekundOppdateringEventHandler(object sender, ElapsedEventArgs e)
        {
            GameTimer time = sender as GameTimer;
            timeLeft = time.GetTid();
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

            Debug.Print("start tråd");
            while (true)
            {
                this.Invalidate();
                Thread.Sleep(17);
            }
            Debug.Print("Slutt tråd");
        }
        // OnPaint metoden for GamePanel
        protected override void OnPaint(PaintEventArgs e)
        {
            lblTime.Text = string.Format("Time Left: {0}", timeLeft); //Oppdaterer tiden som er igjen.
            lblLives.Text = string.Format("Lives left: {0}", numberOfLivesLeft);
            lblScore.Text = string.Format("Score: {0}", score);

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
