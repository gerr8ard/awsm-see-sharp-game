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
        private int width;
        private int height;

        public Obstacle(int _XPosition, int _YPosition, int _width, int _height, Color color)
        {
            XPosition = _XPosition;
            YPosition = _YPosition;
            width = _width;
            height = _height;
            pen = new Pen(color, 5);
        }

        public void Draw(PaintEventArgs e) {
            e.Graphics.DrawRectangle(pen, XPosition, YPosition, width, height);

        }
    }
}
