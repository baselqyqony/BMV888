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
    public class VSearchResult

    {
        public VSearchResult(Service service,City city ,Country country,string type,List<MetaData> metaDatas,string Distance  ) {
            this.ID = service.ID;
            this.name = service.Name;
            this.selectedCity = city.Name;
            this.selectedCountry = country.Name;
            this.ServiceType = type;
            List<string> sMetaData = metaDatas.Select(x => x.Name).ToList();
            this.metaDatas = string.Join(",", sMetaData);
            if (this.description == null)
                this.description = "";
            else
            this.description = service.serviceInfo;
            this.distance = distance;
        }
        [ScaffoldColumn(false)]
        public int ID { set; get; }
        [DisplayName("Name")]
        public string name{set;get;}
        [DisplayName("Service Type")]
        public string ServiceType { set; get; }
        [DisplayName("City")]
        public string selectedCity { set; get; }
        [DisplayName("Country")]
        public string selectedCountry { set; get; }
        [DataType(DataType.MultilineText)]
        [DisplayName("tags")]
        public string metaDatas { set; get; }
        [DisplayName("Description")]
        public string description { set; get; }
        public string distance { set; get; }

        
      
    }
}