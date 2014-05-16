using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class Gravity
    {
        public float gravitationalAcceleration { get; set; }

        public Gravity()
        {
            gravitationalAcceleration = 0.01635f; //635f;
        }

        public Gravity(float _gravity)
        {
            gravitationalAcceleration = _gravity;
        }
    }
}
