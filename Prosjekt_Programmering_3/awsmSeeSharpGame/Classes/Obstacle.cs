using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Obstacle(int _XPosition, int _YPosition, int _width, int _height, Color color)
        {
            XPosition = _XPosition;
            YPosition = _YPosition;
            width = _width;
            height = _height;
            pen = new Pen(color, 1);
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.PlanetTexture);

            textureBrush = new TextureBrush(bitmap);
        }

        public override void Draw(PaintEventArgs e) {
            //e.Graphics.DrawRectangle(pen, XPosition, YPosition, width, height);
            //e.Graphics.DrawEllipse(pen, XPosition, YPosition, width, height);
            e.Graphics.FillEllipse(textureBrush, XPosition, YPosition, width, height);
            e.Graphics.DrawEllipse(pen, XPosition, YPosition, width, height );

        }
    }
}
