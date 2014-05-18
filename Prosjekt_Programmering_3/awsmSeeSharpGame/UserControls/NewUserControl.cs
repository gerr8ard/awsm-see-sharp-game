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
    public partial class NewUserControl : UserControl
    {

        public delegate void cancelDelegate(object sender, EventArgs e);
        public event cancelDelegate cancelEvent;
        string newUserUserName;

        public NewUserControl()
        {
            InitializeComponent();
        }

        private void btnCancelNewUserControl_Click(object sender, EventArgs e)
        {
            cancelEvent(sender, e);
        }

        private void btnRegisterNewUserNewUserControl_Click(object sender, EventArgs e)
        {
           
        }
    }
}
