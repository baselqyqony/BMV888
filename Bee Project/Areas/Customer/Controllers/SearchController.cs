using Bee_Project.Areas.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Areas.Customer.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Customer/Search/
        [HttpGet]
        public ActionResult search()
        {

            VSearchModel VSM = new VSearchModel();
            return View(VSM);
        }
	}
}