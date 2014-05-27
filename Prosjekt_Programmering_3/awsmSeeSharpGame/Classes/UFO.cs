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

        //Lager en ny bullet og legger den til i bulletlista. Bør oppdateres så den kun legger ut en kule hver nte gang rutinen kjøres eller noe slikt
        public void Move(DrawShapes _drawShapes, float _elapsedTime)
        {
            Move(_elapsedTime);
            if (XPosition < 1200 && XPosition > 0)
            {
                Bullet newbullet = new Bullet(XPosition, YPosition, (int) speed+100, 0.0F, ShapeMaps.alienBullet(), ShapeMaps.BitmapBullet3());
                _drawShapes.AddBullet(newbullet);
            }
        }
        public override void Move(float _elapsedTime)
        {
            base.Move(_elapsedTime);
        }
    }
}
