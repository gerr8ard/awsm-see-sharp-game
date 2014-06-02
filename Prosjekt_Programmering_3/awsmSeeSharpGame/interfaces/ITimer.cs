using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame
{

    /// <summary>
    /// Skrevet av Dag Ivarsøy
    /// </summary>
    public interface ITimer
    {
        void Start();
        void Stop();
        void Close();

        bool AutoReset { get; set; }
        bool Enabled { get; set; }
        double Interval { get; set; }
        ISynchronizeInvoke SynchronizingObject { get; set; }

        event ElapsedEventHandler Elapsed;
    }
}
