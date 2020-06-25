using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace appFoodDelivery.Entity
{
   public  class orders
    {
        public int id { get; set; }
        [ForeignKey("CustomerRegistration")]
        public int customerid { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }
        public DateTime placedate { get; set; }
         
        [ForeignKey("driverRegistration")]
        public int? deliveryboyid { get; set; }
        public string paymentstatus { get; set; }
        public string orderstatus { get; set; }
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
       //[DefaultValue("false")]
      //  public Boolean isactive { get; set; }

    }
}
