using Bee_Project.Models;
using Bee_Project.Areas.ServiceProvider.Models.VModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        public int AddressesID { get; set; }
     
        public AddressesVM Addresses { get; set; }


    }
}