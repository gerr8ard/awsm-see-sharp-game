﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    public class ShapeMaps
    {
        public static Point[] RocketDesign1 ()
        {
            Point point1 = new Point(0, 10);
            Point point2 = new Point(-5, 0);
            Point point3 = new Point(-5, -15);
            Point point4 = new Point(-10, -20);
            Point point5 = new Point(10, -20);
            Point point6 = new Point(5, -15);
            Point point7 = new Point (5, 0);
            return new Point[] { point1, point2, point3, point4, point5, point6, point7 };
        }

        public static Point[] RocketDesign2()
        {
            Point point1 = new Point(23, 0);
            Point point2 = new Point(43, 47);
            Point point3 = new Point(41, 54);
            Point point4 = new Point(32, 56);
            Point point5 = new Point(27, 59);
            Point point6 = new Point(27, 65);
            Point point7 = new Point(23, 68);
            Point point8 = new Point(19, 65);
            Point point9 = new Point(19, 59);
            Point point10 = new Point(15, 55);
            Point point11 = new Point(5, 54);
            Point point12 = new Point(2, 48);
            return new Point[] { point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11, point12 };
        }

        /// <summary>
        /// Metode for å konvertere et punkt array til en GraphicsPath
        /// </summary>
        /// <param name="pointArray">Point[] array med koordinater</param>
        /// <returns></returns>
        public static GraphicsPath MakeGraphicsPath(Point[] pointArray)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            Point currentPoint = pointArray[0];
            for(int i = 1; i< pointArray.Length; i++){
                path.AddLine(currentPoint.X,currentPoint.Y,pointArray[i].X, pointArray[i].Y);
                currentPoint.X = pointArray[i].X;
                currentPoint.Y = pointArray[i].Y;
            }
            path.CloseFigure();
            return path;
        }
        public static GraphicsPath MakeElipseGraphicsPath(Rectangle rectangle)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddEllipse(rectangle);
            path.CloseFigure();
            return path;
        }
    }
}
