﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class ServiceType
    {
        [Required]
        public int ID { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


    }
}