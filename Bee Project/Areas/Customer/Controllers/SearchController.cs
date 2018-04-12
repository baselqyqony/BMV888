using Bee_Project.Areas.Customer.Models;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
	}
}