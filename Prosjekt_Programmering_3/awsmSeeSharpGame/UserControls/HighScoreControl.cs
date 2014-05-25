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
        public HighScoreControl()
        {
            InitializeComponent();
            
            //var topScores = Queries.GetTopTenScores();

            using (var context = new Context())
            {
                var topScoreList = context.Score
                                    .Include("Users")
                                    .OrderByDescending(S => S.Score)
                                    .Take(10)
                                    .ToList();
                
            
            
            dgvHighScore.DataSource = topScoreList;
            }

            
           
        }
    }
}
