using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
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
        //Farten
//        private int dxPosisjon = 0;
//        private int dyPosisjon = 1;
        Point point1;
        Point point2;
        Point point3;
        Point point4;
        Point point5;
        Point point6;
        Point point7;
        Pen pen = new Pen(Color.White);
        SolidBrush brush = new SolidBrush(Color.White);
        Point[] curvePoints;
        TextureBrush textureBrush;
        Bitmap bitmap;
        Gravity gravityForRocket = new Gravity();

        public Rocket(int _XPosition, int _YPosition, int _Rotation)
        {
            XPosition = _XPosition;
            YPosition = _YPosition;
            calcXPosition = XPosition;
            calcYPosition = YPosition;
            Rotation = _Rotation;
            DxPosition = 0;
            DyPosition = 0;

            point1 = new Point(XPosition + 0, YPosition + 10);
            point2 = new Point(XPosition - 5, YPosition + 0);
            point3 = new Point(XPosition - 5, YPosition - 15);
            point4 = new Point(XPosition - 10, YPosition - 20);
            point5 = new Point(XPosition + 10, YPosition - 20);
            point6 = new Point(XPosition + 5, YPosition - 15);
            point7 = new Point(XPosition + 5, YPosition + 0);

            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.fire);
            textureBrush = new TextureBrush(bitmap);

            curvePoints = new Point[] { point1, point2, point3, point4, point5, point6, point7 };

        }

        public override void Move()
        {
            calcXPosition += DxPosition;
            calcYPosition += DyPosition;
            XPosition = (int)calcXPosition;
            YPosition = (int)calcYPosition;
            updateCurvePoint();
        }

        public void Accelerate()
        {
            YAccelleration = gravityForRocket.gravitationalAcceleration;
            DxPosition += XAccelleration;
            DyPosition += YAccelleration;
        }

        private void updateCurvePoint()
        {
            for (int i = 0; i < curvePoints.Length; i++)
            {
                curvePoints[0].X = XPosition + 0;
                curvePoints[0].Y = YPosition + 10;
                curvePoints[1].X = XPosition - 5;
                curvePoints[1].Y = YPosition + 0;
                curvePoints[2].X = XPosition - 5;
                curvePoints[2].Y = YPosition - 15;
                curvePoints[3].X = XPosition - 10;
                curvePoints[3].Y = YPosition - 20;
                curvePoints[4].X = XPosition + 10;
                curvePoints[4].Y = YPosition - 20;
                curvePoints[5].X = XPosition + 5;
                curvePoints[5].Y = YPosition - 15;
                curvePoints[6].Y = XPosition + 5;
                curvePoints[6].Y = YPosition + 0;
            }

        } 
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(textureBrush, curvePoints);
            e.Graphics.DrawPolygon(pen, curvePoints);


        }


    }
}
