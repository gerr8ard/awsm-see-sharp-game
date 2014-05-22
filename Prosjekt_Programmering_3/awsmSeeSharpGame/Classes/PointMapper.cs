using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    public static class PointMapper
    {
        public static void Mapper(string illustratorMap)
        {
            CultureInfo culture = new CultureInfo("en-GB");
            string[] temporaryValue;
            double X;
            double Y;
            List<Point> pointMap = new List<Point>();
            string[] pointArray = illustratorMap.Split();
            foreach (string element in pointArray)
            {
                temporaryValue = element.Split(',');
                X = Convert.ToDouble(temporaryValue[0], culture.NumberFormat);
                Y = Convert.ToDouble(temporaryValue[1], culture.NumberFormat);
                pointMap.Add(new Point((int) X, (int) Y));
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Point [] pointArray = new Point[]\n{");

            foreach (Point point in pointMap)
            {
                stringBuilder.Append(string.Format("new Point({0},{1}),",point.X, point.Y));
            }
            stringBuilder.Append("};");
            Debug.Write(stringBuilder.ToString());
        }
    }
}
