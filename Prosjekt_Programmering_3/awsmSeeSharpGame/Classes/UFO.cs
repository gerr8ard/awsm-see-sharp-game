using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    public class UFO : MovableShape
    {
        public UFO(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _shapeMap, Bitmap _bitmap)
            : base(_XPosition, _YPosition, _Rotation, _speed, _shapeMap, _bitmap)
        {
            updateShapePosition();
        }
    }
}
