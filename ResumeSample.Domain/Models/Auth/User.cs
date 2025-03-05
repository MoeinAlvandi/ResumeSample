﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.Domain.Models.Auth
{
   public class User
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(50)]
        public string Fullname { get; set; }


        [MaxLength(50)] 
        public string Password { get; set; }

    }
}
