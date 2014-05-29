using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame.Classes
{
    /// <Forfatter>
    /// Dag Ivarsøy og Pål Skogsrud
    /// </Forfatter>
    public class UFO : MovableShape
    {
        private int updateCounter = 0;
        public int f = 30;

        public UFO(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _shapeMap, Bitmap _bitmap)
            : base(_XPosition, _YPosition, _Rotation, _speed, _shapeMap, _bitmap)
        {
            updateShapePosition();
        }

        //Lager en ny bullet og legger den til i bulletlista. Bør oppdateres så den kun legger ut en kule hver nte gang rutinen kjøres eller noe slikt
        public void Move(DrawShapes _drawShapes, float _elapsedTime, int _random)
        {
           
            Move(_elapsedTime);
            if (XPosition < 1200 && XPosition > 0)
            {

                Bullet newbullet = new Bullet(XPosition, YPosition, (int) speed+300, 0.0F, ShapeMaps.alienBullet(), ShapeMaps.BitmapBullet3());
                if (updateCounter >= _random)
                {
                 //   _drawShapes.AddBullet(newbullet);
                    updateCounter = 0;
                }
                else updateCounter++;
                
            }
        }
        public override void Move(float _elapsedTime)
        {
            base.Move(_elapsedTime);
        }

       
    }
}
