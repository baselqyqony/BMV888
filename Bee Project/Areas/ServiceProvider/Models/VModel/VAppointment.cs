using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.ServiceProvider.Models.VModel
{
    public class VAppointment
    {
      
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsBooked { get; set; }

        [Required]
        public bool IsCancelled { get; set; }

        [Required]
        public bool IsPostponed { get; set; }

        public int UserID { get; set; }


        public int ServiceID { get; set; }

        public double Duration { get; set; }

        public Boolean Sat { get; set; }
        public Boolean Sun { get; set; }
        public Boolean Mon { get; set; }
        public Boolean Tue { get; set; }
        public Boolean Wed { get; set; }
        public Boolean Thu { get; set; }
        public Boolean Fri { get; set; }
        
    }
}