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
            
            string currentuserid = User.Identity.GetUserId();
            userVMB = new UserVM();
            Bee_Project.Models.ServiceProvider userfromdb = _context.ServicesProviders.Where(m => m.UserID == currentuserid).First();
           userVMB.UserName = userfromdb.UserName;
           userVMB.Phone = userfromdb.PhoneNumber;
           userVMB.CompanyName = userfromdb.CompanyName;
           userVMB.Addresses = new Models.VModel.AddressesVM();
           userVMB.Addresses.Addresses = new Addresse();
           if (userfromdb.AddressesID!=0)
           {
               userVMB.AddressesID = userfromdb.AddressesID;
               userVMB.Addresses.Addresses = _context.Addresses.Where(m => m.ID == userfromdb.AddressesID).First();
           }
           userVMB.Addresses.Countries = _context.Countrys.ToList();
           userVMB.Addresses.cities = _context.Cities.ToList();
            return View(userVMB);
            
        }
        [HttpPost]
        public ActionResult Save(UserVM uservmmode)
        {
         
             string currentuserid = User.Identity.GetUserId();
              Bee_Project.Models.ServiceProvider serviceprovider = _context.ServicesProviders.Where(m => m.UserID == currentuserid).First();
              serviceprovider.UserName = uservmmode.UserName;
              serviceprovider.PhoneNumber = uservmmode.Phone;
              serviceprovider.CompanyName = uservmmode.CompanyName;
              if (uservmmode.AddressesID==0)
              { 
              _context.Addresses.Add(uservmmode.Addresses.Addresses);
              _context.SaveChanges();

              uservmmode.AddressesID=uservmmode.Addresses.Addresses.ID;
              serviceprovider.AddressesID = uservmmode.AddressesID;
              }
              Addresse addressesdb = _context.Addresses.Where(m => m.ID == uservmmode.AddressesID).First();
              addressesdb = uservmmode.Addresses.Addresses;

              _context.SaveChanges();

              return RedirectToAction("Profile");
            

        }
        public ActionResult CompanyProfile()
        {

            return View();
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
          List< City>Cities = _context.Cities.Where(m => m.CountryID == stateid).ToList();

          SelectList obgcity = new SelectList(Cities, "Id", "CityName", 0);
          return Json(obgcity);
        }
    }


}