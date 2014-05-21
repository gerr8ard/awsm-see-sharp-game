using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace awsmSeeSharpGame.Classes
{
    public static class WarningMessages
    {

        public static void wrongUserName()
        {
            MessageBox.Show("Du har tastet feil brukernavn", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void wrongPassword()
        {
            MessageBox.Show("Du har tastet feil passord", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void generalWarningMessage()
        {
            MessageBox.Show("Du har tastet noe feil", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void noAccessWarning()
        {
            MessageBox.Show("Du må logge inn for tilgang til hovedmeny.", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void passwordNotSame()
        {
            MessageBox.Show("Passordene er ikke like.", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
