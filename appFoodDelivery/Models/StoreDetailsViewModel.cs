using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace appFoodDelivery.Models
{
    public class StoreDetailsViewModel
    {
        public int id { get; set; }
        [Display(Name ="Store Name")]
        public string storename { get; set; }
        [Display(Name = "Delivery Radius")]
        public int radiusid { get; set; }

        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select State")]
        public int stateid { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        [Required]
        [Display(Name = "Select City")]
        public int cityid { get; set; }


        [Display(Name = "Estimated Delivery Time")]
        public int deliverytimeid { get; set; }
        [Display(Name = "Order Minimum Amount")]
        public decimal orderMinAmount { get; set; }


        [Display(Name = "Packaging Charges")]
        public decimal packagingCharges { get; set; }
        [Display(Name = "Banner Photo")]
        public IFormFile storeBannerPhoto { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Store Time")]
        public string storetime { get; set; }

       
        public Boolean isdeleted { get; set; }


    }
}
