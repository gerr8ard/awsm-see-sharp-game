using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace awsmSeeSharpGame.Models
{

    /// <summary>
    /// Skrevet av Pål Skogsrud og Dag Ivarsøy
    /// Database
    /// </summary>
    public class Context : DbContext
    {

        public DbSet<awsm_Users> Users { get; set; }
        public DbSet<awsm_Privilege> Privilege { get; set; }
        public DbSet<awsm_Score> Score { get; set; }

        /*
        public Context()
            : base("name=awsmSeeSharpGame.Properties.Settings.awsmSeeSharpGame_Models_ContextConnectionString")
        {

        }        
        */
    }
}
