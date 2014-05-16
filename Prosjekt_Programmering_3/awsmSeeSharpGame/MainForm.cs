using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame
{
    public partial class MainForm : Form
    {
        GameTimer timer; //Timeren som holder styr på hvor lenge det er igjen av spillrunden.
        Boolean isGameRunning;
        ThreadStart threadStartInfoPanel;
        Thread threadInfoPanel;
        GamePanel gamePanel;

        /// <summary>
        /// Konstruktør
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            isGameRunning = false;
            startSpill();

            threadStartInfoPanel = new ThreadStart(InfoPanelDraw);
            threadInfoPanel = new Thread(threadStartInfoPanel);
            threadInfoPanel.IsBackground = true;
            threadInfoPanel.Start();
        }

        /// <summary>
        /// Starter et nytt spill
        /// </summary>
        private void startSpill()
        {
            gamePanel = new GamePanel();
            Controls.Add(gamePanel);
            

            TimeSpan spillTid = new TimeSpan(0, 5, 0); //Setter spilltiden til 5 minutter
            timer = new GameTimer(spillTid); //starter en ny timer
            isGameRunning = true;
        }

        /// <summary>
        /// Stopper et spill
        /// </summary>
        private void stoppSpill()
        {
            timer = null;
            isGameRunning = false;
        }

        /// <summary>
        /// Tegner opp Info panelet
        /// </summary>
        private void InfoPanelDraw()
        {
            while (true)
            {
                pnlInfo.Invalidate();
                Thread.Sleep(17); 
            }
        }

        /// <summary>
        /// Paint metode for Info panelet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            lblTid.Text = timer.GetTid().ToString(); // Oppdater tidslabelen.

        }

        /// <summary>
        /// Metode som blir kjørt når programmet lukkes. Stopper kjørende spill og tråder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stoppSpill();
            threadInfoPanel.Abort();
        }

        private void MenuItemAvslutt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void omToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }
    }
}
