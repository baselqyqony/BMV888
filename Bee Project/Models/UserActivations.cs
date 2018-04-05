using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bee_Project.Models
{
    public class UserActivations
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public Guid ActivationCode { get; set; }
    }
}