using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace awsmSeeSharpGame.Models
{

    /// <summary>
    /// Skrevet av Pål Skogsrud og Dag Ivarsøy
    /// Database
    /// </summary>
    [Table("awsm_Users")]
    public class awsm_Users
    {
        [Key]
        public int User_id { get; set; }
        public int Privilege_id { get; set; }
        public string UserName { get; set; }
        public string SureName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Created { get; set; }

        public virtual awsm_Privilege Privileges { get; set; }
        public virtual List<awsm_Score> Scores { get; set; }


    }
}