using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.Customer.Models
{
    public class VUserAppointment
    {
        public string userID {set;get;}
        public UserAppointment UAppointment { set; get; }
        public Service AppointmentService { set; get; }
    }
}