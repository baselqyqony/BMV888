using Bee_Project.Areas.Customer.Models;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Device.Location;
using Bee_Project.Areas.ServiceProvider.Models.VModel;
namespace Bee_Project.Areas.Customer.Controllers
{
    

   
    public class SearchController : Controller
    {

        private ApplicationDbContext dbContext;

        public SearchController() { dbContext = new ApplicationDbContext(); }

        
        //
        // GET: /Customer/Search/
        [HttpGet]
        public ActionResult search()
        {

            VSearchModel VSM = new VSearchModel();
            List<VSearchResult> VSR = new List<VSearchResult>();
            List<SelectListItem> cts = new List<SelectListItem>();
            foreach (City c in dbContext.Cities.ToList<City>())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = c.Name;
                sli.Value = c.ID.ToString();
                sli.Selected = false;
                cts.Add(sli);
            }
            VSM.Cities= cts;


            List<SelectListItem> ctrs = new List<SelectListItem>();

            foreach (Country c in dbContext.Countrys.ToList<Country>())
            {
                SelectListItem sli = new SelectListItem();
                sli.Text = c.Name;
                sli.Value = c.ID.ToString();
                sli.Selected = false;
                ctrs.Add(sli);
            }

            VSM.Countries = ctrs;


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

            VSM.ServiceTypes = serviceTypes;
            return View(VSM);
        }

        public ActionResult BookAppointment()
        {

            return View();
        }

        public ActionResult details()
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

            ViewBag.Altitude = a.ultitude;
            ViewBag.longtude = a.longitude;

