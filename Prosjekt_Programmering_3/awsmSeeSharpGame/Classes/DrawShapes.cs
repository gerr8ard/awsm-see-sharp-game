using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// DrawShapes klassen tar seg av oppdatering, kollisjonstesting og opptegning av alle objektene.
    /// </summary>
    public class DrawShapes
    {
        //properties som bruker for å berenge FPS
        private int frameCount = 0;
        private double timeSinceLastUpdate = 0.0;
        private double fps = 0.0;
        private DateTime lastTime = DateTime.Now;
        private bool collision;

        // Lister som inneholder objektene som skal tegnes opp
        List<Enemy> enemyList;
        List<Bullet> bulletList;
        List<Obstacle> obstacleList;
        List<Target> targetList;
        List<Meteor> meteorList;
        Rocket rocket;
        Region collisionRegion;

        GamePanel parentGamePanel; // lenke til Gamepanelet, så vi kan akkssere FPS labelen

        /// <summary>
        /// Konstruktør som setter opp alle objektene som skal tegnes opp
        /// </summary>
        /// <param name="_parentGamePanel">Referanse til GamePanelet </param>
        /// <param name="_enemylist">Liste med enemies</param>
        /// <param name="_bulletList">Liste med Bullets</param>
        /// <param name="_obstacleList">Liste med Obstacles</param>
        /// <param name="_targetList">Liste med targets</param>
        /// <param name="_rocket">Romskipet vårt</param>
        public DrawShapes(GamePanel _parentPictureBox, List<Enemy> _enemylist, List<Bullet> _bulletList, List<Obstacle> _obstacleList, List<Target> _targetList, List<Meteor> _meteorList, Rocket _rocket)
        {
            parentGamePanel = _parentPictureBox;
            enemyList = _enemylist;
            bulletList = _bulletList;
            obstacleList = _obstacleList;
            targetList = _targetList;
            meteorList = _meteorList;
            rocket = _rocket;
            collision = false;
        }

        /// <summary>
        /// Flytter objektene ved å å gå igjennom alle flyttbare objekter og gå igjennom Move metodene deres.
        /// </summary>
        public void Update()
        {
            foreach(Meteor meteor in meteorList)
            {
                meteor.Move();
            }

            foreach (Bullet bullet in bulletList)
            {
                bullet.Move();
            }
            rocket.Move();
        }

        /// <summary>
        /// Sjekker for kollisjoner ved å gå igjennom alle flyttbare objekter og sjekke kollisjonsmetodene deres
        /// </summary>
        public void CollisonCheck(PaintEventArgs e)
        {

            foreach (Bullet bullet in bulletList)
            {
            }
            foreach (Obstacle obstacle in obstacleList)
            {
                RegionData regionData = obstacle.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    collision = true;
                }
                collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
            }
            if (collision)
            {
                rocket.pen.Color = Color.Red;
                collision = false; //Resetter collisions testen
            }
            else
            {
                rocket.pen.Color = Color.White;
            }
            rocket.region.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
        }
/*
        public void Collision()
        {
            {
                foreach (Firkant firkant in firkanter)
                {
                    foreach (Ball ball in balls)
                    {
                        if (ball.rectangle.IntersectsWith(firkant.rectangle))
                        {
                            ball.running = false;
                            Debug.WriteLine(string.Format("{0} terminert ved kollisjon", ball.getNameOfThread()));
                        }
                    }
                }
                balls.RemoveAll(ball => ball.running == false);
            }
        }
 * */
        /// <summary>
        /// Går igjennom alle objektene og kaller opp Draw metodene deres for å tegne de opp
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            Update(); //Flytter objektene som skal flyttes
            CollisonCheck(e); // Sjekker for kollisjon

            BeregnFPS(); //Beregner og viser Frames Per Second (FPS)

            //Tegner opp objektene
            foreach (Enemy enemy in enemyList)
            {
                enemy.Draw(e);
            }
            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(e);
            }
            foreach (Obstacle obstacle in obstacleList)
            {
                obstacle.Draw(e);
            }
            foreach (Target target in targetList)
            {
                target.Draw(e);
            }
            foreach (Meteor meteor in meteorList)
            {
                meteor.Draw(e);
            }
            rocket.Draw(e);

        }

        /// <summary>
        /// Kode som beregner FPS
        ///*** Takk til Werner Farstad for koden som beregner FPS ***
        /// </summary>
        private void BeregnFPS()
        {
 
            //Finner antall ticks siden sist (10000 ticks per millisekund):
            long elapsedTicks = DateTime.Now.Ticks - lastTime.Ticks; //lastTime sette nederst i metoden.
            //Finner differansen som et timespan-objekt:
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            //Finner forløpt tid siden siste kall på Draw() - i antall sekunder:
            double elapsed = (elapsedSpan.Milliseconds) / 1000.0; //NB! .0

            //Beregner og viser:
            //Teller antall frames:
            frameCount++;
            //Inkrementerer timeSinceLastUpdate med forløpt tid:
            timeSinceLastUpdate += elapsed;
            //Når det er gått mer enn 1 sekund (timeSinceLastUpdate > 1) beregnes fps:
            if (timeSinceLastUpdate > 1.0)
            {
                fps = frameCount / timeSinceLastUpdate;

                parentGamePanel.lblFps.Text = string.Format("FPS: {0:0.0}", fps);
                frameCount = 0;
                timeSinceLastUpdate -= 1.0; //Reduserer med 1 sekund, timeSinceLastUpdate blir (ca.) 0.
            }
            //Setter lastTime:
            lastTime = DateTime.Now;

        }
    }
}
