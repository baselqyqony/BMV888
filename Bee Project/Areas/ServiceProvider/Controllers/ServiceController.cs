using Bee_Project.Areas.ServiceProvider.Models.VModel;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Bee_Project.Areas.ServiceProvider.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext dbContext;
        //
        // GET: /ServiceProvider/Service/

        public ServiceController() { dbContext = new ApplicationDbContext(); }

        public ActionResult ListServices()
        {
            string userId = User.Identity.GetUserId();
            var serviceProvider = dbContext.ServicesProviders.Where(sp => sp.UserID == userId).First();

            List<Service> services = dbContext.Services.Where(x=>x.ServiceProviderID == serviceProvider.ID).ToList<Service>();
            List<VServiceItem> vServices = new List<VServiceItem>();
            foreach (Service s in services)
            {
                VServiceItem vs = new VServiceItem();
                Addresse a = dbContext.Addresses.Where(x => x.ID == s.AdressesID).First();
                ServiceType ST = dbContext.ServiceTypes.Where(x => x.ID == s.ServiceTypeID).First();
                vs.ID = s.ID;
                vs.serviceName = s.Name;
                vs.ServiceType = ST.Name;
                List<int> serviceMetaDataIDS= s.ServiceMetaDatas.Select(x=>x.metaDataID).ToList<int>();
                List<string> serviceMetaDatas = dbContext.MetaData.Where(x=> serviceMetaDataIDS.Contains(x.ID)).Select(y=>y.Name).ToList<string>();

                vs.serviceMetaData = string.Join(",", serviceMetaDatas.ToArray());
                vServices.Add(vs);


            }

            return View(vServices); 
        }
        [HttpPost]

        public ActionResult CreateService(VService vservice)
        {
            //create address
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


            //CreateActionInvoker service 
            dbContext.SaveChanges();
           

            service.AdressesID = ads.ID;
            service.Name = vservice.Name;

            string  userId =User.Identity.GetUserId();
            var serviceProvider = dbContext.ServicesProviders.Where(sp => sp.UserID == userId).First();
            service.ServiceProviderID = serviceProvider.ID;
            service.ServiceTypeID = vservice.selectedServiceTypes;
            service.serviceInfo = vservice.serviceInfo;
            var inputService = dbContext.Services.Add(service);

            //add service metadata
            string [] metaDatas = vservice.serviceMetaData.ToUpper().Split(',');
            List<string> uniqueMetaDatas = metaDatas.Distinct().ToList<string>();
            List<MetaData> metadatas = dbContext.MetaData.ToList<MetaData>();
            List<string> names = metadatas.Select(x => x.Name).ToList<string>();
           
            
            if (metaDatas != null)
            {
                if (metaDatas.Length > 0)
                {
                    foreach (string s in metaDatas)
                    {
                        if (!names.Contains(s))
                        {
                            MetaData md = new MetaData();
                            md.Name = s;
                            dbContext.MetaData.Add(md);
                        }
                    }

                    dbContext.SaveChanges();
                    List<MetaData> filteredMetaData= dbContext.MetaData.Where(m=> uniqueMetaDatas.Contains(m.Name)).ToList<MetaData>();
                    List<int> metaDataIDS = filteredMetaData.Select(m => m.ID).ToList<int>();

                    foreach (int i in metaDataIDS)
                    {
                        ServiceMetaDatas SMD =new ServiceMetaDatas();
                        SMD.metaDataID=i;
                        SMD.serviceID=service.ID;
                        dbContext.ServiceMetaDatas.Add(SMD);
                    }

                    dbContext.SaveChanges();
                    
                } 
            }

                
            dbContext.SaveChanges();
            
            
            //string n = "";
            //foreach (string s in vservice.selectedCities)
            //{
            //    n +=s;
            //}

            return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));
        }

        public ActionResult deleteService()
        {
            int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            Service svc = dbContext.Services.Where(x=>x.ID==ServiceID).First();
            dbContext.Services.Remove(svc);
            dbContext.SaveChanges();
            return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));

        }

         [HttpPost]
        public ActionResult editService(VService vservice)
        {

            Service service = dbContext.Services.Where(x => x.ID == vservice.ID).First();
            Addresse address = dbContext.Addresses.Where(x => x.ID == service.AdressesID).First();
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
            dbContext.Entry(address).State = EntityState.Modified;
           // Addresse ads = dbContext.Addresses.Add(address);


            //CreateActionInvoker service 
            dbContext.SaveChanges();


          //  service.AdressesID = ads.ID;
            service.Name = vservice.Name;

           // string userId = User.Identity.GetUserId();
          //  var serviceProvider = dbContext.ServicesProviders.Where(sp => sp.UserID == userId).First();
           // service.ServiceProviderID = serviceProvider.ID;
            service.ServiceTypeID = vservice.selectedServiceTypes;
            service.serviceInfo = vservice.serviceInfo;
            dbContext.Entry(service).State = EntityState.Modified;
            dbContext.SaveChanges();
            //var inputService = dbContext.Services.Add(service);

            //add service metadata
            string[] metaDatas = vservice.serviceMetaData.ToUpper().Split(',');
            List<string> uniqueMetaDatas = metaDatas.Distinct().ToList<string>();
            List<MetaData> metadatas = dbContext.MetaData.ToList<MetaData>();
            List<string> names = metadatas.Select(x => x.Name).ToList<string>();


            if (metaDatas != null)
            {
                if (metaDatas.Length > 0)
                {
                    foreach (string s in metaDatas)
                    {
                        if (!names.Contains(s))
                        {
                            MetaData md = new MetaData();
                            md.Name = s;
                            dbContext.MetaData.Add(md);
                        }
                    }

                    dbContext.SaveChanges();
                    List<MetaData> filteredMetaData = dbContext.MetaData.Where(m => uniqueMetaDatas.Contains(m.Name)).ToList<MetaData>();
                    List<int> metaDataIDS = filteredMetaData.Select(m => m.ID).ToList<int>();

                    foreach (int i in metaDataIDS)
                    {
                        ServiceMetaDatas SMD = new ServiceMetaDatas();
                        SMD.metaDataID = i;
                        SMD.serviceID = service.ID;
                        ServiceMetaDatas existedMD = null;
                        try
                        {
                            dbContext.ServiceMetaDatas.Where(x => (x.metaDataID == i) && (x.serviceID == service.ID)).First();
                        }
                        catch (Exception ex) { existedMD = null; }
                        if (existedMD == null)
                        dbContext.ServiceMetaDatas.Add(SMD);
                    }

                    foreach (ServiceMetaDatas  smd in dbContext.ServiceMetaDatas)
                    {
                        if ((smd.serviceID == service.ID) && (!metaDataIDS.Contains(smd.metaDataID)))
                        {
                            dbContext.ServiceMetaDatas.Remove(smd);
                        }
                    }

                    dbContext.SaveChanges();

                }
            }


            dbContext.SaveChanges();
            

            //string n = "";
            //foreach (string s in vservice.selectedCities)
            //{
            //    n +=s;
            //}

            return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));
        }

        [HttpGet]
        public ActionResult editService()
        {
            try
            {
                int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                Service svc = dbContext.Services.Where(x => x.ID == ServiceID).First();

                Addresse adress = dbContext.Addresses.Where(x => x.ID == svc.AdressesID).First();
                ServiceType ST = dbContext.ServiceTypes.Where(x => x.ID == svc.ServiceTypeID).First();
                City cty = dbContext.Cities.Where(x => x.ID == adress.CityID).First();
                Country ctry = dbContext.Countrys.Where(x => x.ID == adress.CountryID).First();

                VService Vservice = new VService();

                List<SelectListItem> cts = new List<SelectListItem>();
                foreach (City c in dbContext.Cities.ToList<City>())
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Text = c.Name;
                    sli.Value = c.ID.ToString();
                    if (c.ID == adress.CityID)
                        sli.Selected = true;
                    else
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
                    if (c.ID == adress.CountryID)
                        sli.Selected = true;
                    else
                        sli.Selected = false;
                    ctrs.Add(sli);
                }

                Vservice.Countries = ctrs;


                List<SelectListItem> serviceTypes = new List<SelectListItem>();


                foreach (ServiceType c in dbContext.ServiceTypes.ToList<ServiceType>())
                {
                    Boolean selected = false;
                    if (c.ID == svc.ServiceTypeID)
                    {
                        selected = true;
                    }
                    else

                        selected = false;

                    SelectListItem sli = new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.ID.ToString(),

                        Selected = selected
                    };
                    serviceTypes.Add(sli);
                }

                Vservice.ID = svc.ID;
                Vservice.ServiceTypes = serviceTypes;
                Vservice.altitude = adress.ultitude;
                Vservice.longitude = adress.longitude;
                Vservice.Building = adress.Building;
                Vservice.Ditrict = adress.Ditricit;
                Vservice.DoorNumber = adress.DoorNumber;
                Vservice.FloorNumber = adress.Floornumber;
                Vservice.Name = svc.Name;
                Vservice.PostalCode = adress.PotalCode;
                Vservice.serviceInfo = svc.serviceInfo;
                Vservice.Street = adress.Street;
                //List<string> serviceMetaDatas = dbContext.MetaData.Where(x => serviceMetaDataIDS.Contains(x.ID)).Select(y => y.Name).ToList<string>();
                List<int> serviceMetaDataIDS = svc.ServiceMetaDatas.Select(x => x.metaDataID).ToList<int>();
                List<string> serviceMetaDatas = dbContext.MetaData.Where(x => serviceMetaDataIDS.Contains(x.ID)).Select(y => y.Name).ToList<string>();

                Vservice.serviceMetaData = string.Join(",", serviceMetaDatas.ToArray());
                Vservice.selectedCities = adress.CityID;
                Vservice.selectedCountries = adress.CountryID;
                Vservice.selectedServiceTypes = svc.ServiceTypeID;

                return View(Vservice);
            }
            catch(Exception ex){return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));}

        }

        public ActionResult ServiceDetail()
        {
            try
            {
                int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                Service s = dbContext.Services.Where(x => x.ID == ServiceID).First();
                VServiceItem vs = new VServiceItem();
                Addresse a = dbContext.Addresses.Where(x => x.ID == s.AdressesID).First();
                ServiceType ST = dbContext.ServiceTypes.Where(x => x.ID == s.ServiceTypeID).First();
                vs.ID = s.ID;
                vs.serviceName = s.Name;
                vs.ServiceType = ST.Name;
                List<int> serviceMetaDataIDS = s.ServiceMetaDatas.Select(x => x.metaDataID).ToList<int>();
                List<string> serviceMetaDatas = dbContext.MetaData.Where(x => serviceMetaDataIDS.Contains(x.ID)).Select(y => y.Name).ToList<string>();

                vs.serviceMetaData = string.Join(",", serviceMetaDatas.ToArray());
                vs.serviceCity = dbContext.Cities.Where(x => x.ID == a.CityID).First().Name;
                vs.serviceCountry = dbContext.Countrys.Where(x => x.ID == a.CountryID).First().Name;
                vs.serviceDetails = s.serviceInfo;
                return View(vs);
            }
            catch(Exception ex){return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));}

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