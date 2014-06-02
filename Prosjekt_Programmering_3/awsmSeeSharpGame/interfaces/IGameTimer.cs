using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame
{

    /// <summary>
    /// Skrevet av Dag Ivarsøy
    /// </summary>
    public interface IGameTimer
    {
        TimeSpan GetTid();
        Boolean IsRunning();
    }
}
