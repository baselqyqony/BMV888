using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.ServiceProvider.Models.VModel
{
    public class VServiceItem
    {
        public int ID { get; set; }
        public string serviceName { set; get; }
        public string ServiceType { set; get; }
        public string serviceMetaData { set; get; }
        public string serviceCity { get; set; }
        public string serviceCountry { get; set; }
     

        public string serviceDetails { get; set; }

        public string Appointments { get; set; }

        


    }
}