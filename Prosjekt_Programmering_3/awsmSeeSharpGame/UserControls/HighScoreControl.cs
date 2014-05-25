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

namespace awsmSeeSharpGame.UserControls
{
    public partial class HighScoreControl : UserControl
    {
        private ListViewItem listViewItem, listViewItemEmpty, listViewItemEmpty2;
        private string[] row;

        public HighScoreControl()
        {
            InitializeComponent();

            lvHighScore.View = View.Details;

            ColumnHeader column1 = new ColumnHeader();
            ColumnHeader column2 = new ColumnHeader();
            ColumnHeader column3 = new ColumnHeader();
            ColumnHeader column4 = new ColumnHeader();

            column1.Text = "Nr";
            column1.Width = 40;
            column1.TextAlign = HorizontalAlignment.Center;
            column2.Text = "Navn";
            column2.Width = 180;
            column2.TextAlign = HorizontalAlignment.Center;
            column3.Text = "Poeng";
            column3.Width = 80;
            column3.TextAlign = HorizontalAlignment.Center;
            column4.Text = "Dato";
            column4.Width = 150;
            column4.TextAlign = HorizontalAlignment.Right;
            
            lvHighScore.Columns.Add(column1);
            lvHighScore.Columns.Add(column2);
            lvHighScore.Columns.Add(column3);
            lvHighScore.Columns.Add(column4);

            listViewItemEmpty = new ListViewItem();
            lvHighScore.Items.Add(listViewItemEmpty);

            List<awsm_Score> highscoreListe = Queries.GetTopTenScores();

            for (int i = 0; i < highscoreListe.Count; i++)
            {
                row = new string[]{
                    (i+1).ToString(),
                    highscoreListe[i].Users.UserName.ToString(),
                    highscoreListe[i].Score.ToString(),
                    highscoreListe[i].Created.ToString("dd MMMM yyyy")
                };
                
                listViewItem = new ListViewItem(row);
                listViewItemEmpty2 = new ListViewItem();
                listViewItem.ForeColor = Color.White;
                listViewItem.Font = new System.Drawing.Font(new FontFamily("arial"), 16, FontStyle.Regular);
                
                lvHighScore.Items.Add(listViewItem);
                lvHighScore.Items.Add(listViewItemEmpty2);
            }
           
        }
    }
}
