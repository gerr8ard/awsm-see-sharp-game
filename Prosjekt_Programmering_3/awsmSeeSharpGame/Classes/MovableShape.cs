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
        public int dxPosisjon = 0;
        public int dyPosisjon = 1;
  //      Rocket rocket;
        public void Move()
        {
            YPosition += dyPosisjon;
            XPosition += dxPosisjon;
        }

        public bool Collision()
        {
            return true;
        }

        public override abstract void Draw(PaintEventArgs e);
    }
}
