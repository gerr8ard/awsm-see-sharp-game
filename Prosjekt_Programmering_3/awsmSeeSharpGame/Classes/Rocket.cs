using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private Pen pen = new Pen(Color.White);
        private SolidBrush brush = new SolidBrush(Color.White);
        private Point[] rocketMap;
        private Point[] rocketMapPosition;

        private TextureBrush textureBrush;
        private Bitmap bitmap;
        private Gravity gravityForRocket = new Gravity();

        public Rocket(int _XPosition, int _YPosition, float _Rotation, Point [] _rocketMap)
        {
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.alienblaster);

            XPosition = _XPosition;
            YPosition = _YPosition;
            calcXPosition = XPosition;
            calcYPosition = YPosition;
            Rotation = _Rotation;
            DxPosition = 0;
            DyPosition = 0;
            rocketMap = _rocketMap;
            rocketMapPosition = new Point[rocketMap.Length];
            Array.Copy(rocketMap, rocketMapPosition, rocketMap.Length);
            updateRocketPosition();

            XAccelleration = 0;
            YAccelleration = 0;

        }

        public override void Move()
        {
         //   Accelerate();
            Rotation += 1;
        //    calcXPosition += DxPosition;
        //    calcYPosition += DyPosition;
        //    XPosition = (int)calcXPosition;
        //    YPosition = (int)calcYPosition;
        //    updateRocketPosition();
        }



        private void updateRocketPosition()
        {
            for (int i = 0; i < rocketMap.Length; i++)
            {
                rocketMapPosition[i].X = XPosition + rocketMap[i].X;
                rocketMapPosition[i].Y = YPosition + rocketMap[i].Y;
            }
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

//            e.Graphics.FillPolygon(textureBrush, rocketMapPosition);
       //     e.Graphics.DrawRectangle(pen, new Rectangle(150, 150, 600, 500));
            //e.Graphics.FillRectangle(textureBrush, new Rectangle(200, 200, 600, 500));
            //e.Graphics.From = Graphics.FromImage(bitmap);
        //    graphic.RotateTransform(20.0f);

            e.Graphics.TranslateTransform((float)(XPosition + bitmap.Width / 2), (float)(YPosition) + bitmap.Height / 2);
            e.Graphics.RotateTransform(Rotation);
            e.Graphics.TranslateTransform(-(float)(XPosition + bitmap.Width / 2), -(float)(YPosition + bitmap.Height / 2));
            e.Graphics.DrawImageUnscaled(bitmap, new Point(XPosition,YPosition));// new Point(583, 508));
            e.Graphics.DrawPolygon(pen, rocketMapPosition);

        //    graphic.DrawImage(bitmap, new Point(583, 508));

        }


    }
}
