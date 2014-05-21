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
    /// 
    /// Gravitasjon trekker objektet nedover
    /// Kollisjon med bullet avslutter spillet
    /// Kollisjon med obsticles gir minuspoeng
    /// </summary>
    public class Rocket : MovableShape
    {
        private Bitmap bitmap;
        private Acceleration gravityForRocket = new Acceleration();
        public int Thrust;

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
        }

        public override void Move()
        {
            Accelerate();
         //   Rotation += 1;
            calcXPosition += DxPosition;
            calcYPosition += DyPosition;
        //    XPosition = (int)calcXPosition;
        //    YPostition = (int)calcYPosition;

       /*     rectangle.Y -= Thrust;
            if (Thrust > 1) // Prøv med 1 eller høyere for null gravitasjon effekt :-)
            {
                Thrust--;
            }*/
  //          Accelerate();
            updateShapePosition();
        }       

        public void Accelerate()
        {
            gravityForRocket.SetAccelleration(1.0f, 45);
            YAccelleration = gravityForRocket.accelerationY;
            XAccelleration = gravityForRocket.thrustX;
            DxPosition += XAccelleration;
            DyPosition += YAccelleration;

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
