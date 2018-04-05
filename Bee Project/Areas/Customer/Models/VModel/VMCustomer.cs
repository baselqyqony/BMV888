using Bee_Project.Areas.ServiceProvider.Models.VModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bee_Project.Areas.Customer.Models.VModel
{
    public class VMCustomer
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

        public int AddressesID { get; set; }

        public AddressesVM Addresses { get; set; }

    }
}