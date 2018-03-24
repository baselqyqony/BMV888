using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class ServiceProvider
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        
        public int AddressID { get; set; }
   
        [StringLength(255)]
      
        public string CompanyName { get; set; }

    }
}