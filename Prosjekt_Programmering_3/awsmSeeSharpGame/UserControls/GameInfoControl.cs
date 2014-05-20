using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using awsmSeeSharpGame;

namespace awsmSeeSharpGame.UserControls
{
    public partial class GameInfoControl : UserControl
    {

        public GameInfoControl()
        {
            InitializeComponent();


        }

        public void GameInfoControl_Load()
        {
            lbl_name.Text = MainForm.currentUser.UserName;
            lbl_levelValue.Text = MainForm.currentGameInfo.level.ToString();
            lbl_livesValue.Text = MainForm.currentGameInfo.lives.ToString();
            lbl_PointsValue.Text = MainForm.currentGameInfo.score.ToString();
            lbl_personalHighScore.Text = MainForm.currentGameInfo.personalHighScore.ToString();
        }

    }
}