            List<Appointment> appontments = new List<Appointment>();
            appontments = dbContext.Appointments.Where(x => x.ServiceID == ServiceID).ToList();
            vs.appointments = appontments;
         
            
            return View(vs);
        }
        
        [HttpPost]

        public ActionResult search(VSearchModel VSM)
        {
           
            string  userId =User.Identity.GetUserId();
            SearchLogs SL = new SearchLogs();
            SL.altitude = VSM.altitude;
            SL.isNearBy = VSM.isNearBy;
            SL.longitude = VSM.longitude;
            List<string> addedMetaData=new List<string>();

            if(null!=VSM.metaDatas)
            addedMetaData=VSM.metaDatas.Split(' ').ToList();
            List<MetaData> MD = dbContext.MetaData.Where(x => addedMetaData.Contains(x.Name.ToUpper())).ToList();
            SL.selectedCity = VSM.selectedCity;
            SL.selectedCountry = VSM.selectedCountry;
            SL.serviceTypes = VSM.selectedServiceType;
            SL.userID = userId;
           SearchLogs savedSL=  dbContext.SearchLogs.Add(SL);
           dbContext.SaveChanges();

           foreach (MetaData M in MD)
           {
               SearchMetaDatas s = new SearchMetaDatas();
               s.MetaDataID = M.ID;
               s.SearchLogsID = savedSL.ID;
               dbContext.SearchMetaDatas.Add(s);
               dbContext.SaveChanges();
           }

           VSM.ID = savedSL.ID;
           TempData["VSM"] = VSM;
           
           return RedirectToAction("ViewSearchResult");
            
        }

        [HttpGet]
        public ActionResult ViewSearchResult()
        {
            try
            {
                List<Service> results = new List<Service>();
                //data
                List<Service> services = new List<Service>();
                List<Addresse> addresses = new List<Addresse>();
                List<Country> countries = dbContext.Countrys.ToList();
                List<City> cities = dbContext.Cities.ToList();
                List<ServiceType> types = dbContext.ServiceTypes.ToList();
                List<List<MetaData>> serviceMetaDatas = new List<List<MetaData>>();

                List<int> goalServices = new List<int>();
                VSearchModel VSM = (VSearchModel)TempData["VSM"];

                dbContext = new ApplicationDbContext();
                //filling data
                List<Service> allServices = dbContext.Services.ToList();
                List<VSearchResult> allsearchResults = new List<VSearchResult>();
                List<VSearchResult> goalSearchResults = new List<VSearchResult>();
                foreach (Service ss in allServices)
                {
                    Service s = dbContext.Services.Where(x => x.ID == ss.ID).First();
                    services.Add(s);
                    List<int> SmetaDataIDS = s.ServiceMetaDatas.Select(x => x.metaDataID).ToList();
                    Addresse a = dbContext.Addresses.Where(x => x.ID == s.AdressesID).First();
                    addresses.Add(a);
                    List<MetaData> sMetaMatas = new List<MetaData>();
                    sMetaMatas = dbContext.MetaData.Where(x => SmetaDataIDS.Contains(x.ID)).ToList();
                    serviceMetaDatas.Add(sMetaMatas);
                    City c = dbContext.Cities.Where(x => x.ID == a.CityID).First();
                    cities.Add(c);
                    Country country = dbContext.Countrys.Where(x => x.ID == a.CountryID).First();
                    ServiceType st = dbContext.ServiceTypes.Where(x => x.ID == s.ServiceTypeID).First();
                    types.Add(st);
                    allsearchResults.Add(new VSearchResult(s, c, country, st.Name, sMetaMatas, ""));


                }



                if (VSM.isNearBy)
                {
                    for (int i = 0; i < services.Count; i++)
                    {
                        GeoCoordinate serviceLocation = new GeoCoordinate(Double.Parse(addresses[i].ultitude), Double.Parse(addresses[i].longitude));
                        GeoCoordinate userLocation = new GeoCoordinate(Double.Parse(VSM.altitude), Double.Parse(VSM.longitude));
                        Double Distance = serviceLocation.GetDistanceTo(userLocation);
                        allsearchResults[i].distance = Distance + "";
                        if (Distance <= 50000)
                        {
                            goalServices.Add(i);
                        }

                    }
                }
                else
                {

                    for (int i = 0; i < services.Count; i++)
                    {
                        GeoCoordinate serviceLocation = new GeoCoordinate(Double.Parse(addresses[i].ultitude), Double.Parse(addresses[i].longitude));
                        GeoCoordinate userLocation = new GeoCoordinate(Double.Parse(VSM.altitude), Double.Parse(VSM.longitude));
                        Double Distance = serviceLocation.GetDistanceTo(userLocation);
                        allsearchResults[i].distance = Distance + "";
                        goalServices.Add(i);
                    }
                }


                //apply other factors on search 
                List<int> tempGoalServices = new List<int>();
                for (int i = 0; i < goalServices.Count; i++)
                {

                    Boolean filterResult = false;
                    //check city 
                    if (VSM.selectedCity != -1)
                    {

                        if (cities[goalServices[i]].ID == VSM.selectedCity)
                        {
                            filterResult = filterResult || true;
                            results.Add(services[goalServices[i]]);
                            goalSearchResults.Add(allsearchResults[goalServices[i]]);
                            continue;
                        }
                        else
                        {
                            filterResult = filterResult || false;

                        }

                    }
                    //check countries
                    if (VSM.selectedCountry != -1)
                    {

                        if (countries[goalServices[i]].ID == VSM.selectedCountry)
                        {
                            filterResult = filterResult || true;
                            results.Add(services[goalServices[i]]);
                            goalSearchResults.Add(allsearchResults[goalServices[i]]);
                            continue;
                        }
                        else
                        {
                            filterResult = filterResult || false;

                        }

                    }
                    // check service type
                    if (VSM.selectedServiceType != -1)
                    {

                        if (types[goalServices[i]].ID == VSM.selectedServiceType)
                        {
                            filterResult = filterResult || true;
                            results.Add(services[goalServices[i]]);
                            goalSearchResults.Add(allsearchResults[goalServices[i]]);
                            continue;
                        }
                        else
                        {
                            filterResult = filterResult || false;

                        }

                    }

                    //check service  metaData 



                    if (VSM.metaDatas != null)
                    {
                        string[] searchMetaData = VSM.metaDatas.Split(' ');

                        foreach (string s in searchMetaData)
                        {
                            foreach (MetaData md in serviceMetaDatas[goalServices[i]])
                            {
                                if (md.Name.ToUpper().Contains(s.ToUpper()) || s.ToUpper().Contains(md.Name.ToUpper()))
                                {
                                    filterResult = filterResult || true;
                                    results.Add(services[goalServices[i]]);
                                    goalSearchResults.Add(allsearchResults[goalServices[i]]);
                                    continue;
                                }

                            }



                        }
                    }
                    if (filterResult || VSM.isNearBy)
                    {
                        results.Add(services[goalServices[i]]);
                        goalSearchResults.Add(allsearchResults[goalServices[i]]);
                    }
                }





                return View(goalSearchResults);
            }
            catch (Exception ex) {  return Redirect(Url.Content("~/Customer/Search/search")); }

            }



               
        }


	}

