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
    public partial class StartPageControl : UserControl
    {
        public delegate void startPageDelegate(object sender, EventArgs e);
        public event startPageDelegate startPageClickEvent;

        public StartPageControl()
        {
            InitializeComponent();
            
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            startPageClickEvent(sender, e);
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            startPageClickEvent(sender, e);
        }

        private void btn_Terminate_Click(object sender, EventArgs e)
        {
            startPageClickEvent(sender, e);
        }
    }
}
