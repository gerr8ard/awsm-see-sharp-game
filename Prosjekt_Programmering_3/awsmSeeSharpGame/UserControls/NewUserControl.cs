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

        public delegate void NewUserControlDelegate(object sender, EventArgs e);
        public event NewUserControlDelegate newUserControlEvent;
        string newUserUserName, newUserFirstName, newUserSureName, newUserPassword, newUserRetypePassword;

        public NewUserControl()
        {
            InitializeComponent();
        }

        private void btnCancelNewUserControl_Click(object sender, EventArgs e)
        {
            newUserControlEvent(sender, e);
        }

        private void btnRegisterNewUserNewUserControl_Click(object sender, EventArgs e)
        {
            newUserUserName = tbUserNameNewUserControl.Text;
            newUserFirstName = tbFirstNameNewUserControl.Text;
            newUserSureName = tbSureNameNewUserControl.Text;
            newUserPassword = tbPasswordNewUserControl.Text;
            newUserRetypePassword = tbRetypePasswordNewUserControl.Text;
        }
    }
}
