using awsmSeeSharpGame.interfaces;
using awsmSeeSharpGame.Models;
using awsmSeeSharpGame.UserControls;
using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Denne klassen sender ut de bevegelige objektene ut på tilfeldige tidspunkt
    /// Skrevet av Silje
    /// </summary>
    public class Emitter
    {
        int XPosition;
        int YPosition;
        public List<MovableShape> movableShapeList { get; set; }
        public List<MovableShape> activeMovableShapeList { get; set; }
        Random random = new Random();

        public Emitter(GamePanel panel, List<MovableShape> _movableShapeList)
        {
            movableShapeList = _movableShapeList;
            activeMovableShapeList = new List<MovableShape>();
            XPosition = (panel.panelWidth / 2);
            YPosition = 0;
       //     meteorList = new List<Meteor>();
         /*   meteorList = new List<Meteor>();

            for (int i = 0; i < 31; i++)
            {
                Y = random.next(panel.Height);
                meteorList.Add(new Meteor(XPosition, Y, 250, ShapeMaps.Meteor(), ShapeMaps.BitmapMeteor()));


            } */
        }

        public void EmitMovableShape()
        {
            if (movableShapeList.Count > 0)
            {
                int randomIndex = random.Next(movableShapeList.Count - 1);
                MovableShape currentShape = movableShapeList.ElementAt(randomIndex);
                activeMovableShapeList.Add(currentShape);
                movableShapeList.RemoveAt(randomIndex);
            }
        }

        public void RemoveMovableShapesWhenGone()
        {
            foreach (MovableShape shape in activeMovableShapeList)
            {
                if (shape.calcXPosition < 0)
                {
                    activeMovableShapeList.Remove(shape);
                }
            }
        }

/*        public void EmitMovingObject()
        {
            int chooser = random.Next(2);
         //   List<T> 
            if (chooser == 0)
            {
                Meteor meteor = new Meteor(XPosition, 100, 150, 0, ShapeMaps.Meteor(), ShapeMaps.BitmapMeteor());
                movableShapeList.Add(meteor);
            }
            else if (chooser == 1)
            {
                UFO ufo = new UFO(XPosition, 100, 150, 0, ShapeMaps.UFO(), ShapeMaps.BitmapUFO());
                movableShapeList.Add(ufo);
            }
            else if (chooser == 2)
            {
                AlienHead alienHead = new AlienHead(XPosition, 100, 150, 0, ShapeMaps.AlienHead(), ShapeMaps.BitmapAlienHead());
                movableShapeList.Add(alienHead);
            }

        } */

/*        public List<MovableShape> EmitMovingObject(List<MovableShape> list)
        {
            int chooser = random.Next(2);
            //   List<T> 
            if (chooser == 0)
            {
                Meteor meteor = new Meteor(XPosition, 100, 150, 0, ShapeMaps.Meteor(), ShapeMaps.BitmapMeteor());
                list.Add(meteor);
            }
            else if (chooser == 1)
            {
                UFO ufo = new UFO(XPosition, 100, 150, 0, ShapeMaps.UFO(), ShapeMaps.BitmapUFO());
                list.Add(ufo);
            }
            else if (chooser == 2)
            {
                AlienHead alienHead = new AlienHead(XPosition, 100, 150, 0, ShapeMaps.AlienHead(), ShapeMaps.BitmapAlienHead());
                list.Add(alienHead);
            }

            return list;
        }  */
    }
}
