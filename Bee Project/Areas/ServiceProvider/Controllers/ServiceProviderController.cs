using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bee_Project.Areas.ServiceProvider.Models.VMModel;
using Bee_Project.Models;
using Microsoft.AspNet.Identity;

namespace Bee_Project.Areas.ServiceProvider.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider/ServiceProvider

        private ApplicationDbContext _context;

        public ServiceProviderController()
        {
            _context = new ApplicationDbContext();
        }

        UserVM userVMB;
        [HttpGet]
        public ActionResult Profile()
        {
            List<SelectListItem> Batch = new List<SelectListItem>
             {
                    new SelectListItem {Text = "0", Value = "39"},
             };
            ViewBag.Batch = Batch;
            string currentuserid = User.Identity.GetUserId();
            userVMB = new UserVM();
           var userfromdb =_context.Users.Where(m => m.Id == currentuserid).First();

           userVMB.UserName = userfromdb.UserName;
           userVMB.Phone = userfromdb.PhoneNumber;
           userVMB.Email = userfromdb.Email;
           userVMB.Countries=_context.Countrys.ToList();
           if (userVMB.CountryID == null || userVMB.CountryID==0)
                userVMB.cities = _context.Cities.Where(m => m.CountryID == 0).ToList();
           else
               userVMB.cities = _context.Cities.Where(m => m.CountryID == userVMB.CountryID).ToList();
            return View(userVMB);
            
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult ServiceDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetCityByStaeId(int stateid)
        {

          List<City>  cities = _context.Cities.Where(m => m.CountryID == stateid).ToList();
          return Json(cities.AsEnumerable(), JsonRequestBehavior.AllowGet);
            
        }
    }
}