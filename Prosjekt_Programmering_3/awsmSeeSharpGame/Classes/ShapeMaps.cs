using System;
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
        public static Bitmap BitmapRocketDesign2()
        {
            return new Bitmap(awsmSeeSharpGame.Properties.Resources.Rocket2);
        }

        public static Point[] alienBullet()
        {
            Point[] pointArray = new Point[] {
            new Point(0,2), new Point(3,0), new Point(17,0), new Point(17,5), new Point(3,5), new Point(0,4)};
            return pointArray;
        }

        public static Bitmap BitmapBullet3()
        {
            return new Bitmap(awsmSeeSharpGame.Properties.Resources.bullet3);
        }

        public static Point[] Meteor()
        {
            Point[] pointArray = new Point[]{
            new Point(14,0),new Point(14,1),new Point(16,1),new Point(17,1),new Point(18,1),new Point(19,1),
            new Point(20,2),new Point(20,3),new Point(21,2),new Point(22,3),new Point(23,3),new Point(23,3),
            new Point(24,2),new Point(25,2),new Point(26,2),new Point(27,2),new Point(29,3),new Point(29,3),
            new Point(30,4),new Point(31,3),new Point(32,3),new Point(33,4),new Point(33,3),new Point(33,3),
            new Point(34,3),new Point(35,3),new Point(36,4),new Point(36,4),new Point(37,4),new Point(37,4),
            new Point(37,4),new Point(38,4),new Point(38,5),new Point(39,5),new Point(40,5),new Point(41,5),
            new Point(43,5),new Point(45,5),new Point(45,5),new Point(47,5),new Point(48,5),new Point(49,5),
            new Point(49,5),new Point(50,5),new Point(50,4),new Point(51,5),new Point(52,5),new Point(54,5),
            new Point(55,5),new Point(57,5),new Point(58,5),new Point(59,5),new Point(59,6),new Point(60,6),
            new Point(62,6),new Point(63,6),new Point(64,6),new Point(66,6),new Point(66,6),new Point(67,6),
            new Point(68,6),new Point(69,6),new Point(69,7),new Point(70,7),new Point(70,8),new Point(71,8),
            new Point(72,8),new Point(73,8),new Point(74,9),new Point(74,9),new Point(76,9),new Point(76,9),
            new Point(77,9),new Point(77,9),new Point(77,10),new Point(77,10),new Point(76,10),new Point(74,10),
            new Point(73,11),new Point(72,11),new Point(70,11),new Point(69,11),new Point(68,11),new Point(67,11),
            new Point(66,11),new Point(66,11),new Point(65,11),new Point(65,12),new Point(64,12),new Point(64,12),
            new Point(63,12),new Point(63,12),new Point(62,12),new Point(61,13),new Point(60,13),new Point(59,12),
            new Point(58,12),new Point(57,12),new Point(56,12),new Point(55,12),new Point(54,12),new Point(52,12),
            new Point(51,12),new Point(48,12),new Point(47,13),new Point(47,13),new Point(45,13),new Point(44,14),
            new Point(43,14),new Point(42,14),new Point(41,14),new Point(40,14),new Point(39,14),new Point(39,15),
            new Point(38,16),new Point(36,15),new Point(35,15),new Point(33,15),new Point(32,15),new Point(32,15),
            new Point(31,14),new Point(31,14),new Point(30,14),new Point(29,14),new Point(27,14),new Point(26,15),
            new Point(26,15),new Point(25,16),new Point(24,16),new Point(24,16),new Point(24,16),new Point(24,17),
            new Point(24,18),new Point(23,17),new Point(23,17),new Point(22,17),new Point(21,17),new Point(20,16),
            new Point(19,16),new Point(19,17),new Point(18,17),new Point(18,17),new Point(17,17),new Point(16,17),
            new Point(16,17),new Point(16,18),new Point(15,18),new Point(14,18),new Point(13,18),new Point(13,18),
            new Point(12,18),new Point(12,18),new Point(12,18),new Point(12,18),new Point(11,19),new Point(9,19),
            new Point(9,18),new Point(8,18),new Point(7,17),new Point(7,17),new Point(6,17),new Point(6,17),
            new Point(5,17),new Point(5,16),new Point(5,16),new Point(4,16),new Point(4,15),new Point(4,14),
            new Point(3,15),new Point(3,14),new Point(2,14),new Point(2,13),new Point(1,14),new Point(1,13),
            new Point(1,13),new Point(0,12),new Point(0,11),new Point(0,10),new Point(0,9),new Point(1,8),
            new Point(1,7),new Point(1,6),new Point(2,6),new Point(2,5),new Point(2,5),new Point(3,4),new Point(4,4),
            new Point(4,3),new Point(5,2),new Point(6,2),new Point(7,2),new Point(7,1),new Point(7,1),new Point(9,0),
            new Point(9,0),new Point(10,0),new Point(11,0),new Point(13,0)};
            return pointArray;
        }
        public static Bitmap BitmapMeteor()
        {
            return new Bitmap(awsmSeeSharpGame.Properties.Resources.Meteor);
        }

        public static Point[] AlienHead()
        {
            Point[] pointArray = new Point[] { new Point(14, 43), new Point(16, 43), new Point(17, 42), new Point(19, 39),
            new Point(21, 36), new Point(22, 34), new Point(24, 31), new Point(26, 29), new Point(29, 29), new Point(30, 27),
            new Point(32, 23), new Point(33, 19), new Point(33, 13), new Point(33, 9), new Point(31, 6), new Point(26, 2),
            new Point(21, 0), new Point(16, 0), new Point(10, 1), new Point(8, 2), new Point(5, 4), new Point(3, 6), new Point(1, 9),
            new Point(0, 12), new Point(0, 16), new Point(0, 20), new Point(0, 22), new Point(1, 29), new Point(1, 30), 
            new Point(3, 31), new Point(5, 35), new Point(6, 37), new Point(7, 41), new Point(8, 42), new Point(10, 44)};
            return pointArray;
        }
        public static Bitmap BitmapAlienHead()
        {
            return new Bitmap(awsmSeeSharpGame.Properties.Resources.alien_head);
        }

        public static Point[] UFO ()
        {
            Point [] pointArray = new Point[] {
                new Point(0,7),new Point(1,5),new Point(3,4),new Point(5,3),new Point(8,3),new Point(11,3),new Point(12,2),
                new Point(14,1),new Point(16,0),new Point(17,0),new Point(20,0),new Point(26,0),new Point(29,0),new Point(32,0),
                new Point(33,0),new Point(36,2),new Point(36,3),new Point(40,3),new Point(43,3),new Point(45,4),new Point(47,5),
                new Point(49,6),new Point(50,7),new Point(49,9),new Point(48,10),new Point(46,11),new Point(43,12),new Point(38,13),
                new Point(33,13),new Point(18,13),new Point(14,13),new Point(10,13),new Point(7,12),new Point(3,11),new Point(1,9)
            };
            return pointArray;
        }
        public static Bitmap BitmapUFO()
        {
            return new Bitmap(awsmSeeSharpGame.Properties.Resources.alien_spaceship);
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
