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
        public string UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public int AddressesID { get; set; }
            
        [Range(0,100)]
        public int Age { get; set; }
    }
}