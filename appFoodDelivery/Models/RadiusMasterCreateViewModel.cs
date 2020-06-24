using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class RadiusMasterCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Product Cuisine")]
        public string name { get; set; }
        public Boolean isdeleted { get; set; }
        
        public Boolean isactive { get; set; }
    }
}
