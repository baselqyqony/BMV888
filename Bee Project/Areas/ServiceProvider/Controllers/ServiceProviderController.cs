using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Areas.ServiceProvider.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider/ServiceProvider
        public ActionResult Profile()
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

    }
}