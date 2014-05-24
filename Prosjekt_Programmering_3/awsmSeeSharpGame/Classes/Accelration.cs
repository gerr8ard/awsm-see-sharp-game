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
           // gravitationalAcceleration = 0.01635f; //635f;
          //  gravitationalAcceleration = 0.025f;
            gravitationalAcceleration = 0.0981f; //635f;

        }

        public Acceleration(float _gravity)
        {
            gravitationalAcceleration = 0.0981f;


         //   gravitationalAcceleration = _gravity;

        //    thrust = _thrust;

        }

        public void SetAccelleration(double _elapsedTime, float _thrust, float _rotation)
        {
            float currentGravitationalAccelleration = gravitationalAcceleration * (float)_elapsedTime;
            thrust = _thrust;
            rotationRad = (_rotation / 180) * (float)Math.PI;
            thrustX = (thrust * (float)(Math.Sin(rotationRad)));
            thrustY = (thrust * (float)(Math.Cos(rotationRad)));
            accelerationY = currentGravitationalAccelleration - thrustY;
        }
    }
}
