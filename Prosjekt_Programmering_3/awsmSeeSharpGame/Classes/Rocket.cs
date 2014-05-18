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
        Pen pen = new Pen(Color.White);
        SolidBrush brush = new SolidBrush(Color.White);
        Point[] rocketMap;
        Point[] rocketMapPosition;

        TextureBrush textureBrush;
        Bitmap bitmap;
        Gravity gravityForRocket = new Gravity();
        Graphics graphic;

        public Rocket(int _XPosition, int _YPosition, int _Rotation, Point [] _rocketMap)
        {
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
            Rectangle myRectangle = new Rectangle(200, 200, 100, 100);

            //bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.Rocket2);
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.alienblaster);
  //          graphic = Graphics.FromImage(bitmap);
  //          graphic.RotateTransform(20.0f);

            //textureBrush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Clamp, myRectangle);
            textureBrush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Clamp);
        }

        public override void Move()
        {
            calcXPosition += DxPosition;
            calcYPosition += DyPosition;
            XPosition = (int)calcXPosition;
            YPosition = (int)calcYPosition;
            updateRocketPosition();
        }

        public void Accelerate()
        {
            YAccelleration = gravityForRocket.gravitationalAcceleration;
            DxPosition += XAccelleration;
            DyPosition += YAccelleration;
        }

        private void updateRocketPosition()
        {
            for (int i = 0; i < rocketMap.Length; i++)
            {
                rocketMapPosition[i].X = XPosition + rocketMap[i].X;
                rocketMapPosition[i].Y = YPosition + rocketMap[i].Y;
            }

        } 
        public override void Draw(PaintEventArgs e)
        {
//            e.Graphics.FillPolygon(textureBrush, rocketMapPosition);
            e.Graphics.DrawRectangle(pen, new Rectangle(150, 150, 600, 500));
            //e.Graphics.FillRectangle(textureBrush, new Rectangle(200, 200, 600, 500));
            //e.Graphics.From = Graphics.FromImage(bitmap);
            graphic.RotateTransform(20.0f);
            //e.Graphics.DrawImageUnscaled(bitmap, new Point(583, 508));
            e.Graphics.DrawPolygon(pen, rocketMapPosition);
            graphic.DrawImage(bitmap, new Point(583, 508));

        }


    }
}
