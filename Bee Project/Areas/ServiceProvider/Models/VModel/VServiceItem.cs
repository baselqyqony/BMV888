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

    }
}