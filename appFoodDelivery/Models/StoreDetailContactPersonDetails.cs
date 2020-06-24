using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class StoreDetailContactPersonDetails
    {
        public int id { get; set; }

        public string storeid { get; set; }

        [Display(Name = "Contact Person Name")]
        public string contactpersonname { get; set; }
        [Display(Name = "Email Address")]
        public string emailaddress { get; set; }
        [Display(Name = "Contact No")]
        public string contactno { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }


        public Boolean isdeleted { get; set; }
    }
}
