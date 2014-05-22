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
        public int speed;
        
        public Meteor(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _meteorMap)
        {
            bitmap = new Bitmap(awsmSeeSharpGame.Properties.Resources.Meteor);

            shapeMap = _meteorMap;
            shapeMapPosition = new Point[shapeMap.Length];
            Array.Copy(shapeMap, shapeMapPosition, shapeMap.Length);

            XPosition = _XPosition;
            YPosition = _YPosition;
            Width = bitmap.Width;
            Height = bitmap.Height;

            Rotation = _Rotation;
            speed = _speed;
            pen = new Pen(Color.White);
            updateShapePosition();

        }

        public override void Move()
        {
            XPosition -= speed;
            updateShapePosition();
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, new Point(XPosition, YPosition));
            e.Graphics.DrawPolygon(pen, shapeMapPosition);
        }
    }
}
