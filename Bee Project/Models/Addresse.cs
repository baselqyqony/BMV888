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

        [Display(Name = "District")]
        public string Ditricit { get; set; }
        
        public string Street { get; set; }

        public string Building { get; set; }

        [Display(Name = "Floor Number")]
        public int Floornumber { get; set; }
        [Display(Name = "Door Number")]
        public int DoorNumber { get; set; }
        [Display(Name = "Postal Code")]
        public string PotalCode { get; set; }
        [Display(Name = "longtude")]
        public string longitude { get; set; }
        [Display(Name = "altitude")]
        public string ultitude { get; set; }
    }
}