using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public class Meteor : MovableShape
    {       
        public Meteor(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _shapeMap, Bitmap _bitmap) : base(_XPosition, _YPosition, _Rotation, _speed, _shapeMap, _bitmap)
        {
        }
    }
}
