﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsmSeeSharpGame.Models
{
    [Table("awsm_Privilege")]
    public class awsm_Privilege
    {
        [Key]
        public int Privilege_id { get; set; }
        public string Privilege { get; set; }

    }
}