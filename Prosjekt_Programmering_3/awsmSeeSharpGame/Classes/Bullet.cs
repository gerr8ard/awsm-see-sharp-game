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
    /// Posisjon, fart og retning arves
    /// Startposisjon er ved Enemy toppunkt
    /// Retning er samme som Enemy
    /// Kuler forsvinner ved kollisjon
    /// </summary>
    public class Bullet : MovableShape
    {
        public Bullet(int _XPosition, int _YPosition, int _Rotation)
        {
            rectangle = new Rectangle();
            rectangle.X = _XPosition;
            rectangle.Y = _YPosition;
            calcXPosition = rectangle.X;
            calcYPosition = rectangle.Y;
            Rotation = _Rotation;
            DxPosition = 0;
            DyPosition = 0;
        }

        public override void Move(float _elapsedTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(PaintEventArgs e)
        {

        }

    }
}
