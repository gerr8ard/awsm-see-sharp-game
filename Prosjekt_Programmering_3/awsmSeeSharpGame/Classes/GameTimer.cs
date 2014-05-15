using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace awsmSeeSharpGame.Classes
{
    public class GameTimer : IGameTimer
    {
        public event sekundOppdateringHandler sekundOppdatering; //Ikke brukt ennå
        public delegate void sekundOppdateringHandler(object source, ElapsedEventArgs e); //ikke brukt ennå

        private TimeSpan tid; //Timespan objekt som holder på tiden som er igjen
        private TimeSpan zeroTime = new TimeSpan(0); //Timespan objekt med verdien 0, som brukes for sammenligningsgrunnlag
        private TimeSpan oneSecond = new TimeSpan(0, 0, 1); // Timepan objekt på 1 sekund. Settes her for å slippe å lage mange søppelobjekter
        private ITimer timer; //System Timer objekt
        private Boolean isRunning; //Bool som indikerer om timeren er aktiv

        /// <summary>
        /// Konstruktør som setter igang timeren med angitt tid
        /// </summary>
        /// <param name="_tid">Starttid som timeren teller ned ifra</param>
        public GameTimer(TimeSpan _tid) 
        {
            tid = _tid;   
            timer = new SystemTimer();
            timer.Elapsed += new ElapsedEventHandler(TimerEvent);
            timer.Interval = 1000; //Setter timeren til å kalle eventhandleren hvert sekund
            timer.Enabled = true;
            timer.Start();
            isRunning = true;
        }

        /// <summary>
        /// event handler som blir kjørt hvert sekund
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e">ElapsedEventArgs</param>
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

        /// <summary>
        /// Henter ut gjenstående tid på timeren
        /// </summary>
        /// <returns>Timespan Tiden som er igjen</returns>
        public TimeSpan GetTid(){
            return tid;
        }

        /// <summary>
        /// Sjekker om timeren fremdeles kjører
        /// </summary>
        /// <returns>Bool Status på timeren</returns>
        public Boolean IsRunning()
        {
            return isRunning;
        }

        // Metode for å kjøre tester
        public GameTimer(ITimer _timer, TimeSpan _tid)
        {
            tid = _tid;
            timer = _timer;
            timer.Elapsed += new ElapsedEventHandler(TimerEvent);
            timer.Enabled = true;
            timer.Start();
            isRunning = true;
        }
     }
}
