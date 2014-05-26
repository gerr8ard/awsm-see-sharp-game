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
        public float elapsedTime;

        private awsm_SoundPlayer alienHeadSound;


        // Lister som inneholder objektene som skal tegnes opp
        List<Enemy> enemyList;
        List<Bullet> bulletList;
        List<Obstacle> obstacleList;
        List<Target> targetList;
        List<Meteor> meteorList;
        List<AlienHead> alienHeadList;
        List<UFO> ufoList;
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
        public DrawShapes(GamePanel _parentGamePanel, List<Enemy> _enemylist, List<Bullet> _bulletList, List<Obstacle> _obstacleList, List<Target> _targetList, List<Meteor> _meteorList, List<AlienHead> _alienHeadList, List<UFO> _ufoList, Rocket _rocket)
        {
            parentGamePanel = _parentGamePanel;
            enemyList = _enemylist;
            bulletList = _bulletList;
            obstacleList = _obstacleList;
            targetList = _targetList;
            meteorList = _meteorList;
            alienHeadList = _alienHeadList;
            ufoList = _ufoList;
            rocket = _rocket;
            collision = false;
        }

        //Public get for Deltatiden. Brukt for å oppdatere spillobjektene uavhengig av FPS
        public float GetElapsedTime{
            get{
                return elapsedTime;
            }
        }

        /// <summary>
        /// Flytter objektene ved å å gå igjennom alle flyttbare objekter og gå igjennom Move metodene deres.
        /// </summary>
        public void Update()
        {
            
            foreach(Meteor meteor in meteorList)
            {
                meteor.Move(GetElapsedTime);
            }
            
            foreach(AlienHead alienHead in alienHeadList)
            {
                alienHead.Move(GetElapsedTime);
            }

            foreach (UFO ufo in ufoList)
            {
                ufo.Move(GetElapsedTime);
            }

            foreach (Bullet bullet in bulletList)
            {
                bullet.Move(GetElapsedTime);
            }

            rocket.Accelerate();
            rocket.Move(GetElapsedTime);
        }

        /// <summary>
        /// Sjekker for kollisjoner ved å gå igjennom alle flyttbare objekter og sjekke kollisjonsmetodene deres
        /// </summary>
        public void CollisonCheck(PaintEventArgs e)
        {
            if (rocket.X < 0 - rocket.WidthOfRocket || rocket.X > parentGamePanel.panelWidth)
            {
                parentGamePanel.LossOfLife();
            }
            if (rocket.Y < 0 || rocket.Y > parentGamePanel.panelHeight)
            {
                parentGamePanel.LossOfLife();
            }

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
                    parentGamePanel.LossOfLife();
                }
                collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
            }
            
            foreach (Meteor meteor in meteorList)
            {
                RegionData regionData = meteor.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    parentGamePanel.LossOfLife();
                    collision = true;
                }
                collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
            }

            foreach (AlienHead alienHead in alienHeadList)
            {
                RegionData regionData = alienHead.region.GetRegionData();
                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics) && alienHead.isCollected == false)
                {
                    alienHead.isCollected = true;
                    parentGamePanel.score += 100;
                    alienHeadSound = new awsm_SoundPlayer("Shot.wav");
                    
                }
                collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
            }

            foreach (UFO ufo in ufoList)
            {
                RegionData regionData = ufo.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    parentGamePanel.LossOfLife();
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
            foreach (AlienHead alienHead in alienHeadList)
            {
                alienHead.Draw(e);
            }
            
            foreach(Meteor meteor in meteorList)
            {
               meteor.Draw(e);
            }

            foreach (UFO ufo in ufoList)
            {
                ufo.Draw(e);
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
            elapsedTime = (elapsedSpan.Milliseconds) / 1000.0F; //NB! .0

            //Beregner og viser:
            //Teller antall frames:
            frameCount++;
            //Inkrementerer timeSinceLastUpdate med forløpt tid:
            timeSinceLastUpdate += elapsedTime;
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
