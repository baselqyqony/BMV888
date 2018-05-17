using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Areas.Customer.Models
{
    public class VSearchModel
    {
        public int ID { set; get; }
        [ScaffoldColumn(false)]
        public int selectedServiceType { set; get; }
        public List<SelectListItem> ServiceTypes { set; get; }
        [ScaffoldColumn(false)]
        public int selectedCity {set;get;}
        public List<SelectListItem> Cities { set; get; }
        [ScaffoldColumn(false)]
        public int selectedCountry {set;get;}
        public List<SelectListItem> Countries { set; get; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Search")]
        [Required]
        public string metaDatas{set;get;}
         [DisplayName("longitude")]
        public string longitude { set; get; }
          [DisplayName("latitude")]
        public string altitude { set; get; }
        public bool isNearBy { set; get; }
       
   }
}