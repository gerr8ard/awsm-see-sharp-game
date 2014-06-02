using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame.Classes;
using awsmSeeSharpGame.Models;
using System.Collections;

namespace awsmSeeSharpGame.UserControls
{

    /// <summary>
    /// Skrevet av Pål Skogsrud
    /// UserControl som registrerer en ny bruker. Gjøres ved hjelp av delegater som MainForm abonnerer på.
    /// </summary>
    public partial class NewUserControl : UserControl
    {


        public delegate void NewUserControlDelegate(object sender, EventArgs e);
        public delegate void cancelDelegate(object sender, EventArgs e);
        public event cancelDelegate cancelEvent;
        public event cancelDelegate redirectNewUserEvent;


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

            string givenUserName = tbUserNameNewUserControl.Text;
            string givenFirstName = tbFirstNameNewUserControl.Text;
            string givenSureName = tbSureNameNewUserControl.Text;
            string givenPassword = tbPasswordNewUserControl.Text;
            string givenRetypePassword = tbRetypePasswordNewUserControl.Text;

            if (givenUserName != string.Empty && givenFirstName != string.Empty && givenSureName != string.Empty && givenPassword != string.Empty && givenRetypePassword != string.Empty)
            {
                if (givenPassword == givenRetypePassword)
                {
                    Hashtable HashAndSalt = Hash.GetHashAndSalt(givenPassword);
                    string HashUser = (string)HashAndSalt["hash"];
                    string SaltUser = (string)HashAndSalt["salt"];



                    using (var context = new Context())
                    {

                        awsm_Privilege userPrivilege = context.Privilege.FirstOrDefault(privilege => privilege.Privilege == "Bruker");

                        awsm_Users newUser = new awsm_Users()
                            {
                                UserName = givenUserName,
                                SureName = givenSureName,
                                FirstName = givenFirstName,
                                Password = HashUser,
                                Salt = SaltUser,
                                Created = DateTime.Now,
                                Privilege_id = userPrivilege.Privilege_id
                            };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                    }
                }
                else WarningMessages.passwordNotSame();

               

            }
            else WarningMessages.generalWarningMessage();

            tbFirstNameNewUserControl.Clear();
            tbPasswordNewUserControl.Clear();
            tbRetypePasswordNewUserControl.Clear();
            tbSureNameNewUserControl.Clear();
            tbUserNameNewUserControl.Clear();
            redirectNewUserEvent(sender, e);
        }

    }
}
