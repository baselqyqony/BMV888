using Bee_Project.Areas.Customer.Models;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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

        [HttpPost]

        public ActionResult search(VSearchModel VSM)
        {
           
            string  userId =User.Identity.GetUserId();
            SearchLogs SL = new SearchLogs();
            SL.altitude = VSM.altitude;
            SL.isNearBy = VSM.isNearBy;
            SL.longitude = VSM.longitude;

            List<string> addedMetaData=VSM.metaDatas.Split(' ').ToList();
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

           return RedirectToAction("ViewSearchResult", VSM);
            
        }

        [HttpGet]
        public ActionResult ViewSearchResult(VSearchModel VSM)
        {
            return View();
        }


	}
}