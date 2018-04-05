using Bee_Project.Areas.Customer.Models.VModel;
using Bee_Project.Areas.ServiceProvider.Models.VModel;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Bee_Project.Areas.Customer.Controllers
{
    public class CustomerProfileController : Controller
    {
        // GET: Customer/CustomerProfile
      
        private ApplicationDbContext _context;

        public CustomerProfileController()
        {
            _context = new ApplicationDbContext();
           
        }
      
       VMCustomer userVMB;
       [HttpGet]
       public ActionResult Profile()
       {
           string currentuserid = User.Identity.GetUserId();
           userVMB = new VMCustomer();
           Bee_Project.Models.Customer customerdb = _context.Customers.Where(m => m.UserID == currentuserid).First();
           userVMB.UserName = customerdb.UserName;
           userVMB.Phone = customerdb.PhoneNumber;

           userVMB.Addresses = new AddressesVM();
           userVMB.Addresses.Addresses = new Addresse();
           if (customerdb.AddressesID != 0)
           {
               userVMB.AddressesID = customerdb.AddressesID;
               userVMB.Addresses.Addresses = _context.Addresses.Where(m => m.ID == customerdb.AddressesID).First();
           }
           userVMB.Addresses.Countries = _context.Countrys.ToList();
           userVMB.Addresses.cities = _context.Cities.ToList();
           return View(userVMB);

       }
       [HttpPost]
       public ActionResult Save(VMCustomer uservmmode)
       {

           string currentuserid = User.Identity.GetUserId();
           Bee_Project.Models.Customer Customer = _context.Customers.Where(m => m.UserID == currentuserid).First();
           Customer.UserName = uservmmode.UserName;
           Customer.PhoneNumber = uservmmode.Phone;
           
           if (uservmmode.AddressesID == 0)
           {
               _context.Addresses.Add(uservmmode.Addresses.Addresses);
               _context.SaveChanges();

               uservmmode.AddressesID = uservmmode.Addresses.Addresses.ID;
               Customer.AddressesID = uservmmode.AddressesID;
           }
           Addresse addressesdb = _context.Addresses.Where(m => m.ID == uservmmode.AddressesID).First();
           addressesdb = uservmmode.Addresses.Addresses;

           _context.SaveChanges();

           return RedirectToAction("Profile");


       }


    }
}