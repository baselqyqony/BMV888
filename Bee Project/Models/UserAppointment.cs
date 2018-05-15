using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class UserAppointment
    {
        public int ID { set; get; }
        public string UserID { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime startTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime endTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime appointmentDate { get; set; }

        public int AppointmentID { get; set; }

        public Boolean canceled { get; set; }

    }
}