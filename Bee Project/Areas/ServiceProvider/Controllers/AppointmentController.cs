using Bee_Project.Areas.ServiceProvider.Models.VModel;
using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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

        [HttpGet]
        public ActionResult EditAppointment()
        {
            int AppointmentID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            Appointment app = dbContext.Appointments.Where(x => x.ID == AppointmentID).First();
            TempData["serviceID"]=app.ServiceID;
            return View(app);
        }

        [HttpPost]
        public ActionResult EditAppointment(Appointment app)
        {
            int serviceID =Int16.Parse(TempData["serviceID"].ToString());

            app.ServiceID = serviceID;
            dbContext.Entry(app).State = EntityState.Modified;
            dbContext.SaveChanges();
            List<UserAppointment> serviceUserAppintments = dbContext.UserAppointment.Where(x => x.AppointmentID == app.ID && x.UserID != null).ToList();

          dbContext.UserAppointment.RemoveRange( dbContext.UserAppointment.Where(x => x.AppointmentID == app.ID).ToList());

            for (var dt = app.StartDate; dt <= app.EndDate; dt = dt.AddDays(1))
            {
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Saturday: if (!app.Sat) continue;
                        break;
                    case DayOfWeek.Sunday: if (!app.Sun) continue;
                        break;
                    case DayOfWeek.Monday: if (!app.Mon) continue;
                        break;
                    case DayOfWeek.Tuesday: if (!app.Tue) continue;
                        break;
                    case DayOfWeek.Wednesday: if (!app.Wed) continue;
                        break;
                    case DayOfWeek.Thursday: if (!app.Thu) continue;
                        break;
                    case DayOfWeek.Friday: if (!app.Fri) continue;
                        break;
                }

                DateTime startTime = app.StartTime;
                DateTime endTime = app.EndTime;

                for (var tm = startTime; tm <= endTime; tm.AddHours(app.Duration))
                {
                    UserAppointment Uapp = new UserAppointment();
                    Uapp.appointmentDate = dt;
                    Uapp.AppointmentID = app.ID;
                    Uapp.startTime = tm;
                    Uapp.endTime = tm.AddHours(app.Duration);
                    Uapp.canceled = false;
                    dbContext.UserAppointment.Add(Uapp);
                    if (serviceUserAppintments != null)
                    {
                        UserAppointment similarTime = serviceUserAppintments.Where(x => x.appointmentDate.Equals(Uapp.appointmentDate) && x.startTime.Equals(Uapp.startTime) && x.endTime.Equals(Uapp.endTime)).First();
                        if(similarTime != null)
                        {
                            Uapp.UserID = similarTime.UserID;
                            serviceUserAppintments.Remove(similarTime);
                        }
                     
                      
                    }
                    dbContext.SaveChanges();
                }
                // canceled for time change 
                foreach (UserAppointment ua in serviceUserAppintments)
                {
                    userAppointmentLog ual = new userAppointmentLog();
                    ual.canceled = true;
                    ual.date = ua.appointmentDate;
                    ual.startTime = ua.startTime;
                    ual.endTime = ua.endTime;
                    ual.ServiceID = app.ServiceID;
                    ual.userID = ua.UserID;
                    ual.duration = app.Duration;
                    dbContext.userAppointmentLog.Add(ual);
                }
                dbContext.SaveChanges();
            }
            return Redirect(Url.Content("~/ServiceProvider/Appointment/ListAppointments/" + app.ServiceID));
        }

        public ActionResult deleteAppointment()
        {
            int appointmentID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            
            Appointment app = dbContext.Appointments.Where(x => x.ID == appointmentID).First();
            int ServiceID = app.ServiceID;

            //cancel users appointments

            List<UserAppointment> serviceUserAppintments = dbContext.UserAppointment.Where(x => x.AppointmentID == app.ID && x.UserID != null).ToList();
            foreach (UserAppointment ua in serviceUserAppintments)
            {
                userAppointmentLog ual = new userAppointmentLog();
                ual.canceled = true;
                ual.date = ua.appointmentDate;
                ual.startTime = ua.startTime;
                ual.endTime = ua.endTime;
                ual.ServiceID = app.ServiceID;
                ual.userID = ua.UserID;
                ual.duration = app.Duration;
                dbContext.userAppointmentLog.Add(ual);
                dbContext.UserAppointment.Remove(ua);
            }
            dbContext.SaveChanges();



            dbContext.Appointments.Remove(app);
            dbContext.SaveChanges();
            return Redirect(Url.Content("~/ServiceProvider/Appointment/ListAppointments/" + ServiceID));

        }

        [HttpPost]
        public ActionResult CreateAppointment(Appointment App)
        {
            int ServiceID = int.Parse(Url.RequestContext.RouteData.Values["id"].ToString());
            App.ServiceID = ServiceID;
            dbContext.Appointments.Add(App);
            dbContext.SaveChanges();

            for (var dt = App.StartDate; dt <= App.EndDate; dt = dt.AddDays(1))
            {
                switch(dt.DayOfWeek) {
                    case DayOfWeek.Saturday: if (!App.Sat) continue;
                        break;
                    case DayOfWeek.Sunday: if (!App.Sun) continue;
                        break;
                    case DayOfWeek.Monday: if (!App.Mon) continue;
                        break;
                    case DayOfWeek.Tuesday: if (!App.Tue) continue;
                        break;
                    case DayOfWeek.Wednesday: if (!App.Wed) continue;
                        break;
                    case DayOfWeek.Thursday: if (!App.Thu) continue;
                        break;
                    case DayOfWeek.Friday: if (!App.Fri) continue;
                        break;
                    }

                DateTime startTime = App.StartTime;
                DateTime endTime = App.EndTime;

                for (var tm = startTime; tm <= endTime; tm.AddHours(App.Duration))
                {
                    UserAppointment UAPP = new UserAppointment();
                    UAPP.appointmentDate = dt;
                    UAPP.AppointmentID = App.ID;
                    UAPP.startTime = tm;
                    UAPP.endTime = tm.AddHours(App.Duration);
                    UAPP.canceled = false;
                    dbContext.UserAppointment.Add(UAPP);
                 
                    dbContext.SaveChanges();
                }
            } 
           
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