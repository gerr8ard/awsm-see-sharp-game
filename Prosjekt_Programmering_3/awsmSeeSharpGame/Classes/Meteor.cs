using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    public class Meteor : MovableShape
    {
        private Point[] meteorMap;
        private Point[] meteorMapPosition;
        private Bitmap bitmap;
        public int speed;
        
        public Meteor(int _XPosition, int YPosition, int speed, float _Rotation, Point[] _meteorMap)
        {
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.Meteor);

            meteorMap = _meteorMap;
            meteorMapPosition = new Point[meteorMap.Length];
            Array.Copy(meteorMap, meteorMapPosition, meteorMap.Length);
        }
    }
}
