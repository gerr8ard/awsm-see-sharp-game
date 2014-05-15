using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// Shape har retning, posisjon og fart
    /// 
    /// </summary>
    public class Shape : IShape
    {
        //Posisjonene
        public Pen pen {get; set;}
        public static int XPosition {get; set;}
        public static int YPosition {get; set;}       
    }
}
