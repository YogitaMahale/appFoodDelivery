using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace appFoodDelivery.Models
{
    public class DriverEditViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Photo")]
        public IFormFile profilephoto { get; set; }
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno { get; set; }
        [Display(Name = "Email ID")]
        public string emailid { get; set; }

        [Display(Name = "Password")]

        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Display(Name = "Gender")]
        public string gender { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string deviceid { get; set; }
        public DateTime createddate { get; set; }

        public string biketype { get; set; }
        public string manufacturename { get; set; }
        public string modelname { get; set; }
        public string modelyear { get; set; }
        public string vehicleplateno { get; set; }
        public IFormFile drivinglicphoto { get; set; }
        public IFormFile vehicleinsurancephoto { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }


    }
}
