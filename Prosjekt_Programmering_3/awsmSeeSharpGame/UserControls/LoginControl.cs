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
    public partial class LoginControl : UserControl
    {
        public delegate void LoginControlDelegate(object sender, EventArgs e);
        public event LoginControlDelegate loginControlEvent;
       
        public LoginControl()
        {
            InitializeComponent();
           
        }

        private void btnLoginLoginControl_Click(object sender, EventArgs e)
        {
            
            
        }
        
        private void btnNewUserLoginControl_Click(object sender, EventArgs e)
        {

            loginControlEvent(sender, e);
            
        }
    }
}
