using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Skrevet av Dag Ivarsøy og Silje Hauknes
    /// Gravitasjon trekker objektet nedover
    /// Kollisjon med bullet avslutter spillet
    /// Kollisjon med obsticles gir minuspoeng
    /// </summary>
    public class Rocket : MovableShape
    {
        private Acceleration gravityForRocket = new Acceleration();
        public float Thrust;
        public new float calcXPosition {get; set; }
        public new float calcYPosition {get; set; }
        public float xThrust;
        public float yThrust;
        private float gravity;

        public Rocket(int _XPosition, int _YPosition, float _Rotation, Point [] _rocketMap)
        {
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.alienblaster);

            shapeMap = _rocketMap;
            shapeMapPosition = new Point[shapeMap.Length];
            Array.Copy(shapeMap, shapeMapPosition, shapeMap.Length);

            XPosition = _XPosition;
            YPosition = _YPosition;
            Width = bitmap.Width;
            Height = bitmap.Height;

            calcXPosition = XPosition;
            calcYPosition = YPosition;
            Rotation = _Rotation;
            DxPosition = 0;
            DyPosition = 0;
            Thrust = 0;
            pen = new Pen(Color.White);

            updateShapePosition();

            XAccelleration = 0;
            YAccelleration = 0;

            xThrust = 0;
            yThrust = 0;
            speed = 0.1F;
        }

        ////Gjør Xposition public, mulighet for å hent ut posisjonene til Rocket
        public int X
        {
            get { 
                return XPosition;
            }
        }

        ////Gjør Yposition public, mulighet for å hent ut posisjonene til Rocket
        public int Y
        {
            get
            {
                return YPosition;
            }
        }

        ////Gjør Bredden public, mulighet for å hent ut posisjonene til Rocket
        public int WidthOfRocket
        {
            get
            {
                return Width;
            }
        }

        ////Gjør Høyden public, mulighet for å hent ut posisjonene til Rocket
        public int HeightOfRocket
        {
            get
            {
                return Height;
            }
        }

        ////Gjør Xposition public, mulighet for å hent ut posisjonene til Rocket
        public override void Move(float _elapsedTime)
        {
         //   Accelerate(_thrust, _rotation);
         //   Accelerate();
         //   Rotation += 1;
    //        calcXPosition += DxPosition;
    //        calcYPosition += DyPosition;

            //YPosition = (int)calcYPosition;
            //XPosition = (int)calcXPosition;

            //speed += 0.001F - yThrust * _elapsedTime;
            XPosition += (int)(xThrust*_elapsedTime);
            YPosition += (int)(yThrust* _elapsedTime);

            //(yThrust * _elapsedTime)
            if (xThrust > 1) // Prøv med 1 eller høyere for null gravitasjon effekt :-)
            {
                xThrust -= xThrust * _elapsedTime*2;
            }
            else if (xThrust < 1)
            {
                xThrust -= xThrust * _elapsedTime*2;
                
            }
            if (yThrust > 1)
            {
                yThrust -= yThrust * _elapsedTime * 2;
                speed -= 0.0019F;
            }
            else if (yThrust < 1 )
            {
                yThrust -= yThrust * _elapsedTime*2;
                speed += 0.001F;
            }
  //          Accelerate();
            updateShapePosition();
        }       

        public void Accelerate()
        {
            gravityForRocket.SetAccelleration(Thrust, Rotation);
            YAccelleration = gravityForRocket.accelerationY;
            XAccelleration = gravityForRocket.thrustX;
            DxPosition += XAccelleration;
            DyPosition += YAccelleration;
            if (Thrust > 0.2995)
                Thrust -= 0.2995f;
            else if (Thrust > 0.15)
                Thrust -= 0.15f;
            else if (Thrust > 0.03)
                Thrust -= 0.03f;
            else if (Thrust > 0.005)
                Thrust -= 0.005f;

            if (DxPosition > 0.03)
                DxPosition -= 0.03f;
            else if (DxPosition < -0.03)
                DxPosition += 0.03f;

            if (DyPosition > 0.005)
            {
              //  DyPosition -= 0.005f;
            }
            else if (DyPosition < -0.03)
               DyPosition += 0.03f; 
        }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.TranslateTransform((float)(XPosition + bitmap.Width / 2), (float)(YPosition) + bitmap.Height / 2);
            e.Graphics.RotateTransform(Rotation);
            e.Graphics.TranslateTransform(-(float)(XPosition + bitmap.Width / 2), -(float)(YPosition + bitmap.Height / 2));
            e.Graphics.DrawImageUnscaled(bitmap, new Point(XPosition,YPosition));
            e.Graphics.DrawPolygon(pen, shapeMapPosition);
        }


    }
}
