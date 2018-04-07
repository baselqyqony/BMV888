using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class Appointment
    {
        [Required]
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

        [Required]
        public int ServiceID { get; set; }


    }
}