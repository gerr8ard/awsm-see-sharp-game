using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class Acceleration
    {
        public float gravitationalAcceleration { get; set; }
        public float thrust { get; set; }
        public float thrustX { get; set; }
        public float thrustY { get; set; }
        public float rotationRad { get; set; }
        public float accelerationY { get; set; }

        public Acceleration()
        {
            gravitationalAcceleration = 0.01635f; //635f;
        }

        public Acceleration(float _gravity)
        {
            gravitationalAcceleration = 0.01635f;


         //   gravitationalAcceleration = _gravity;

        //    thrust = _thrust;

        }

        public void SetAccelleration(float _thrust, float _rotation)
        {
            thrust = _thrust;
            rotationRad = (_rotation / 180) * (float)Math.PI;
            thrustX = (thrust * (float)(Math.Sin(rotationRad)));
            thrustY = (thrust * (float)(Math.Cos(rotationRad)));
            accelerationY = gravitationalAcceleration - thrustY;
        }
    }
}
