using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame.Classes
{
    public class GameTimer
    {
        private TimeSpan tid; //Timespan objekt som holder på tiden som er igjen
        private TimeSpan zeroTime = new TimeSpan(0); //Timespan objekt med verdien 0, som brukes for sammenligningsgrunnlag
        private TimeSpan oneSecond = new TimeSpan(0, 0, 1); // Timepan objekt på 1 sekund. Settes her for å slippe å lage mange søppelobjekter
        private Timer timer; //System Timer objekt
        private Boolean isRunning; //Bool som indikerer om timeren er aktiv

        public GameTimer(TimeSpan _tid) 
        {
            tid = _tid;   
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerEvent);
            timer.Interval = 1000; //Setter timeren til å kalle eventhandleren hvert sekund
            timer.Enabled = true;
            timer.Start();
            isRunning = true;
        }


        private void TimerEvent(object source, ElapsedEventArgs e)
        {
            if (tid > zeroTime)
                tid = tid - oneSecond;
            else
            {
                isRunning = false;
                timer.Stop();
            }
        }

        public TimeSpan GetTid(){
            return tid;
        }

        public Boolean IsRunning()
        {
            return isRunning;
        }
     }
}
