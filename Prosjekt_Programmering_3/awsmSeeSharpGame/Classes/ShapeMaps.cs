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
    }
}
