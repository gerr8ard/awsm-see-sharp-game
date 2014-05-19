using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame.Models;
using awsmSeeSharpGame.Classes;

namespace awsmSeeSharpGame.UserControls
{
    public partial class LoginControl : UserControl
    {
        public delegate void newUserDelegate(object sender, EventArgs e);
        public event newUserDelegate newUserEvent;
       
        public LoginControl()
        {
            InitializeComponent();
           
        }

        private void btnLoginLoginControl_Click(object sender, EventArgs e)
        {
            string givenUsername = tbUserNameLoginControl.Text;
            string givenPassword = tbPasswordLoginControl.Text;

            if (givenUsername != string.Empty && givenPassword != string.Empty)
            {
                awsm_Users user = Queries.GetUserByUserName(givenUsername);

                if (user != null)
                {
                    string salt = user.Salt;
                    string hash = user.Password;

                    if (Hash.CheckPassord(givenPassword, hash, salt))
                    {
                        MainForm.isLoggedIn = true;
                    }
                }
            }
            
        }
        
        private void btnNewUserLoginControl_Click(object sender, EventArgs e)
        {

            newUserEvent(sender, e);
            
        }
    }
}
