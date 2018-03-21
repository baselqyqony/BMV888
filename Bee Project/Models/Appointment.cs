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
        public DateTime Date { get; set; }


        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public  bool IsAvailable { get; set; }

        public int UserID { get; set; }

        [Required]
        public int ServiceID{ get; set; }


    }
}