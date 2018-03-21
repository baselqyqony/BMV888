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

       
        [HttpGet]
        
        public ActionResult Profile()
        {
            string currentuserid = User.Identity.GetUserId();
            UserVM userVMB = new UserVM();
           var userfromdb =_context.Users.Where(m => m.Id == currentuserid).First();

           userVMB.UserName = userfromdb.UserName;
           userVMB.Phone = userfromdb.PhoneNumber;
           userVMB.Email = userfromdb.Email;
           userVMB.Countries=_context.Countrys.ToList();
           userVMB.cities = _context.Cities.ToList();
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
            List<City> objcity = new List<City>();
            objcity = _context.Cities.Where(m => m.CountryID == stateid).ToList();
            SelectList obgcity = new SelectList(objcity, "Id", "Name", 0);
            ViewData["FeedBack"] = objcity;
            return Json(obgcity);
        }
    }
}