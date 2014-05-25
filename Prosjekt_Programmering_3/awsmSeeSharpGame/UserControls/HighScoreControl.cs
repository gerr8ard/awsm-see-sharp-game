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

namespace awsmSeeSharpGame.UserControls
{
    public partial class HighScoreControl : UserControl
    {
        private ListViewItem listViewItem;
        private string[] row;

        public HighScoreControl()
        {
            InitializeComponent();
            lvHighScore.Columns.Add("Nr");
            lvHighScore.Columns.Add("Navn");
            lvHighScore.Columns.Add("Poeng");
            lvHighScore.Columns.Add("Dato");

            List<awsm_Score> highscoreListe = Queries.GetTopTenScores();
            for (int i = 0; i < highscoreListe.Count; i++)
            {
                row = new string[]{
                    i.ToString(),
                    highscoreListe[i].User_id.ToString(),
                    highscoreListe[i].Score.ToString(),
                    highscoreListe[i].Created.ToString()
                };
                listViewItem = new ListViewItem(row);
                lvHighScore.Items.Add(listViewItem);
            }
        }
    }
}
