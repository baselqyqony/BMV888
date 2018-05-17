using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.ServiceProvider.Models
{
    public class ServiceAppointmentItem
    {
        public Bee_Project.Models.Customer user { set; get; }
        public string name{set;get;}
        public string phone { set; get; }
        public string email { set; get; }
         [DataType(DataType.Date)]
        public DateTime date{set;get;}

        public UserAppointment UAppointment { set; get; }

    }
}