﻿using System;
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

    /// <Forfatter>
    /// Pål Skogsrud
    /// </Forfatter>

    /// <summary>
    /// UserControl som setter vanskelighetsgraden på spillet. Gjøres ved hjelp av delegater som MainForm abonnerer på.
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void btn_EasyDifficulty_Click(object sender, EventArgs e)
        {

        }

        private void btn_NormalDifficulty_Click(object sender, EventArgs e)
        {

        }

        private void lbl_HardDifficulty_Click(object sender, EventArgs e)
        {

        }

        private void btn_VeryHardDifficulty_Click(object sender, EventArgs e)
        {

        }
    }
}
