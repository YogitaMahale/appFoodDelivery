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
using appFoodDelivery.Persistence;
using System.Data.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using System.Data.Entity.Spatial;
using Dapper;
using appFoodDelivery.Models;
using Microsoft.AspNetCore.Identity;
using Nancy.Json;
using System.Text;
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
        private readonly ApplicationDbContext _db;
        private readonly ISP_Call _ISP_Call;
        private readonly UserManager<ApplicationUser> _usermanager;
        public hotelController(ICustomerRegistrationservices _CustomerRegistrationservices, IstoredetailsServices storedetailsServices, IWebHostEnvironment hostingEnvironment, Iproductcuisinemasterservices productcuisinemasterservices, Iproductservices productservices, IordersServices ordersServices, IorderproductServices orderproductServices, IorderhistoryServices orderhistoryServices, ApplicationDbContext db, ISP_Call ISP_Call, UserManager<ApplicationUser> usermanager)
        {
            _storedetailsServices = storedetailsServices;
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
            _ordersServices = ordersServices;
            _orderproductServices = orderproductServices;
            _orderhistoryServices = orderhistoryServices;
            _db = db;
            _ISP_Call = ISP_Call;
            _usermanager = usermanager;
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
        [Route("hotelselectallbyLocation")]
        public async Task<IActionResult> hotelselectallbyLocation(decimal Latitude,decimal Longitude)
        {
            
            var paramter = new DynamicParameters();
            paramter.Add("@Latitude", Latitude);
            paramter.Add("@Longitude", Longitude);
            paramter.Add("@distance", 5);
            //storedetailsListViewmodel
            var storeList =_ISP_Call.List<storedetailsListViewmodel>("getNearestStoredbyLocationNew", paramter);             
            if (storeList != null)
            {
                return Ok(storeList);
                
            }
            else
            {
                return NotFound();
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getCuisineSelectall")]
        public async Task<IActionResult> getCuisineSelectall()
        {
            var customer = _productcuisinemasterservices.GetAll().Where(x => x.isdeleted == false);
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
        public async Task<IActionResult> getProductbyHotelIdandCuisineId(string hotelid, int Cuisineid)
        {
            var customer = _productservices.GetAll().Where(x => x.storeid == hotelid && x.productcuisineid == Cuisineid && x.isdeleted == false);
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
        [Route("getHotelCuisineId")]
        public async Task<IActionResult> getHotelCuisineId(int Cuisineid)
        {
            //var CanadaCustomers = from c in db.Customers.Where(cust => cust.region == "Canada")
            //                      select new { c.custId, c.name };

            // SqlParameter category = new SqlParameter("@CategoryName", "Test");

            //List<storedetails> obj = await _db.Database.ExecuteSqlCommandAsync("NewCategory @CategoryName", category);
            //var parameter = 1;
            //var query = db.Database.SqlQuery<TestProcedure>("TestProcedure @parameter1",
            //               new SqlParameter("@parameter1", parameter)).ToList();
            //return Json(query, JsonRequestBehavior.AllowGet);

            //  var res = from a in _db.product where a.productcuisineid==2 select a;
              var storeidd = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid).Select(x => x.storeid).Distinct().ToList();
            var hotels = _storedetailsServices.GetAll().Where(hotels => storeidd.Contains(hotels.storeid)).ToList();

            //var customer = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid && x.productcuisineid == Cuisineid && x.isdeleted == false).Distinct();
            if (hotels == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hotels);
            }

            //return BadRequest();
        }




        [HttpPost]
        [Route("OrderInsertandOrderProduct")]
        public async Task<IActionResult> OrderInsertandOrderProduct(int customerid, decimal totalamount, string OrderProducts_JSONString,string promocode,string storedid,string discount,string orderstatus,string paymenttype,string paymentstatus,string deliveryaddress,string transactionid, string instruction)
        {
            //var customer = CustomerRegistrationservices.GetById(id);
            if (customerid == 0)
            {
                return NotFound();
            }
            else
            {
                orders objorders = new orders();
                objorders.customerid = customerid;
                objorders.amount = totalamount;
                //objorders.placedate = DateTime.UtcNow;
                objorders.placedate = DateTime.Now;
                objorders.paymentstatus = paymentstatus;
                objorders.orderstatus = orderstatus;
               
                objorders.discount = Convert.ToDecimal(discount);
                objorders.storeid  = storedid;
                objorders.deliveryaddress = deliveryaddress;
                objorders.paymenttype = paymenttype;
                objorders.promocode = promocode;
                objorders.transactionid = transactionid;
                objorders.instructions  = instruction;
                // objorders.propmocode = promocode;


                //                , deliveryboyid, paymentstatus, orderstatus, isdeleted, discount, storeid, 
                //deliveryaddress, paymenttype, promocode

                objorders.storeid = storedid;
                //if (promocode == ""|| storedid=="")
                //{
                //    objorders.discount = 0;
                //}
                //else
                //{
                //    objorders.discount = _storedetailsServices.GetAll().Where(x => x.storeid == storedid&&x.promocode==promocode).FirstOrDefault().discount;
                //}
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

                              

                                //id, oid, placedate, orderstatus
                                //   id, oid, pid, qty, price, isdeleted
                                //[{"productid":"1","productprice":"500","quantites":10},{"productid":"2","productprice":"500","quantites":10}]

                            }
                        }


                        orderhistory objorderhistory = new orderhistory();
                        objorderhistory.oid = OrderId;
                        objorderhistory.placedate = DateTime.UtcNow;
                        objorderhistory.orderstatus = "place Order";
                        await _orderhistoryServices.CreateAsync(objorderhistory);

                        var users = await _usermanager.FindByIdAsync(storedid);
                        string storeDeviceId = users.deviceid;
                        #region "notication"

                        string sResponseFromServer = string.Empty, finalResult = string.Empty;
                        try
                        {
                             
                            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            tRequest.Method = "post";
                            //serverKey - Key from Firebase cloud messaging server   customer
                            //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                            //store
                            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAr0cwgUE:APA91bEs5PB48LpheJuGQOJi8jENylDdtBgGA5tcHFY2Kbz4-FwNLocAN8z7X7c4ADuP6vA7MSE3M6hx5OHp12iFt0yb7zfHO16c7mlgnppsEOFY8J4WRfpOUI-RkbXBLBwMqYwwDyYX"));
                            //Sender Id - From firebase project setting  
                            tRequest.Headers.Add(string.Format("Sender: id={0}", "752813637953"));
                            tRequest.ContentType = "application/json";
                            var payload = new
                            {
                                to = storeDeviceId,
                                priority = "high",
                                content_available = true,
                                notification = new
                                {
                                    body ="New Order No. - " +OrderId+" insert",
                                    title = "New Order",
                                    badge = 1
                                },
                                data = new
                                {
                                    key1 = "value1",
                                    key2 = "value2"
                                }

                            };

                            //string postbody = JsonConvert.SerializeObject(payload).ToString();

                            var serializer = new JavaScriptSerializer();
                            var postbody = serializer.Serialize(payload);
                            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                            tRequest.ContentLength = byteArray.Length;
                            using (Stream dataStream = tRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                                using (WebResponse tResponse = tRequest.GetResponse())
                                {
                                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                    {
                                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                            {
                                                sResponseFromServer = tReader.ReadToEnd();
                                                //result.Response = sResponseFromServer;
                                            }
                                    }
                                }
                            }

                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                       // return Ok(sResponseFromServer);

                        #endregion

                    }
                }
                if(OrderId==0)
                {
                    return BadRequest();
                }
                else
                {
                    var orders = _ordersServices.GetById(OrderId);
                    return Ok(orders);

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

        [HttpGet]
        [Route("getCuisinebyHotelId")]
        public async Task<IActionResult> getCuisinebyHotelId(string hotelid)
        {
            //var storeidd = _productservices.GetAll().Where(x => x.productcuisineid == Cuisineid).Select(x => x.storeid).Distinct().ToList();
            //var hotels = _storedetailsServices.GetAll().Where(hotels => storeidd.Contains(hotels.storeid)).ToList();

            var cusineid = _productservices.GetAll().Where(x => x.storeid==hotelid).Select(x => x.productcuisineid).Distinct().ToList();
            var cusineList = _productcuisinemasterservices.GetAll().Where(hotels => cusineid.Contains(hotels.id)).ToList();
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (cusineList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cusineList);
            }
            //return BadRequest();
        }


     
    }
}
