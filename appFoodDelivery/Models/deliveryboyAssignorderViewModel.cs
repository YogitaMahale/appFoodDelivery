using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class deliveryboyAssignorderViewModel
    {
        public int id { get; set; }
         
        [Display(Name = "Select Deliveryboy")]
        public int deliveryboyid { get; set; }
         
        public string customername { get; set; }
    }
}
