using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame.Classes;
using System.Drawing;

namespace awsmSeeSharpGame.Classes
{

    /// <summary>
    /// Skrevet av Dag Ivarsøy
    /// </summary>
    public abstract class MovableShape : Shape, IMoveableShape
    {

        public float DxPosition { get; set; }
        public float DyPosition { get; set; }

        public float XAccelleration { get; set; }
        public float YAccelleration { get; set; }

        public float calcXPosition { get; set; }
        public float calcYPosition { get; set; }

    

        public float speed { get; set; }

        public MovableShape() { }

        public MovableShape(int _XPosition, int _YPosition, float _Rotation, float _speed, Point[] _shapeMap, Bitmap _bitmap)
        {
            shapeMap = _shapeMap;
            shapeMapPosition = new Point[shapeMap.Length];
            Array.Copy(shapeMap, shapeMapPosition, shapeMap.Length);

            XPosition = _XPosition;
            YPosition = _YPosition;
            DxPosition = XPosition;
            DyPosition = YPosition;

            bitmap = _bitmap;
            Width = bitmap.Width;
            Height = bitmap.Height;
            speed = _speed;


            Rotation = _Rotation;
            pen = new Pen(Color.White);
            updateShapePosition();
        }

        public virtual void Move(float _elapsedTime)
        {
            DxPosition -= speed * _elapsedTime;
            XPosition = (int)DxPosition;
            updateShapePosition();
        }
    }
}
