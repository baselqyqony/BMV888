using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.Customer.Models
{
    public class VSearchModel
    {
        [ScaffoldColumn(false)]
        public int selectedServiceType { set; get; }
        public List<ServiceType> serviceTypes{set;get;}
        [ScaffoldColumn(false)]
        public int selectedCity {set;get;}
        public List<City> cities{set;get;}
        [ScaffoldColumn(false)]
        public int selectedCountry {set;get;}
        public List<Country> countries{set;get;}
        [DataType(DataType.MultilineText)]
        public string metaDatas{set;get;}
        public string longitude { set; get; }
        public string altitude { set; get; }
        public VSearchModel()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
        }
   }
}