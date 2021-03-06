﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Controllers
{
    
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
         [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "service locator service";

            return View();
        }
         [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "+36 999 999 999";

            return View();
        }

         public ActionResult Mainview()
         {
             if (User.Identity.IsAuthenticated)
             {
                 if (User.IsInRole("ServiceProvider"))
                     return RedirectToAction("Profile", "ServiceProvider", new { area = "ServiceProvider" });
                 else
                     if (User.IsInRole("Customer"))
                         return RedirectToAction("Profile", "CustomerProfile", new { area = "Customer" });

             }
             return RedirectToAction("Index");
         }
    }
}