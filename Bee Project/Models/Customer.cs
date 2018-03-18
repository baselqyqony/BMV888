using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class Customer
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [Range(10,100)]
        public int Age { get; set; }
    }
}