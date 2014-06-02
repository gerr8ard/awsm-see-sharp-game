using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame
{
    public class SystemTimer : Timer, ITimer
    {
        public SystemTimer() : base() { }
        public SystemTimer(double interval) : base(interval) { }
    }
}
