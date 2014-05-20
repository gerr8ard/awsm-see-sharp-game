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
        private int width;
        private int height;
        private Bitmap bitmap;
        private Pen pen;
        private GraphicsPath path;

        public Obstacle(int _XPosition, int _YPosition, int _width, int _height, Color color)
        {
            rectangle = new Rectangle();
            rectangle.X = _XPosition;
            rectangle.Y = _YPosition;
            rectangle.Width = _width;
            rectangle.Height = _height;
            pen = new Pen(color, 1);
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.PlanetTexture);

            path = ShapeMaps.MakeElipseGraphicsPath(rectangle);
            region = new Region(path);

            textureBrush = new TextureBrush(bitmap);
        }

        public override void Draw(PaintEventArgs e) {
            e.Graphics.FillEllipse(textureBrush, rectangle);
            e.Graphics.DrawEllipse(pen, rectangle);
        }
    }
}
