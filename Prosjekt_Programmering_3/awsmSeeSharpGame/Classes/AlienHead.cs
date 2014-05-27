using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public class AlienHead : MovableShape
    {
        public bool isCollected { get; set; } //Om hodet er plukke opp eller ei.

        public AlienHead(int _XPosition, int _YPosition, int _speed, float _Rotation, Point[] _shapeMap, Bitmap _bitmap) 
            : base(_XPosition, _YPosition, _Rotation, _speed, _shapeMap, _bitmap)
        {
            isCollected = false; //setter alienhodet til å ikke være plukket opp.
            updateShapePosition();
        }

        public override void Draw(PaintEventArgs e)
        {
            if (!isCollected)
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImageUnscaled(bitmap, new Point(XPosition, YPosition));
                e.Graphics.DrawPolygon(pen, shapeMapPosition);
            }
        }
    }
}
