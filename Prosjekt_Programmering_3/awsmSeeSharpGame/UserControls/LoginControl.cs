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

    /// <summary>
    /// Skrevet av Pål Skogsrud
    /// User control som tar seg av logg inn delen,
    /// og bruker delegater og eventer for å bli vist i panelet pnlMainForm i MainForm.
    /// Har en metode som sjekker brukernavn og passord, og logger inn bruker dersom alt er riktig.
    /// Har en metode som videresender kontrollen til newUserControl for å registrer ny bruker.
    /// Har to metoder som logger inn bruker dersom enter knapp trykkes.
    /// </summary>
    public partial class LoginControl : UserControl
    {

        public delegate void loginControlDelegate(object sender, EventArgs e);
        public event loginControlDelegate newUserEvent;
        public event loginControlDelegate loginEvent;

       
        public LoginControl()
        {
            InitializeComponent();           
        }

        private void btnLoginLoginControl_Click(object sender, EventArgs e)
        {
            string givenUsername = tbUserNameLoginControl.Text;
            string givenPassword = tbPasswordLoginControl.Text;
            MainForm.currentUser = Queries.GetUserByUserName(givenUsername);
            


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
                        //MainForm.user_id = user.User_id;
                        //MainForm.userName = user.UserName;
                        MainForm.currentUser = user;
                        loginEvent(sender, e);
                    }
                    else WarningMessages.wrongPassword();
                }
                else WarningMessages.wrongUserName();
            }
            else WarningMessages.generalWarningMessage();
            tbPasswordLoginControl.Clear();
            tbUserNameLoginControl.Clear();
        }
        
        
        private void btnNewUserLoginControl_Click(object sender, EventArgs e)
        {

            newUserEvent(sender, e);
            
        }

        private void tbPasswordLoginControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLoginLoginControl.PerformClick();
            }
        }

        private void tbUserNameLoginControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLoginLoginControl.PerformClick();
            }
        }

    }
}
