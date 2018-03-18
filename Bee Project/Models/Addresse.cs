using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class Addresse
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int CountryID { get; set; }

       [Required]
        public int CityID { get; set; }


        public string Ditricit { get; set; }

        public string Street { get; set; }

        public int Floornumber { get; set; }

        public int DoorNumber { get; set; }
    }
}