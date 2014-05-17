using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame.UserControls;

namespace awsmSeeSharpGame
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnLoginLoginControl_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterNewUserLoginControl_Click(object sender, EventArgs e)
        {
            NewUserControl newUser = new NewUserControl();
            
        }
    }
}
