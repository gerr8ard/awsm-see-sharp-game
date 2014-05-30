using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.UserControls
{
    /// <Forfatter>
    /// Pål Skogsrud
    /// </Forfatter>

    /// <summary>
    /// UserControl som viser hvordan spillet skal spilles. Gjøres ved hjelp av delegater som MainForm abonnerer på.
    /// </summary>
    public partial class HowToPlayControl : UserControl
    {

        public delegate void howToPlayDelegate(object sender, EventArgs e);
        public event howToPlayDelegate howToPlayEvent;

        public HowToPlayControl()
        {
            InitializeComponent();
            
        }

        private void hvordanSpilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            howToPlayEvent(sender, e);
        }

    }
}
