using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class City
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
       
        public int CountryID { get; set; }
    

    }
}