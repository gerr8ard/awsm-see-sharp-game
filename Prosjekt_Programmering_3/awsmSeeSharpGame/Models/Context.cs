using awsmSeeSharpGame.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <Forfatter>
/// Pål Skogsrud med hjelp av Dag Ivarsøy
/// </Forfatter>

/// <summary>
/// Database
/// </summary>

namespace awsmSeeSharpGame.Models
{
    public class Context : DbContext
    {

        public DbSet<awsm_Users> Users { get; set; }
        public DbSet<awsm_Privilege> Privilege { get; set; }
        public DbSet<awsm_Score> Score { get; set; }

        public Context()
        {

        }

    }
}