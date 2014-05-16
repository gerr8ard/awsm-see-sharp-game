using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame.Classes;

namespace awsmSeeSharpGame.Classes
{
    public abstract class MovableShape : Shape, IMoveableShape
    {

        abstract public void Move();
        public int DxPosisjon { get; set; }
        public int DyPosisjon { get; set; }


        public bool Collision()
        {
            return true;
        }

        public override abstract void Draw(PaintEventArgs e);
    }
}
