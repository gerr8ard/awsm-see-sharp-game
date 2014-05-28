using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    class RandomGenerator
    {
        private static Random random = new Random();
    
        static public int randomIntBetween20And60()
        {

            int n = random.Next(20, 60);
            return n;
        }

    }

    
}
