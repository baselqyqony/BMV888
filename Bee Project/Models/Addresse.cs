using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class Addresse
    {
        [Required]
        public int ID { get; set; }
        [Display(Name = "Country")]
        [Required]
        public int CountryID { get; set; }
       
        [Display(Name="City")]
        [Required]
        public int CityID { get; set; }
    

        public string Ditricit { get; set; }

        public string Street { get; set; }

        public string Building { get; set; }

        public int Floornumber { get; set; }

        public int DoorNumber { get; set; }

        public string PotalCode { get; set; }
        public string longitude { get; set; }
        public string ultitude { get; set; }
    }
}