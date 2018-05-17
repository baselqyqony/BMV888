using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class userAppointmentLog
    {
        public int ID { set; get; }
        public int ServiceID { get; set; }
        public string userID { get; set; }
        public Boolean canceled { get; set; }
        public double duration { get; set; }

       [DataType(DataType.Time)]

        public DateTime startTime { set; get; }
       [DataType(DataType.Time)]

        public DateTime endTime { set; get; }
       [DataType(DataType.Date)]

       public DateTime date { set; get; }
    }
}