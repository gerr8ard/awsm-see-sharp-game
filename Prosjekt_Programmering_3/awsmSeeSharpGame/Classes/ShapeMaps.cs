using System;
using System.Collections.Generic;
using System.Drawing;
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
            Point point1 = new Point(306, 361);
            Point point2 = new Point(326, 408);
            Point point3 = new Point(324, 415);
            Point point4 = new Point(315, 417);
            Point point5 = new Point(310, 420);
            Point point6 = new Point(310, 426);
            Point point7 = new Point(306, 429);
            Point point8 = new Point(302, 426);
            Point point9 = new Point(302, 420);
            Point point10 = new Point(298, 416);
            Point point11 = new Point(288, 415);
            Point point12 = new Point(285, 409);
            return new Point[] { point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11, point12 };
        }
    }
}
