using Bee_Project.Areas.ServiceProvider.Models.VModel;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Bee_Project.Areas.ServiceProvider.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext dbContext;
        //
        // GET: /ServiceProvider/Service/

        public ServiceController() { dbContext = new ApplicationDbContext(); }


        [HttpPost]

        public ActionResult CreateService(VService vservice)
        {

            Service service = new Service();
            Addresse address = new Addresse();
            address.Building = vservice.Building;
            address.CityID = vservice.selectedCities;
            address.CountryID = vservice.selectedCountries;
            address.Ditricit = vservice.Ditrict;
            address.DoorNumber = vservice.DoorNumber;
            address.Floornumber = vservice.DoorNumber;
            address.longitude = vservice.longitude;
            address.PotalCode = vservice.PostalCode;
            address.Street = vservice.Street;
            address.ultitude = vservice.altitude;
            Addresse ads = dbContext.Addresses.Add(address);

            service.AdressesID = ads.ID;
            service.Name = vservice.Name;

            string  userId =User.Identity.GetUserId();
            var serviceProvider = dbContext.ServicesProviders.Where(sp => sp.UserID == userId).First();
            service.ServiceProviderID = serviceProvider.ID;
            service.ServiceTypeID = vservice.selectedServiceTypes;

            var inputService = dbContext.Services.Add(service);

            
            
            //string n = "";
            //foreach (string s in vservice.selectedCities)
            //{
            //    n +=s;
            //}

            return Redirect(Url.Content("~/"));
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            VService Vservice = new VService();

            List<SelectListItem> cts = new List<SelectListItem>();
            foreach (City c in dbContext.Cities.ToList<City>())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = c.Name;
                sli.Value = c.ID.ToString();
                sli.Selected = false;
                cts.Add(sli);
            }
            Vservice.Cities = cts;


            List<SelectListItem> ctrs = new List<SelectListItem>();

            foreach (Country c in dbContext.Countrys.ToList<Country>())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = c.Name;
                sli.Value = c.ID.ToString();
                sli.Selected = false;
                ctrs.Add(sli);
            }

            Vservice.Countries = ctrs;


            List<SelectListItem> serviceTypes = new List<SelectListItem>();

        
            foreach (ServiceType c in dbContext.ServiceTypes.ToList<ServiceType>())
            {
                SelectListItem sli = new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.ID.ToString(),
                    Selected = false
                };
                serviceTypes.Add(sli);
            }

            Vservice.ServiceTypes = serviceTypes;
            return View(Vservice);
        }
	}
}