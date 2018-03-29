using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class ServiceMetaDatas
    {

        [Required]
        public int ID { get; set; }

        [Required]
      
        public int serviceID { set; get; }
        

        [Required]
      
        public int metaDataID { set; get; }
        
    }
}