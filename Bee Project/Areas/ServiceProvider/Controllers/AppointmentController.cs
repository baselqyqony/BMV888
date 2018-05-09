using Bee_Project.Areas.ServiceProvider.Models.VModel;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bee_Project.Areas.ServiceProvider.Controllers
{
    public class AppointmentController : Controller
    {
        //
        private ApplicationDbContext dbContext;
        public AppointmentController() { dbContext = new ApplicationDbContext(); }

        // GET: /ServiceProvider/Appointment/
        [HttpGet]
        public ActionResult CreateAppointment()
        {
            try
            {
                int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                Appointment App = new Appointment();
                App.ServiceID = ServiceID;
                return View(App);
            }
            catch { return Redirect(Url.Content("~/ServiceProvider/Service/ListServices"));}
        }

        [HttpPost]
        public ActionResult CreateAppointment(Appointment App)
        {
            int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            App.ServiceID = ServiceID;
            dbContext.Appointments.Add(App);
            dbContext.SaveChanges();
            return Redirect(Url.Content("~/ServiceProvider/Appointments/ListAppointments/"+App.ServiceID));

        }
       
        public ActionResult ListAppointments()
        {
            try
            {
                int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
                List<Appointment> appointments = dbContext.Appointments.Where(x => x.ServiceID == ServiceID).ToList();
                TempData["ID"] = ServiceID;
                return View(appointments);
            }
            catch (Exception ex) { return Redirect(Url.Content("~/ServiceProvider/Service/ListServices")); }
              
        }
	}
}