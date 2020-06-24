using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class DeliveryTimeCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Estimated Delivery Time")]
        public string name { get; set; }
        public Boolean isdeleted { get; set; }
 
        public Boolean isactive { get; set; }
    }
}
