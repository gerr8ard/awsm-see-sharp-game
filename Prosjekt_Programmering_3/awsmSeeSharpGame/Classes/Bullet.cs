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
        public Bullet(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _shapeMap, Bitmap _bitmap)
            : base(_XPosition, _YPosition, _Rotation, _speed, _shapeMap, _bitmap)
        {
        }

    }
}
