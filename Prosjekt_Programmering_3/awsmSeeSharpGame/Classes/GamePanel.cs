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
        private Rocket rocket;

        public Label lblFps; // Label for FPS
        Point lblFpsLocation = new Point(10, 10); //Setter posisjonen til FPS labelen!
        
        ThreadStart threadStartGamePanel; //Threadmetode som kjører oppdatering av OnPaint metoden 
        Thread threadGamePanel; // Thread som oppdaterer OnPaint metoden

        /// <summary>
        /// Konstruktør som setter opp objektene, objektlistene, FPSlabel og starter oppdateringene av OnPaint metoden
        /// </summary>
        public GamePanel()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;


            this.PreviewKeyDown += new PreviewKeyDownEventHandler(previewKeyEventHandler);

            //this.BackColor = Color.Black;
            this.BackgroundImage = awsmSeeSharpGame.Properties.Resources.spaceBackground;
            this.Dock = DockStyle.Fill; // Hmmm... Nå fyller Gamepanel helle vinduet, og infoPanelet og menyen ligger over gamepanelet

            //Setter opp alle objekt listene
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            obstacleList = new List<Obstacle>();
            targetList = new List<Target>();

            Point[] rocketMap = ShapeMaps.RocketDesign2();

            rocket = new Rocket(200,300,0, rocketMap);

            // Setter opp labelen som viser FPS
            lblFps = new Label();
            lblFps.Location = lblFpsLocation;
            lblFps.ForeColor = Color.White;
            lblFps.BackColor = Color.Transparent;
            lblFps.Text = string.Empty;
            this.Controls.Add(lblFps);


            //Lager et test objekt og legger det til i obstacle lista
            Obstacle obstackle1 = new Obstacle(200, 200, 200, 200, Color.White);
            Obstacle obstackle2 = new Obstacle(600, 300, 150, 150, Color.White);

            obstacleList.Add(obstackle1);
            obstacleList.Add(obstackle2);


            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            drawShapes = new DrawShapes(this, enemyList, bulletList, obstacleList, targetList, rocket);

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
                rocket.Rotation -= 3;
            }

            else if (e.KeyCode == Keys.Right)
            {
                rocket.Rotation += 3;
            }
            else if (e.KeyCode == Keys.Down)
            {
                rocket.Thrust += 1;
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
    }
}
