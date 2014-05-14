using awsmSeeSharpGame.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class MovableShape : Shape, IMoveableShape
    {
        public void Move()
        {

        }

        public bool Collision()
        {
            return true;
        }
    }
}
