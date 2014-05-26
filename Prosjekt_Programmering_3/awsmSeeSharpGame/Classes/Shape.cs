using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Shape har retning, posisjon og fart
    /// 
    /// </summary>
    public abstract class Shape : IShape
    {
        //Posisjonene
        public Pen pen {get; set;}
        public Rectangle rectangle;
        public Region region;
        public float Rotation { get; set; }

        protected Point[] shapeMap;
        protected Point[] shapeMapPosition;
        protected int XPosition { get; set; }
        protected int YPosition { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }
        protected Bitmap bitmap;

        protected virtual void updateShapePosition()
        {
            for (int i = 0; i < shapeMap.Length; i++)
            {
                shapeMapPosition[i].X = XPosition + shapeMap[i].X;
                shapeMapPosition[i].Y = YPosition + shapeMap[i].Y;
            }
            GraphicsPath graphicPath = ShapeMaps.MakeGraphicsPath(shapeMapPosition);
            region = new Region(graphicPath);
        }

        public virtual void Draw(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, new Point(XPosition, YPosition));
            e.Graphics.DrawPolygon(pen, shapeMapPosition);
        }
    }
}
