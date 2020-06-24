using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class productCreateViewModel
    {
        public int id { get; set; }
        
        public string storeid { get; set; }

        [Display(Name = "Select Cuisine")]
        public int productcuisineid { get; set; }
        
        [Required(ErrorMessage = "Menu Name is Required")]
        [Display(Name = "Menu Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile img { get; set; }
        [Display(Name = "Food Type")]

        public string foodtype { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal amount { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Discount Type")]
        public string discounttype { get; set; }
        [Required]
        [Display(Name = "Discount Amount")]
        public decimal discountamount { get; set; }
        public DateTime createddate { get; set; } = DateTime.UtcNow;

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }

    }
}
