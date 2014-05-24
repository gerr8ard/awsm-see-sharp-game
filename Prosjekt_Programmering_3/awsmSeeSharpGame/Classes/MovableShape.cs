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

        public float DxPosition { get; set; }
        public float DyPosition { get; set; }

        public float XAccelleration { get; set; }
        public float YAccelleration { get; set; }

        public float calcXPosition { get; set; }
        public float calcYPosition { get; set; }

        public float speed { get; set; }

        public override abstract void Draw(PaintEventArgs e);

        public virtual void Move(float _elapsedTime)
        {
            DxPosition -= speed * _elapsedTime;
            XPosition = (int)DxPosition;
            updateShapePosition();
        }
    }
}
