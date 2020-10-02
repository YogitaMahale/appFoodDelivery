using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class chargesEditViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name ="Customer 1 Km Amount")]
        public decimal customer1Km { get; set; } = 0;
        [Required]
        [Display(Name = "Customer 2 Km Amount")]

        public decimal customer2K { get; set; } = 0;
        [Required]
        [Display(Name = "Delivery Boy 1 Km Amount")]

        public decimal deliveryboy1Km { get; set; } = 0;

        [Required]
        [Display(Name = "Delivery Boy 2 Km Amount")]
        public decimal deliveryboy2Km { get; set; } = 0;
    }
}
