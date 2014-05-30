using awsmSeeSharpGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <Forfatter>
/// Pål Skogsrud med hjelp av Dag Ivarsøy
/// </Forfatter>

/// <summary>
/// Database
/// </summary>

namespace awsmSeeSharpGame.Classes
{
    [Table("awsm_Score")]
    public class awsm_Score
    {
        [Key]
        public int Score_id { get; set; }
        public int Score { get; set; }
        public int User_id { get; set; }
        public DateTime Created { get; set; }

        public virtual awsm_Users Users { get; set; }
        
    }
}