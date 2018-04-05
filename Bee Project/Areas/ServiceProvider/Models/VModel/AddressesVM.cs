using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.ServiceProvider.Models.VModel
{
    public class AddressesVM
    {


        public Addresse Addresses { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> cities { get; set; }
    }
}