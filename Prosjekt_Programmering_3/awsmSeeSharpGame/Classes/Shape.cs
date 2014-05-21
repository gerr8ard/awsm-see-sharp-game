using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public abstract void Draw(PaintEventArgs e);
    }
}
