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
        Point lblFpsLocation = new Point(10, 75); //Setter posisjonen til FPS labelen!
        
        ThreadStart threadStartGamePanel; //Threadmetode som kjører oppdatering av OnPaint metoden 
        Thread threadGamePanel; // Thread som oppdaterer OnPaint metoden

        /// <summary>
        /// Konstruktør som setter opp objektene, objektlistene, FPSlabel og starter oppdateringene av OnPaint metoden
        /// </summary>
        public GamePanel()
        {
            this.BackColor = Color.Black;
            this.Dock = DockStyle.Fill; // Hmmm... Nå fyller Gamepanel helle vinduet, og infoPanelet og menyen ligger over gamepanelet

            //Setter opp alle objekt listene
            enemyList = new List<Enemy>();
            bulletList = new List<Bullet>();
            obstacleList = new List<Obstacle>();
            targetList = new List<Target>();

            Point[] rocketMap = ShapeMaps.RocketDesign1();

            rocket = new Rocket(300,150,0, rocketMap);

            // Setter opp labelen som viser FPS
            lblFps = new Label();
            lblFps.Location = lblFpsLocation;
            lblFps.ForeColor = Color.White;
            lblFps.Text = string.Empty;
            this.Controls.Add(lblFps);


            //Lager et test objekt og legger det til i obstacle lista
            Obstacle obstackle1 = new Obstacle(200, 200, 200, 200, Color.BlueViolet);
            obstacleList.Add(obstackle1);

            // Lager et nytt DrawShapes objekt som skal ta seg av oppdatering og opptegning av objektene
            drawShapes = new DrawShapes(this, enemyList, bulletList, obstacleList, targetList, rocket);

            // Setter opp og starter oppdatering av OnPaint metoden
            threadStartGamePanel = new ThreadStart(GamePanelDraw);
            threadGamePanel = new Thread(threadStartGamePanel);
            threadGamePanel.IsBackground = true;
            threadGamePanel.Start();

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
            base.OnPaint(e);
            drawShapes.Draw(e); //Kaller Draw metoden som tegner opp alle objektene i Gamepanelet
        }        
    }
}
