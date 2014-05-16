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

            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.fire);
            textureBrush = new TextureBrush(bitmap);

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
            e.Graphics.FillPolygon(textureBrush, rocketMapPosition);
            e.Graphics.DrawPolygon(pen, rocketMapPosition);
        }


    }
}
