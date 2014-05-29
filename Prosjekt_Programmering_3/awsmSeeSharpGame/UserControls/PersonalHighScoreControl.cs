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

    /// <Forfatter>
    /// Pål Skogsrud
    /// </Forfatter>

    /// <summary>
    /// UserControl som viser de ti beste poengsummene til innlogget spiller. Gjøres ved hjelp av delegater som MainForm abonnerer på.
    /// </summary>
    public partial class PersonalHighScoreControl : UserControl
    {

        private ListViewItem listViewItem, listViewItemEmpty, listViewItemEmpty2;
        private string[] row;
        private string userName;

        public PersonalHighScoreControl()
        {
            InitializeComponent();

            if (MainForm.isLoggedIn)
            {
                userName = MainForm.currentUser.UserName;
            }

            lvPersonalHighScore.View = View.Details;

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
            
            lvPersonalHighScore.Columns.Add(column1);
            lvPersonalHighScore.Columns.Add(column2);
            lvPersonalHighScore.Columns.Add(column3);
            lvPersonalHighScore.Columns.Add(column4);

            listViewItemEmpty = new ListViewItem();
            lvPersonalHighScore.Items.Add(listViewItemEmpty);

            List<awsm_Score> highscoreListe = Queries.GetTopTenPersonalScores(userName);

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
                
                lvPersonalHighScore.Items.Add(listViewItem);
                lvPersonalHighScore.Items.Add(listViewItemEmpty2);
            }
           
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }
        
    }
}
