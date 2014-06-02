using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{

    /// <summary>
    /// Bare tjafs skrevet av Pål Skogsrud
    /// </summary>
    class RandomGenerator
    {
        private static Random random = new Random();
    
        static public int randomIntBetween20And60()
        {

            int n = random.Next(500, 3000);
            return n;
        }

    }

    
}
