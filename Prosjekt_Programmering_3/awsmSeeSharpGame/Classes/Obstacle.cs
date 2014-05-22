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
    public class Obstacle : Shape
    {
        private TextureBrush textureBrush;
        private GraphicsPath path;

        public Obstacle(int _XPosition, int _YPosition, int _width, int _height, Color color)
        {
            rectangle = new Rectangle();
            XPosition = _XPosition;
            YPosition = _YPosition;
            Width = _width;
            Height = _height;
            pen = new Pen(color, 1);
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.PlanetTexture);

            path = ShapeMaps.MakeElipseGraphicsPath(new Rectangle(XPosition, YPosition, Width, Height));
            region = new Region(path);

            textureBrush = new TextureBrush(bitmap);
        }

        public override void Draw(PaintEventArgs e) {
            e.Graphics.FillEllipse(textureBrush, XPosition,YPosition, Width, Height);
            e.Graphics.DrawEllipse(pen, XPosition, YPosition, Width, Height);
        }
    }
}
