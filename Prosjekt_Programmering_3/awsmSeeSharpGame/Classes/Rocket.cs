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
    public class Rocket : MovableShape
    {
        //Farten
        private int dxPosisjon = 0;
        private int dyPosisjon = 1;

        public void Flytt()
        {
            Shape.XPosition += dxPosisjon;
            Shape.YPosition += dyPosisjon;
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
