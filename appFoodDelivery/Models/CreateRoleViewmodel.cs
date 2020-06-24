using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class CreateRoleViewmodel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
