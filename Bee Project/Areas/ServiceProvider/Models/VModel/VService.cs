using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Areas.ServiceProvider.Models.VModel
{
    public class VService
    {
        
        public int ID { set; get; }
        public string Name { set; get; }
        
        
        public string Ditrict { set; get; }
        public string Street { set; get; }
        public int FloorNumber { set; get; }
        public int DoorNumber { set; get; }
        public string Building { set; get; }
        public string PostalCode { set; get; }
        public string longitude { set; get; }
        public string altitude { set; get; }
 
        


        //additional

        public List<SelectListItem> ServiceTypes { set; get; }
        public IEnumerable<SelectListItem> Cities { set; get; }
        public int selectedCities { set; get; }
        public int selectedCountries { set; get; }
        public int  selectedServiceTypes { set; get; }
        public List<SelectListItem> Countries { set; get; }

        [DataType(DataType.MultilineText)]
        public string serviceInfo { get; set; }

        [DataType(DataType.MultilineText)]
        public string serviceMetaData { get; set; }
    }
}