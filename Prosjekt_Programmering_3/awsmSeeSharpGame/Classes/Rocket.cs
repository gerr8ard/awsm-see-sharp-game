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
        private Point[] rocketMap;
        private Point[] rocketMapPosition;
        private Bitmap bitmap;
        private Gravity gravityForRocket = new Gravity();
        public int Thrust;

        public Rocket(int _XPosition, int _YPosition, float _Rotation, Point [] _rocketMap)
        {
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.alienblaster);

            rocketMap = _rocketMap;
            rocketMapPosition = new Point[rocketMap.Length];
            Array.Copy(rocketMap, rocketMapPosition, rocketMap.Length);

            //rectangle objekt som tar vare på posisjon og størrelse på raketten
            rectangle = new Rectangle(_XPosition, _YPosition, bitmap.Width, bitmap.Height);

            calcXPosition = rectangle.X;
            calcYPosition = rectangle.Y;
            Rotation = _Rotation;
            DxPosition = 0;
            DyPosition = 0;
            Thrust = 0;
            pen = new Pen(Color.White);

            updateRocketPosition();

            XAccelleration = 0;
            YAccelleration = 0;
        }

        public override void Move()
        {
         //   Accelerate();
         //   Rotation += 1;
        //    calcXPosition += DxPosition;
        //    calcYPosition += DyPosition;
        //    rectangle.X = (int)calcXPosition;
        //    rectangle.Y = (int)calcYPosition;

            rectangle.Y -= Thrust;
            if (Thrust > 1) // Prøv med 1 eller høyere for null gravitasjon effekt :-)
            {
                Thrust--;
            }
            updateRocketPosition();
        }

        private void updateRocketPosition()
        {
            for (int i = 0; i < rocketMap.Length; i++)
            {
                rocketMapPosition[i].X = rectangle.X + rocketMap[i].X;
                rocketMapPosition[i].Y = rectangle.Y + rocketMap[i].Y;
            }
            GraphicsPath graphicPath = ShapeMaps.MakeGraphicsPath(rocketMapPosition);
            region = new Region(graphicPath);
        }

        public void Accelerate()
        {
            YAccelleration = gravityForRocket.gravitationalAcceleration;
            DxPosition += XAccelleration;
            DyPosition += YAccelleration;
        }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.TranslateTransform((float)(rectangle.X + bitmap.Width / 2), (float)(rectangle.Y) + bitmap.Height / 2);
            e.Graphics.RotateTransform(Rotation);
            e.Graphics.TranslateTransform(-(float)(rectangle.X + bitmap.Width / 2), -(float)(rectangle.Y + bitmap.Height / 2));
            e.Graphics.DrawImageUnscaled(bitmap, new Point(rectangle.X,rectangle.Y));
            e.Graphics.DrawPolygon(pen, rocketMapPosition);
        }


    }
}
