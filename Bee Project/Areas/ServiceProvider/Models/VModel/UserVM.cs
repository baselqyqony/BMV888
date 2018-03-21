using Bee_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.ServiceProvider.Models.VMModel
{
    public class UserVM
    {

        [Required]
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

       [Required]
        public int CountryID { get; set; }

        [Required]
        [Display( Name ="City")]
        public int CityID { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        public int Floornumber { get; set; }

        public int DoorNumber { get; set; }
        public int PostalCode { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> cities { get; set; }

    }
}