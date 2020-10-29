﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Models
{
    public class getOrderStatusInfo
    {

        //    id, customerid, amount
        //, convert(nvarchar(100),placedate,103)as placedate
        //, deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, storeid, deliveryaddress,
        // paymenttype, promocode, transactionid
        public int id { get; set; }

        public int customerid { get; set; }
        public decimal amount { get; set; } = 0;
        public string placedate { get; set; }
        public int? deliveryboyid { get; set; }

        public string paymentstatus { get; set; }

        public string orderstatus { get; set; }
        public string orderstatusPropername { get; set; }

        public Boolean isdeleted { get; set; }
        public decimal discount { get; set; } = 0;
        public string storeid { get; set; }

        public string deliveryaddress { get; set; }
        public string paymenttype { get; set; }
        public string promocode { get; set; }
        public string transactionid { get; set; }





        public string customerName { get; set; }
        public string mobileno { get; set; }
        public string storename { get; set; }
        public string deliveryboyname { get; set; }
        public string deliveryboylatitude { get; set; }
        public string deliveryboylongitude { get; set; }
        public string deliveryboymobileno { get; set; }
        public string deliveryboyprofilephoto { get; set; }
        public string storelatitude { get; set; }

        public string storelongitude { get; set; }

    }
}
