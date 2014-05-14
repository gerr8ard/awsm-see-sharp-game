using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace awsmSeeSharpGame.Classes
{
    /// <summary>
    /// 
    /// Gravitasjon trekker objektet nedover
    /// Kollisjon med bullet avslutter spillet
    /// Kollisjon med obsticles gir minuspoeng
    /// </summary>
    class Rocket : MovableShape
    {
        //Farten
        private float dxPosisjon = 0f;
        private float dyPosisjon = 1.0f;

        public void Flytt()
        {
            Shape.xPosisjon += dxPosisjon;
            Shape.yPosisjon += dyPosisjon;
        }

/*        public void EndreFartsRetning(bool venstre, bool høyre, bool opp)
        {
            if (venstre)
                dxPosisjon -= 1.0f;
            if (høyre)
                dxPosisjon += 1.0f;
            if (opp)
                dyPosisjon -= 1.8f;
        } */
    }
}
