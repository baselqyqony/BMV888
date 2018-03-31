using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class Service
    {
        [Required]
        public int ID { get; set; }

        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int AdressesID { get; set; }

        [Required]
        public int ServiceTypeID { get; set; }

        [Required]
        public int ServiceProviderID { get; set; }

        [DataType(DataType.MultilineText)]
        public string serviceInfo { get; set; }

        public virtual ICollection<ServiceMetaDatas> ServiceMetaDatas { set; get; }
      

        
    }
}