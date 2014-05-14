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
        Rectangle rect;
        Pen pen;
        public Obstacle(int width, int height, Color color)
        {
            rect = new Rectangle();
            pen = new Pen(color, 5);
        }

        public void OnPaint(Graphics g, PaintEventArgs e) {
            g.DrawRectangle(pen, rect);
        }
    }
}
