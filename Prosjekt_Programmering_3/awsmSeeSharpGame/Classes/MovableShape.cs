using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public abstract class MovableShape : Shape, IMoveableShape
    {
        public void Move()
        {

        }

        public bool Collision()
        {
            return true;
        }

        public override abstract void Draw(PaintEventArgs e);
    }
}
