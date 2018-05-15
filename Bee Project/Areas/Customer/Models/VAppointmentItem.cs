using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.Customer.Models
{
    public class VAppointmentItem
    {
        public string day { set; get; }
        [DataType(DataType.Date)]
       public  DateTime appointmentsDate { set; get; }

       public  List<UserAppointment> appointments{set;get;}

       public Service service { set; get; }

    }
}