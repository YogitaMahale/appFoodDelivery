using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace appFoodDelivery.Models
{
    public class orderselectallViewModel
    { 
        
 //       id, customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, 
 //storeid, deliveryaddress, paymenttype, promocode, transactionid,customerName,mobileno,storename
        public int id { get; set; }
         
        public int customerid { get; set; }

        public string logintype { get; set; }
        public string storeid { get; set; }
        [Display(Name ="Customer Name")]
        
        public string customerName { get; set; }
        public string mobileno { get; set; }
        public string storename { get; set; }

        public decimal amount { get; set; } = 0;
        public string placedate { get; set; }
 
        public int? deliveryboyid { get; set; }

        public string orderstatus { get; set; }
        public string orderstatusPropername { get; set; }
        
        public string promocode { get; set; }

         
        public decimal discount { get; set; } = 0;
        public string deliveryaddress { get; set; }

        public string paymenttype { get; set; }

        public string paymentstatus { get; set; }

        public string transactionid { get; set; }
        public string  storeaddress { get; set; }
        public Boolean isdeleted { get; set; }
        
          public Boolean isactive { get; set; }
        public string deliveryboyname { get; set; }
        public string time { get; set; }
    }
}
