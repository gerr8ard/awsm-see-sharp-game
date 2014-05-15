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
        public int XPosition {get; set;}
        public int YPosition {get; set;}
        public abstract void Draw(PaintEventArgs e);
    }
}
