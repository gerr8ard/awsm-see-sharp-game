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
        private Random random;

        private awsm_SoundPlayer alienHeadSound, bulletHitSound;


        private List<Obstacle> obstacleList;
        private Rocket rocket;
        private Region collisionRegion;

        private List<MovableShape> movableShapeList; //STH
        private List<MovableShape> activeMovableShapeList;
        Emitter emitter;

        GamePanel parentGamePanel; // lenke til Gamepanelet, så vi kan akkssere FPS labelen

        /// <summary>
        /// Konstruktør som setter opp alle objektene som skal tegnes opp
        /// Skrevet av Silje og Dag
        /// </summary>
        /// <param name="_parentGamePanel">Referanse til GamePanelet </param>
        /// <param name="_obstacleList">Liste med Obstacles</param>
        /// <param name="_rocket">Romskipet vårt</param>
        public DrawShapes(GamePanel _parentGamePanel, List<Obstacle> _obstacleList, List<MovableShape> _movableShapeList, Rocket _rocket)
        {
            parentGamePanel = _parentGamePanel;
            obstacleList = _obstacleList;
            movableShapeList = _movableShapeList;
            activeMovableShapeList = new List<MovableShape>();
            rocket = _rocket;
            emitter = new Emitter(_parentGamePanel, _movableShapeList);
            collision = false;
        }


        //Public get for Deltatiden. Brukt for å oppdatere spillobjektene uavhengig av FPS
        public float GetElapsedTime{
            get{
                return elapsedTime;
            }
        }

 /*       public void SetMovableObjectList(List<MovableShape> list)
        {
            movableShapeList = list;
        } */
        

        /// <summary>
        /// Flytter objektene ved å å gå igjennom alle flyttbare objekter og gå igjennom Move metodene deres.
        /// Skrevet av Silje
        /// </summary>
        public void Update()
        {
            Emit();
            activeMovableShapeList = emitter.activeMovableShapeList;
            emitter.RemoveMovableShapesWhenGone();

            foreach (MovableShape shape in activeMovableShapeList)
            {
                shape.Move(GetElapsedTime);
            } 

            rocket.Accelerate();
            rocket.Move(GetElapsedTime);
        }

        /// <summary>
        /// Sjekker for kollisjoner ved å gå igjennom alle flyttbare objekter og sjekke kollisjonsmetodene deres
        /// Skrevet av Dag og Silje
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

            foreach (MovableShape shape in activeMovableShapeList)
            {
               RegionData regionData = shape.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    if (shape is AlienHead)
                    {
                        emitter.activeMovableShapeList.Remove(shape);
                        parentGamePanel.score += 100;
                        alienHeadSound = new awsm_SoundPlayer("splat.wav");

                    }
                    else
                    {
                        parentGamePanel.LossOfLife();
                        collision = true;
                    }
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

        public void LossOfPoints()
        {
            if (parentGamePanel.score > 0)
            {
                parentGamePanel.score -= 10;
            }
        } 

        //Metode som tar seg av opptegning av objektene
        //Skrevet av Silje
        public void Draw(PaintEventArgs e)
        {
            Update(); //Flytter objektene som skal flyttes
            CollisonCheck(e); // Sjekker for kollisjon

            BeregnFPS(); //Beregner og viser Frames Per Second (FPS)

            foreach (Obstacle obstacle in obstacleList)
            {

                obstacle.Draw(e);
            }

            foreach (MovableShape shape in activeMovableShapeList)
            {
                shape.Draw(e);
            }

            rocket.Draw(e);

        }

        //Metode som sender ut MovableShapes på tilfeldige tidspunkt
        //Skrevet av Silje
        public void Emit()
        {
            Random rndm = new Random();
            int nextEmit = rndm.Next(100);
            int count = 0;
            if (count == nextEmit)
                emitter.EmitMovableShape();
            else
                count++;
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
