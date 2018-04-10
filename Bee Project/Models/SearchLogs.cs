using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class SearchLogs
    {
        [Required]
        public int ID { set; get; }
        public int selectedServiceType { set; get; }
        public int serviceTypes { set; get; }
        public int selectedCity { set; get; }
        public int selectedCountry { set; get; }
       // public string metaDatas { set; get; }
        public string longitude { set; get; }
        public string altitude { set; get; }
        public bool isNearBy { set; get; }
        public string userID { set; get; }
        public List<SearchMetaDatas> metaDatas { set; get; }
        
    }
}