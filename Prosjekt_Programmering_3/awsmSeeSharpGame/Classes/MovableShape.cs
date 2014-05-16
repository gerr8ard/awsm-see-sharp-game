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
        public float DxPosition { get; set; }
        public float DyPosition { get; set; }

        public float XAccelleration { get; set; }
        public float YAccelleration { get; set; }

        public float calcXPosition { get; set; }
        public float calcYPosition { get; set; }

        public bool Collision()
        {
            return true;
        }

        public override abstract void Draw(PaintEventArgs e);
    }
}
