using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pnlInfo.BackColor = Color.FromArgb(85, 0, 0, 0);
        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
