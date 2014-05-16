using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Classes
{
    [Table("awsm_HighScore")]
    public class awsm_HighScore
    {
        [Key]
        public int HighScore_id { get; set; }
        public DateTime Created { get; set; }

        public virtual List<awsm_Score> Score { get; set; }
    }
}
