using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using appFoodDelivery.Entity;
//using appFoodDelivery.Models.Dtos;
using appFoodDelivery.Services;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Data;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.API
{
    [Route("hotel")]
    public class hotelController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Iproductservices _productservices;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IordersServices _ordersServices;
        private readonly IorderproductServices _orderproductServices;
        private readonly IorderhistoryServices _orderhistoryServices;

        public hotelController(ICustomerRegistrationservices _CustomerRegistrationservices, IstoredetailsServices storedetailsServices, IWebHostEnvironment hostingEnvironment, Iproductcuisinemasterservices productcuisinemasterservices, Iproductservices productservices, IordersServices ordersServices, IorderproductServices orderproductServices, IorderhistoryServices orderhistoryServices)
        {
            _storedetailsServices = storedetailsServices;
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
            _ordersServices = ordersServices;
            _orderproductServices = orderproductServices;
            _orderhistoryServices = orderhistoryServices;
        }
        [HttpGet]
        [Route("hotelselectall")]
        public async Task<IActionResult> hotelselectall()
        {
            var customer = _storedetailsServices.GetAll();
            if (customer == null)
            {
                return NotFound();
            }
            else
            {    
                    return Ok(customer);                 
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getCuisinebyHotelId")]
        public async Task<IActionResult> getCuisinebyHotelId(string hotelid)
        {
            var customer = _productcuisinemasterservices.GetAll().Where(x=>x.storeid==hotelid&&x.isdeleted==false);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getProductbyHotelIdandCuisineId")]
        public async Task<IActionResult> getProductbyHotelIdandCuisineId(string hotelid,int Cuisineid)
        {
            var customer = _productservices.GetAll().Where(x => x.storeid == hotelid&& x.productcuisineid==Cuisineid && x.isdeleted == false);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
            //return BadRequest();
        }






        [HttpPost]
        [Route("OrderInsertandOrderProduct")]
        public async Task<IActionResult> OrderInsertandOrderProduct(int customerid, decimal totalamount, string OrderProducts_JSONString)
        {
            //var customer = CustomerRegistrationservices.GetById(id);
            if (customerid== 0)
            {
                return NotFound();
            }
            else
            {
                orders objorders = new orders();
                objorders.customerid = customerid;
                objorders.amount = totalamount;
                objorders.placedate = DateTime.UtcNow;
                objorders.paymentstatus = "";
                objorders.orderstatus = "place Order";
               
                int OrderProductAdd = 0;
                int OrderId = 0;
                var dtOrderProducts = JsonConvert.DeserializeObject<DataTable>(OrderProducts_JSONString);
                if (dtOrderProducts != null)
                {
                    if (dtOrderProducts.Rows.Count > 0)
                    {
                        OrderId = await _ordersServices.CreateAsync(objorders);
                        if (OrderId > 0)
                        {
                            for (int i = 0; i < dtOrderProducts.Rows.Count; i++)
                            {
                                orderproducts objorderproduct = new orderproducts();
                                objorderproduct.oid = OrderId;
                                objorderproduct.pid = Convert.ToInt32(dtOrderProducts.Rows[i]["productid"]);
                                objorderproduct.qty = Convert.ToInt64(dtOrderProducts.Rows[i]["quantites"]);
                                objorderproduct.price = Convert.ToInt64(dtOrderProducts.Rows[i]["productprice"]);
                                objorderproduct.isdeleted = false;
                                await _orderproductServices.CreateAsync(objorderproduct);

                                orderhistory objorderhistory = new orderhistory();
                                objorderhistory.oid = OrderId;
                                objorderhistory.placedate = DateTime.UtcNow;
                                objorderhistory.orderstatus = "place Order";
                                await _orderhistoryServices.CreateAsync(objorderhistory);
                                //id, oid, placedate, orderstatus
                                //   id, oid, pid, qty, price, isdeleted
                                //[{"productid":"783","productprice":"500","quantites":10}]

                            }
                        }
                    }
                }
                // customerid, amount, placedate, deliveryboyid, paymentstatus, orderstatus, isdeleted, isactive
                //customer.deviceid = deviceId;
                //await CustomerRegistrationservices.UpdateAsync(customer);

                //if (id < 0)
                //{
                //    return BadRequest();
                //}
                //else
                //{

                //    return Ok(customer);
                //}
            }
            return BadRequest();
        }
    }
}
