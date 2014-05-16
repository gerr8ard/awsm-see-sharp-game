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
        Pen pen = new Pen(Color.White);
        SolidBrush brush = new SolidBrush(Color.White);
        Point[] curvePoints;
        TextureBrush textureBrush;
        Bitmap bitmap;

        public Rocket(int _XPosition, int _YPosition, int _Rotation)
        {
            XPosition = _XPosition;
            YPosition = _YPosition;
            Rotation = _Rotation;
            DxPosisjon = 1;
            DyPosisjon = 0;

            point1 = new Point(100 + XPosition, 0 + YPosition);
            point2 = new Point(150 + XPosition, 50 + YPosition);
            point3 = new Point(250 + XPosition, 50 + YPosition);
            point4 = new Point(150 + XPosition, 100 + YPosition);
            point5 = new Point(50 + XPosition, 100 + YPosition);
            point6 = new Point(0 + XPosition, 50 + YPosition);
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.fire);
            textureBrush = new TextureBrush(bitmap);

            curvePoints = new Point[] { point1, point2, point3, point4, point5, point6 };

        }

        public override void Move()
        {
            XPosition += DxPosisjon;
            YPosition += DyPosisjon;
            updateCurvePoint();
        }



        private void updateCurvePoint()
        {
            for (int i = 0; i < curvePoints.Length; i++)
            {
                curvePoints[i].X += DxPosisjon;
                curvePoints[i].Y += DyPosisjon;
            }

        } 
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillPolygon(textureBrush, curvePoints);
            e.Graphics.DrawPolygon(pen, curvePoints);


        }


    }
}
