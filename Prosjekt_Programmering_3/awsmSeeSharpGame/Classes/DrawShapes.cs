﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Skrevet av Dag ivarsøy og Silje Hauknes
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
        private int nextEmit; //counter som bestemmer når neste moveableShape skal emites
        private int emitCounter; // counter som teller opp til neste emit;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private List<Bullet> bulletList;
        private int emitRate; //Hvor ofte moveable shapes skal sendes ut på skjermen
        private const int ENERGY_LOSS = 2;

        private DrawShapes thisPanel;

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
        public DrawShapes(GamePanel _parentGamePanel, int _emitRate, List<Obstacle> _obstacleList, List<MovableShape> _movableShapeList, Rocket _rocket)
        {
            parentGamePanel = _parentGamePanel;
            emitRate = _emitRate;
            obstacleList = _obstacleList;
            movableShapeList = _movableShapeList;
            activeMovableShapeList = new List<MovableShape>();
            rocket = _rocket;
            emitter = new Emitter(_parentGamePanel, _movableShapeList);
            collision = false;
            random = new Random();

            bulletList = new List<Bullet>();
            thisPanel = this;
            nextEmit = random.Next(300);
        }


        //Public get for Deltatiden. Brukt for å oppdatere spillobjektene uavhengig av FPS
        public float GetElapsedTime{
            get{
                return elapsedTime;
            }
        }

        public void AddBullet(Bullet bullet)
        {
            bulletList.Add(bullet);
        }

 /*       public void SetMovableObjectList(List<MovableShape> list)
        {
            movableShapeList = list;
        } */
        

        /// <summary>
        /// Flytter objektene ved å å gå igjennom alle flyttbare objekter og gå igjennom Move metodene deres.
        /// Skrevet av Silje
        /// </summary>
        public void Update(int _emitRate)
        {
            Emit(_emitRate);
            activeMovableShapeList = emitter.activeMovableShapeList;
            emitter.RemoveMovableShapesWhenGone();

            foreach (MovableShape shape in activeMovableShapeList)
            {
                
                if (shape is UFO)
                {
                    UFO ufo = shape as UFO;
                    ufo.Move(thisPanel, GetElapsedTime, random.Next(100,400));
                }
                shape.Move(GetElapsedTime);
            }

            foreach (Bullet bullet in bulletList)
            {
                bullet.Move(GetElapsedTime);
            }
            //rocket.Accelerate();
            rocket.Move(GetElapsedTime);
        }

        /// <summary>
        /// Sjekker for kollisjoner ved å gå igjennom alle flyttbare objekter og sjekke kollisjonsmetodene deres
        /// Skrevet av Dag og Silje
        /// </summary>
        public void CollisonCheck(PaintEventArgs e)
        {
            collision = false; //Resetter collisions testen

            if (rocket.X < 0)
            {
                rocket.xThrust += 10;
            }
            else if (rocket.X + rocket.WidthOfRocket > parentGamePanel.panelWidth)
            {
                rocket.xThrust -= 10;
            }
            if (rocket.Y < 0 )
            {
                rocket.yThrust += 10;
            }
            else if (rocket.Y > parentGamePanel.panelHeight)
            {
                rocket.yThrust -= 10;
            }
           
            foreach (MovableShape shape in activeMovableShapeList)
            {
                RegionData regionData = shape.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {

                    if (shape is AlienHead && shape.active == true)
                    {
                        shape.active = false;
                        parentGamePanel.score += 100;
                        alienHeadSound = new awsm_SoundPlayer("splat.wav");

                    }
                    else if(shape.active == true)
                    {
                        parentGamePanel.LossOfLife();
                        collision = true;

                    }

                    //collision = true;
                    //parentGamePanel.LossOfLife();

                }
                collisionRegion.Dispose();
            }
            
            foreach (Obstacle obstacle in obstacleList)
            {
                RegionData regionData = obstacle.region.GetRegionData();

                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    collision = true;
                    
                    collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
                }
            }
            
            foreach (Bullet bullet in bulletList)
            {
                RegionData regionData = bullet.region.GetRegionData();
                collisionRegion = new Region(regionData);
                collisionRegion.Intersect(rocket.region);
                if (!collisionRegion.IsEmpty(e.Graphics))
                {
                    bulletHitSound = new awsm_SoundPlayer("Explosion02.wav");
                    parentGamePanel.LossOfLife();
                   
                    collision = true;
                    collisionRegion.Dispose();//Ferdig med regionen, så vi kan fjerne den fra minnet
                }
               
            }

            if (collision)
            {
                rocket.pen.Color = Color.Red;
                parentGamePanel.score -= 1;
                // Sjekker om energi nivået er null eller mindre og mister liv om det er tilfelle.
                if (parentGamePanel.energy <= 0)
                    parentGamePanel.LossOfLife();
                else
                    parentGamePanel.energy -= ENERGY_LOSS;
            }
            else
            {
                rocket.pen.Color = Color.White;
            }
        }

        public void LossOfPointsEvent(object source, ElapsedEventArgs e)
        {
 if (parentGamePanel.score > 0)
            {
                parentGamePanel.score -= 10;
            }


            //lossOfPoints();
        }

  

        //Metode som tar seg av opptegning av objektene
        //Skrevet av Dag og Silje
        public void Draw(PaintEventArgs e)
        {
            Update(emitRate); //Flytter objektene som skal flyttes
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

            foreach (Bullet bullet in bulletList)
            {
                bullet.Draw(e);
            }

            rocket.Draw(e);

        }

        //Metode som sender ut MovableShapes på tilfeldige tidspunkt
        //Skrevet av Silje og Dag
        public void Emit(int _emitRate)
        {
            if (emitCounter == nextEmit)
            {
                nextEmit = random.Next(_emitRate);
                emitCounter = 0;
                emitter.EmitMovableShape();
            }
            else
                emitCounter++;
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
