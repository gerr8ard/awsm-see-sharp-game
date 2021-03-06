﻿using awsmSeeSharpGame.interfaces;
using awsmSeeSharpGame.Models;
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
using awsmSeeSharpGame.Classes;
using System.Runtime.InteropServices;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Skrevet av Dag Ivarsøy, Silje Hauknes og Pål Skogsrud
    /// Klasse som viser selve spillet. 
    /// </summary>
    public class GamePanel : PictureBox
    {
        #region Fields
        private DrawShapes drawShapes; // Klasse som tar for seg opptegningen av objektene

        // Lister med objektene
        private List<Enemy> enemyList;
        private List<Bullet> bulletList;
        private List<Obstacle> obstacleList = new List<Obstacle>();
        private List<MovableShape> movableShapeList = new List<MovableShape>();
        private List<Target> targetList;  
        private List<Meteor> meteorList;
        private List<AlienHead> alienHeadList;
        private List<UFO> ufoList;

        private Rocket rocket;
        private Label lblNavn;
        private Label lblLevel;
        private Label lblLives;
        private Label lblTime;
        private Label lblScore;
        private Label lblRecord;
        private Label lblEnergy;
        private Panel pnlEnergy;
        private TimeSpan timeLeft;
        private GameTimer gameTimer;
        private int emitRate; // Hvor ofte objektene skal sendes ut på skjermen 
        public int panelHeight = 638;
        public int panelWidth = 1184;
        public int energy;
        public bool isGameRunning;

        public int numberOfAlienHead { get; set; }
        public int numberOfMeteors { get; set; }
        public int numberOfUFOs { get; set; }
        public int numberOfPlanets { get; set; }
        public int numberOfLivesLeft { get; set; }
        public int level { get; set; }

        private MainForm parentMainForm;
        private Random random;
        public int score { get; set; }

        public Label lblFps; // Label for FPS
        Point lblFpsLocation = new Point(10, 200); //Setter posisjonen til FPS labelen!
        
        public ThreadStart threadStartGamePanel; //Threadmetode som kjører oppdatering av OnPaint metoden 
        public Thread threadGamePanel; // Thread som oppdaterer OnPaint metoden
        

        private string resourceUrl = System.Windows.Forms.Application.StartupPath + "\\Resources\\";
        Font fontDavid = new Font("Arial", 11.0F); //Font som blir brukt til informasjonen om spillet øverst på skjermen.
        private const float MOVEMENT_PER_KEY_PRESS = 100.0F;

        Emitter emitter;

        private const int MAX_ENERGY = 1500;

        #endregion

        /// <summary>
        /// Konstruktør som setter opp objektene, objektlistene, FPSlabel og starter oppdateringene av OnPaint metoden
        /// </summary>
        public GamePanel(MainForm _parentMainForm)
        {
            parentMainForm = _parentMainForm;
            random = new Random(); // Setter opp et random objekt for å kalkulere flere parametre på objektene som skal dukke opp i spillet

            this.Dock = DockStyle.Fill; // Hmmm... Nå fyller Gamepanel hele vinduet, og infoPanelet og menyen ligger over gamepanelet
            this.Image = Image.FromFile(resourceUrl + "space-background.jpg"); // Laster inn bakgrunnsbilde

            // Gjør det mulig å registrer tastetrykk på Gamepanel
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;

            this.PreviewKeyDown += new PreviewKeyDownEventHandler(previewKeyEventHandler); //Registrer en ny handler for tastetrykk

            #region Game info Panel
            // Setter opp labelen som viser FPS
            lblFps = new Label();
            lblFps.Location = new Point (50, 30);
            lblFps.ForeColor = Color.White;
            lblFps.BackColor = Color.Transparent;
            lblFps.Font = fontDavid;
            this.Controls.Add(lblFps);

            // Setter opp labelen som viser Navn
            lblNavn = new Label();
            lblNavn.Location = new Point(150, 30);
            lblNavn.ForeColor = Color.White;
            lblNavn.BackColor = Color.Transparent;
            lblNavn.Font = fontDavid;
            this.Controls.Add(lblNavn);

            // Setter opp labelen som viser level
            lblLevel = new Label();
            lblLevel.Location = new Point(250, 30);
            lblLevel.ForeColor = Color.White;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = fontDavid;
            this.Controls.Add(lblLevel);

            // Setter opp labelen som viser antall liv
            lblLives = new Label();
            lblLives.Location = new Point(350, 30);
            lblLives.ForeColor = Color.White;
            lblLives.BackColor = Color.Transparent;
            lblLives.Font = fontDavid;
            this.Controls.Add(lblLives);

            // Setter opp labelen som Energi
            lblEnergy = new Label();
            lblEnergy.Width = 50;
            lblEnergy.Location = new Point(450, 30);
            lblEnergy.ForeColor = Color.White;
            lblEnergy.BackColor = Color.Transparent;
            lblEnergy.Font = fontDavid;
            this.Controls.Add(lblEnergy);

            // Setter opp panel som viser energy
            pnlEnergy = new Panel();
            pnlEnergy.Location = new Point(500, 33);
            pnlEnergy.Width = 150;
            pnlEnergy.Height = 13;
            pnlEnergy.BackColor = Color.White;
            this.Controls.Add(pnlEnergy);          

            // Setter opp labelen som viser gjenstående tid
            lblTime = new Label();
            lblTime.Location = new Point(700, 30);
            lblTime.Size = new Size(150, 15);
            lblTime.ForeColor = Color.White;
            lblTime.BackColor = Color.Transparent;
            lblTime.Font = fontDavid;
            this.Controls.Add(lblTime);

            // Setter opp labelen som viser Poeng
            lblScore = new Label();
            lblScore.Location = new Point(850, 30);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = fontDavid;
            this.Controls.Add(lblScore);

            // Setter opp labelen som viser din rekord
            lblRecord = new Label();
            lblRecord.Location = new Point(1050, 30);
            lblRecord.ForeColor = Color.White;
            lblRecord.BackColor = Color.Transparent;
            lblRecord.Font = fontDavid;
            this.Controls.Add(lblRecord);

            #endregion

            // Setter opp og starter oppdatering av OnPaint metoden som tegner opp alle spillobjektene om IsGameRunning er satt til true
            threadStartGamePanel = new ThreadStart(GamePanelDraw);
            threadGamePanel = new Thread(threadStartGamePanel);
            threadGamePanel.IsBackground = true;
            threadGamePanel.Name = "gamePanelDraw";
            threadGamePanel.Start();

            //emitter = new Emitter(this);

            NewGame(); //Setter variabler for et nytt spill
            InitializeAndStartGame(); //Setter opp alle objektene for å spille.               


        }
        /*
        // Ekstra konstruktør for å sette antall liv og tid, kan kanskje tas bort
        public GamePanel(int _NumberOflives, TimeSpan _time) : base()
        {
            numberOfLivesLeft = _NumberOflives;
            timeLeft = _time;
        }*/
        
        //Laget av Dag
        private void NewGame()
        {
            numberOfLivesLeft = 3;
            
            if (MainForm.currentUser != null)
            {
                lblNavn.Text = MainForm.currentUser.UserName;
                
            }
            else
            {
                lblNavn.Text = "Testbruker";
                
            }
            numberOfAlienHead = 40;
            numberOfMeteors = 10;
            numberOfUFOs = 10;
            score = 0;
            level = 1;
            emitRate = 1000;
            lblLevel.Text = string.Format("Nivå: {0}", level.ToString());
            lblLives.Text = string.Format("Liv: {0}", numberOfLivesLeft);
            lblEnergy.Text = string.Format("Energi:");
            lblTime.Text = string.Format("Tid: {0}", timeLeft);
            lblScore.Text = string.Format("Poeng: {0}", score.ToString());
            lblRecord.Text = string.Format("Rekord: {0}",Queries.getHighestScore().Score.ToString());
        }

        // Laget av Dag
        private void InitializeAndStartGame()
        {
            //Setter opp alle objekt listene
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            obstacleList = new List<Obstacle>();
            targetList = new List<Target>();
            meteorList = new List<Meteor>();
            alienHeadList = new List<AlienHead>();
            ufoList = new List<UFO>(); 

            //Setter opp raketten
            Point[] rocketMap = ShapeMaps.RocketDesign2();
            rocket = new Rocket(100, panelHeight / 2, 90, rocketMap);
            //Setter opp planeter

            Obstacle obstackle1 = new Obstacle(random.Next(200, panelWidth -200), random.Next(panelHeight - 200), 200, 200, Color.White);
            Obstacle obstackle2 = new Obstacle(random.Next(200, panelWidth - 150), random.Next(panelHeight - 150), 150, 150, Color.White);
            Obstacle obstackle3 = new Obstacle(random.Next(200, panelWidth - 150), random.Next(panelHeight - 150), 150, 150, Color.White);
            obstacleList.Add(obstackle1);
            obstacleList.Add(obstackle2);
            obstacleList.Add(obstackle3);

            //Fyller opp energibaren
            pnlEnergy.Width = 150;
            energy = MAX_ENERGY;
            
            
            //Setter opp ufoene
            //ufoList = MakeObjectList(ufoList, 90, timeLeft, false, 100, ShapeMaps.UFO(), ShapeMaps.BitmapUFO());

            //Setter opp meteorene
            //meteorList = MakeObjectList(meteorList, 30, timeLeft, false, 250, ShapeMaps.Meteor(), ShapeMaps.BitmapMeteor());

            //Setter opp alienhead
            //alienHeadList = MakeObjectList(alienHeadList, 100, timeLeft, false, 100, ShapeMaps.AlienHead(), ShapeMaps.BitmapAlienHead());
            //alienHeadList = MakeObjectList(alienHeadList, 60, timeLeft, false, 100, ShapeMaps.AlienHead(), ShapeMaps.BitmapAlienHead());

            //Setter opp bullets
            //bulletList = MakeObjectList(bulletList, 20, timeLeft, false, 80, ShapeMaps.alienBullet(), ShapeMaps.BitmapBullet3());

            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            //meteorList = emitter.EmitMovingObject(meteorList);
            movableShapeList = MakeShapeList(numberOfAlienHead, numberOfUFOs, numberOfMeteors);
            drawShapes = new DrawShapes(this, emitRate, obstacleList, movableShapeList, rocket);
                        
           //Starter en ny timer
            timeLeft = new TimeSpan(0, 1, 0); //Setter spilltiden til 1 minutt
            gameTimer = new GameTimer(timeLeft); //starter en ny timer
            gameTimer.sekundOppdatering += new GameTimer.sekundOppdateringHandler(sekundOppdateringEventHandler);
            //Starter opptegningen av objektene
            
            isGameRunning = true;
        }

        // Laget av Dag
        //Må fikses, kjøres når tida går ut.
        private void EndLevel()
        {
            isGameRunning = false;
            if (MessageBox.Show(string.Format("Gratulerer, du klarte nivået!")) == DialogResult.OK)
            {
                emptyObjects();
                numberOfUFOs += 10;
                numberOfMeteors += 5;
                numberOfAlienHead++;
                level++;
                if (emitRate > 100) //Øker emitteren av objekter, så de kommer oftere
                    emitRate -= 100;
                InitializeAndStartGame();
            }
        }

        // Laget av Dag
        // Opprydning, tømmer alle objektene
        private void emptyObjects()
        {
            drawShapes = null;
            //ufoList = null;
            //meteorList = null;
            //alienHeadList = null;
            obstacleList = null;
            //bulletList = null;
            //enemyList = null;
            rocket = null;
            gameTimer.Stopp();
            gameTimer = null;
        }


        // Laget av Dag
        // Spilleren døde
        public void LossOfLife()
        {
            isGameRunning = false;

            if (numberOfLivesLeft > 0)
            {
                numberOfLivesLeft -= 1;
                if (MessageBox.Show(string.Format("Du har {0} liv igjen", numberOfLivesLeft.ToString())) == DialogResult.OK)
                {
                    emptyObjects();
                    InitializeAndStartGame();
                }
            }
            else GameOver();
        }

       
        //Laget av Dag
        private void GameOver()
        {
            emptyObjects();
            if (MainForm.currentUser != null) //Sjekker om brukeren er logget inn og lagrer scoren 
            {
                if (MessageBox.Show(string.Format("Gratulerer {0}! Din poengsum ble {1}.", MainForm.currentUser.UserName, score.ToString())) == DialogResult.OK)
                {
                        using (var context = new Context())
                        {
                            awsm_Score scoreToSave = new awsm_Score()
                            {
                                Score = score,
                                User_id = MainForm.currentUser.User_id,
                                Created = DateTime.Now
                            };
                            context.Score.Add(scoreToSave);
                            context.SaveChanges();
                            context.Entry(scoreToSave).Reload();
                        }                  
                }
            }
            else MessageBox.Show("Du må være logget inn for å kunne lagre poengsummen din!");

            threadGamePanel.Abort();
            Debug.Print("Slutt tråd");
            parentMainForm.stoppSpill();  
        }

        //Laget av Silje
        private List<MovableShape> MakeShapeList(int _numberOfAlienHeads, int _numberOfUFOs, int _numberOfMeteors)
        {
            List<MovableShape> list = new List<MovableShape>();
            Random random = new Random();

            for (int i = 0; i < _numberOfAlienHeads; i++)
            {
                list.Add(new AlienHead(panelWidth, random.Next(panelHeight), random.Next(50,300), 0, ShapeMaps.AlienHead(), ShapeMaps.BitmapAlienHead()));
            }
            for (int i = 0; i < _numberOfUFOs; i++)
            {
                list.Add(new UFO(panelWidth, random.Next(panelHeight), random.Next(50,150), 0, ShapeMaps.UFO(), ShapeMaps.BitmapUFO()));
            }
            for (int i = 0; i < _numberOfMeteors; i++ )
            {
                list.Add(new Meteor(panelWidth, random.Next(panelHeight), random.Next(100,400), 0, ShapeMaps.Meteor(), ShapeMaps.BitmapMeteor()));
            }

            return list;

        }
        
        // Laget av Dag
        // Generisk liste metode som lager lister for alle type moveable shape objekter
        private List<T> MakeObjectList<T>(List<T> shapeListe, int _numberOfObjects, TimeSpan _time, bool _useRotation, int speed, Point [] shapeMap, Bitmap bitmap)
        {
            for (int i = 0; i < _numberOfObjects; i++)
            {
                int XPosition = random.Next(panelWidth, panelWidth * (int)_time.TotalSeconds); //**** SILJE, kan du ta en beregning på denne så vi får spredd elementene utover til tida går ut?
                int YPosition = random.Next(panelHeight); //Høyden på mainform 638                  
                int rotation = 0;
                if (_useRotation)
                {
                    rotation = random.Next(360); //Rotasjon på mellom 0 og 360 grader
                }
                shapeListe.Add((T)Activator.CreateInstance(typeof(T), XPosition, YPosition, speed, rotation, shapeMap, bitmap));
            }
            return shapeListe;
        }
       
        private void sekundOppdateringEventHandler(object sender, ElapsedEventArgs e)
        {
            GameTimer time = sender as GameTimer;
            timeLeft = time.GetTid();
        }

        public static bool IsKeyDown(Keys key)
        {
            return (GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;
        }

        [DllImport("user32.dll")]
        public extern static Int16 GetKeyState(Int16 nVirtKey);


        private void previewKeyEventHandler(object sender, PreviewKeyDownEventArgs e)
        {
            if (IsKeyDown(Keys.Left) && IsKeyDown(Keys.Up))
            {
                rocket.xThrust -= MOVEMENT_PER_KEY_PRESS;
                rocket.yThrust -= MOVEMENT_PER_KEY_PRESS;
            }

            if (IsKeyDown(Keys.Left) && IsKeyDown(Keys.Down))
            {
                rocket.xThrust -= MOVEMENT_PER_KEY_PRESS;
                rocket.yThrust += MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Right) && IsKeyDown(Keys.Up))
            {
                rocket.xThrust += MOVEMENT_PER_KEY_PRESS;
                rocket.yThrust -= MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Right) && IsKeyDown(Keys.Down))
            {
                rocket.xThrust += MOVEMENT_PER_KEY_PRESS;
                rocket.yThrust += MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Left))
            {
                rocket.xThrust -= MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Up))
            {
                rocket.yThrust -= MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Right))
            {
                rocket.xThrust += MOVEMENT_PER_KEY_PRESS;
            }
            if (IsKeyDown(Keys.Down))
            {
                rocket.yThrust += MOVEMENT_PER_KEY_PRESS;
            }

            /*
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
            else if (e.KeyCode == Keys.Up)
            {
                rocket.Thrust -= 0.3f;
            }
            else if (e.KeyCode == Keys.Space)
            {
                // Skyte pang! pang!
            }
            else if (e.KeyCode == Keys.P)
            {
                drawShapes.Emit();
            }
             * */
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

            if (isGameRunning) //Oppdater spillobjektene dersom spillet kjøres
            {
                if (timeLeft == TimeSpan.Zero)
                {
                    EndLevel();
                }
                lblTime.Text = string.Format("Tid: {0}", timeLeft); //Oppdaterer tiden som er igjen.
                lblLives.Text = string.Format("Liv: {0}", numberOfLivesLeft);
                lblScore.Text = string.Format("Poeng: {0}", score);
                lblLevel.Text = string.Format("Nivå: {0}", level);
                pnlEnergy.Width = energy / 10;

                drawShapes.Draw(e); //Kaller Draw metoden som tegner opp alle objektene i Gamepanelet
            }
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
