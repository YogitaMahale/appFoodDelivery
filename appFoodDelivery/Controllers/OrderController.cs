using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appFoodDelivery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using appFoodDelivery.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using appFoodDelivery.Services.Implementation;
using Dapper;
using appFoodDelivery.pagination;
using System.Security.Cryptography.Xml;
using System.Net;
using Nancy.Json;
using System.Text;
//using AspNetCore;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISP_Call _ispcall;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IordersServices _ordersServices;
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly ISP_Call _ISP_Call;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IdistanceServices _distanceServices;
        public OrderController(UserManager<ApplicationUser> usermanager, ISP_Call ispcall, IordersServices ordersServices, ICustomerRegistrationservices CustomerRegistrationservices, ISP_Call ISP_Call, IdriverRegistrationServices driverRegistrationServices, IstoredetailsServices storedetailsServices, IdistanceServices distanceServices)
        {
            this._usermanager = usermanager;
            _ISP_Call = ispcall;
            _ispcall = ispcall;
            _ordersServices = ordersServices;
            _CustomerRegistrationservices = CustomerRegistrationservices;
            _driverRegistrationServices = driverRegistrationServices;
            _storedetailsServices = storedetailsServices;
            _distanceServices = distanceServices;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _usermanager.GetUserAsync(HttpContext.User);

        // GET: /<controller>/
        //public async Task<IActionResult> Index(int? PageNumber)
        //{
        //    ApplicationUser usr = await GetCurrentUserAsync();
        //    var user = await _usermanager.FindByIdAsync(usr.Id);
        //    var role = await _usermanager.GetRolesAsync(user);
        //    string roles = role[0].ToString();
        //    var paramter = new DynamicParameters();





        //    //  return 
        //    if (roles == "Admin")
        //    {

        //        var orderList = _ordersServices.GetAll().Where(x => x.isdeleted == false).Select(x => new OrderIndexViewModel
        //        {
        //            id = x.id
        //                 ,
        //            customerid = x.customerid
        //                 ,
        //            amount = x.amount
        //                 ,
        //            placedate = x.placedate
        //                 ,
        //            deliveryboyid = x.deliveryboyid
        //                 ,
        //            paymentstatus = x.paymentstatus
        //                 ,
        //            orderstatus = x.orderstatus
        //                 ,
        //            discount = x.discount
        //                 ,
        //            storeid = x.storeid
        //                 ,
        //            deliveryaddress = x.deliveryaddress
        //                 ,
        //            paymenttype = x.paymenttype
        //                 ,
        //            promocode = x.promocode
        //                 ,
        //            transactionid = x.transactionid
        //                 ,
        //            customername = _CustomerRegistrationservices.GetById(x.customerid).name

        //        }).ToList();
        //        int PageSize = 10;
        //        return View(OrderPagination<OrderIndexViewModel>.Create(orderList, PageNumber ?? 1, PageSize));

        //    }
        //    else if (roles == "Store")
        //    {
        //        var orderList = _ordersServices.GetAll().Where(x => x.storeid == usr.Id && x.isdeleted == false).Select(x => new OrderIndexViewModel
        //        {
        //            id = x.id
        //                     ,
        //            customerid = x.customerid
        //                     ,
        //            amount = x.amount
        //                     ,
        //            placedate = x.placedate
        //                     ,
        //            deliveryboyid = x.deliveryboyid
        //                     ,
        //            paymentstatus = x.paymentstatus
        //                     ,
        //            orderstatus = x.orderstatus
        //                     ,
        //            discount = x.discount
        //                     ,
        //            storeid = x.storeid
        //                     ,
        //            deliveryaddress = x.deliveryaddress
        //                     ,
        //            paymenttype = x.paymenttype
        //                     ,
        //            promocode = x.promocode
        //                     ,
        //            transactionid = x.transactionid
        //                     ,
        //            customername = _CustomerRegistrationservices.GetById(x.customerid).name

        //        }).ToList();
        //        int PageSize = 10;
        //        return View(OrderPagination<OrderIndexViewModel>.Create(orderList, PageNumber ?? 1, PageSize));

        //    }
        //    //var orderlist = _ISP_Call.List<storedetailsListViewmodel>("getNearestStoredbyLocationNew", paramter);
        //    return View();
        //}
        public IActionResult Details(int id)
        {
            var ordervm = new orderinvoice();
            var paramter = new DynamicParameters();
            paramter.Add("@oid", id);
            //  obj.orderheader = _ISP_Call.List<orderselectallViewModel>("orderinvoicebyid", paramter);
            ordervm.orderheader = _ISP_Call.OneRecord<orderselectallViewModel>("orderinvoicebyid", paramter);
            ordervm.orderdetails = _ISP_Call.List<orderselectallDetailsViewModel>("orderinvoice_getProductList", paramter);

            return View(ordervm);
        }
        public async Task<IActionResult> test()
        {
            return View();
        }
        #region API Calls
        public async Task<IActionResult> GetOrderList(string status)
        {

            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();
            IEnumerable<orders> orderheaderList;
            //-------------------------------------------
            orderheaderList = _ordersServices.GetAll();
            if (roles == "Admin")
            {
                var paramter = new DynamicParameters();
                paramter.Add("@storeid", "");
                paramter.Add("@status", status);

                //storedetailsListViewmodel
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
                orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
                //return Json(new { data = orderheaderList });
                return Json(new { data = orderheaderList1 });
            }
            else if (roles == "Store")
            {
                var paramter = new DynamicParameters();
                paramter.Add("@storeid", usr.Id);
                paramter.Add("@status", status);


                //storedetailsListViewmodel
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
                orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
                return Json(new { data = orderheaderList1 });
            }
            //-------------------------------------------
            //if (roles == "admin")
            //{
            //    orderheaderList = _ordersServices.GetAll();

            //}
            //else if (roles == "store")
            //{
            //    orderheaderList = _ordersServices.GetAll().Where(x => x.storeid == usr.Id);
            //}

            //switch (status)
            //{
            //    case "inprocess":
            //        orderheaderList = _ordersServices.GetAll().Where(o => o.orderstatus == "inprocess");
            //        break;
            //    case "pending":
            //        orderheaderList = _ordersServices.GetAll().Where(o => o.orderstatus == "placed");
            //        break;
            //    case "completed":
            //        orderheaderList = _ordersServices.GetAll().Where(o => o.orderstatus == "completed");
            //        break;
            //    case "rejected":
            //        orderheaderList = _ordersServices.GetAll().Where(o => o.orderstatus == "rejected");
            //        break;
            //    default:
            //        orderheaderList = _ordersServices.GetAll();
            //        break;
            //}
            return Json(new { data = orderheaderList });

        }
        #endregion

        public IActionResult changeorderStatus(int id, string status)
        {
            //orders obj = _ordersServices.GetById(id);
            //obj.orderstatus = status;
            //_ordersServices.UpdateAsync(obj);
            var paramter = new DynamicParameters();
            paramter.Add("@id", id);
            paramter.Add("@orderstatus", status);
            //storedetailsListViewmodel
            _ISP_Call.Execute("orderStatus_Update", paramter);
            var orders = _ordersServices.GetById(id);
            int customerid = orders.customerid;
            int deliveryboyid = 0;
            string deliveryboyDeviceId = "";
            string storeid = _ordersServices.GetById(id).storeid;
            var store = _storedetailsServices.GetAll().Where(x => x.storeid == storeid).FirstOrDefault();
            string storeLatitude = store.latitude;
            string storelongitude = store.longitude;
            if (orders.deliveryboyid==null)
            {
                //deliveryboyid = (int)orders.deliveryboyid;
            }
            else
            {
                deliveryboyid = (int)orders.deliveryboyid;
              //  deliveryboyDeviceId = _driverRegistrationServices.GetById(deliveryboyid).deviceid;
            }
           

            string customerDeviceId = _CustomerRegistrationservices.GetById(customerid).deviceid;
             
            if(status== "approved")

            {
                #region "customer"
                
                try
                {
                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server   customer
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //store
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //Sender Id - From firebase project setting  
                    tRequest.Headers.Add(string.Format("Sender: id={0}", "844325225983"));
                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = customerDeviceId,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = "New Order No. - " + id + " Approved by Admin",
                            title = "Order Approved",
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
                #region "Deliveryboy"
               
                    try
                    {
                        var distancedt = _distanceServices.GetById(1);
                        var distance = distancedt.range;

                        var paramter1 = new DynamicParameters();
                        paramter1.Add("@Latitude", storeLatitude);
                        paramter1.Add("@Longitude", storelongitude);
                        paramter1.Add("@distance", distance);
                        var dt = _ISP_Call.List<getNeareDeliveryboybyLocation>("getNeareDeliveryboybyLocationNew", paramter1);

                        foreach (var item in dt)
                        {
                            string deviceid = item.deviceid;
                             
                            if(deviceid.Trim()=="")
                            {

                            }
                            else
                            {
                                string sResponseFromServer = string.Empty, finalResult = string.Empty;
                                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest.Method = "post";
                                //serverKey - Key from Firebase cloud messaging server   customer
                                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                                //store
                                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAHKQA0Wk:APA91bHedRwkl8yVXSbwWC9dQY76Iw-pbxPofgap1wkZX4kAvMvGK826iFlaP6M-27qB9P3UKgwZ1we-B19YmJmbhZCnqULRVGLxfjOumkSo9R-OiQVh5eEN3qc1zo2WRxbFByvdDYO8"));
                                //Sender Id - From firebase project setting  
                                tRequest.Headers.Add(string.Format("Sender: id={0}", "123010601321"));
                                tRequest.ContentType = "application/json";
                                var payload = new
                                {
                                    to = deviceid,
                                    priority = "high",
                                    content_available = true,
                                    notification = new
                                    {
                                        body = "New Order No. - " + id + " Approved by Admin",
                                        title = "Order Approved",
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
                        }

                        

                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                 
               
                // return Ok(sResponseFromServer);

                #endregion
            }
            return RedirectToAction("test");
        }

        //[HttpGet]
        //public IActionResult assigndeliveryboy(int id)
        //{

        //    ViewBag.driverlist = _driverRegistrationServices.GetAlldriver();
        //    //orderassigndeliveryboy
        //    //var paramter = new DynamicParameters();
        //    //paramter.Add("@oid", id);
        //    //assigndeliveryboyModel orderheader = _ISP_Call.OneRecord<assigndeliveryboyModel>("orderinvoicebyid", paramter);

        //    var obj  = _ordersServices.GetById(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    //    var model = new orderassigndeliveryboy
        //    //    {
        //    //        id = obj.id
        //    //        ,
        //    //        deliveryboyid = (int?)obj.deliveryboyid
        //    //        // , profilephoto = objcustomer.profilephoto

        //    //};
        //    orderassigndeliveryboy model = new orderassigndeliveryboy();
        //    model.id = obj.id;
        //    if(obj.deliveryboyid==null)
        //    {
        //        model.deliveryboyid = 0;
        //    }
        //    else
        //    {
        //        model.deliveryboyid = (int)obj.deliveryboyid;
        //    }
        //    return View(model);
        //}
        //[HttpPost]

        //public IActionResult assigndeliveryboy(orderassigndeliveryboy model)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //    else
        //    {

        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult deliveryboyassign(int id)
        {
          
            //   ViewBag.driverlists = _driverRegistrationServices.GetAlldriver().ToList();
            ViewBag.drivers = _driverRegistrationServices.GetAll().ToList();
            var obj = _ordersServices.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            var orders = _ordersServices.GetById(id);

            deliveryboyAssignorderViewModel model = new deliveryboyAssignorderViewModel();
            model.id = obj.id;
            model.customername = _CustomerRegistrationservices.GetById(orders.customerid).name;
            if (obj.deliveryboyid == null)
            {
                //  model.deliveryboyid = 0;
            }
            else
            {
                model.deliveryboyid = (int)obj.deliveryboyid;
            }
            return View(model);
         
            //ViewBag.driverlists = _driverRegistrationServices.GetAlldriver().ToList();
            //deliveryboyAssignorderViewModel model = new deliveryboyAssignorderViewModel();
            //return View(model);
        }
        [HttpPost]
        public IActionResult deliveryboyassignPost(deliveryboyAssignorderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var paramter = new DynamicParameters();
                paramter.Add("@id", model.id);
                paramter.Add("@deliveryboyid", model.deliveryboyid);


                //storedetailsListViewmodel
                _ISP_Call.Execute("orderdeliveryboy_Update", paramter);

                #region "Notification"
                var deliveryboydetails = _driverRegistrationServices.GetById(model.deliveryboyid);
                string deliveryboyName = deliveryboydetails.name;
                string deliveryboyDeviceId = deliveryboydetails.deviceid;


                int customerid = _ordersServices.GetById(model.id).customerid;
                string customerDeviceId = _CustomerRegistrationservices.GetById(customerid).deviceid;

                if (customerDeviceId.Trim() == "")
                {

                }
                else
                {


                    try
                    {
                        string sResponseFromServer = string.Empty, finalResult = string.Empty;
                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        //serverKey - Key from Firebase cloud messaging server   customer
                        //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                        //store
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                        //Sender Id - From firebase project setting  
                        tRequest.Headers.Add(string.Format("Sender: id={0}", "844325225983"));
                        tRequest.ContentType = "application/json";
                        var payload = new
                        {
                            to = customerDeviceId,
                            priority = "high",
                            content_available = true,
                            notification = new
                            {
                                body = "Your Order No. - " + model.id + " assignt to this " + deliveryboyName,
                                title = "Assign Deliveryboy",
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
                }

                if(deliveryboyDeviceId.Trim()=="")
                {

                }
                else
                {
                    
                        
                             
                                string sResponseFromServer = string.Empty, finalResult = string.Empty;
                                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                                tRequest.Method = "post";
                                //serverKey - Key from Firebase cloud messaging server   customer
                                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                                //store
                                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAHKQA0Wk:APA91bHedRwkl8yVXSbwWC9dQY76Iw-pbxPofgap1wkZX4kAvMvGK826iFlaP6M-27qB9P3UKgwZ1we-B19YmJmbhZCnqULRVGLxfjOumkSo9R-OiQVh5eEN3qc1zo2WRxbFByvdDYO8"));
                                //Sender Id - From firebase project setting  
                                tRequest.Headers.Add(string.Format("Sender: id={0}", "123010601321"));
                                tRequest.ContentType = "application/json";
                                var payload = new
                                {
                                    to = deliveryboyDeviceId,
                                    priority = "high",
                                    content_available = true,
                                    notification = new
                                    {
                                        body = "You have assign this Order Id - " + model.id +"by Admin",
                                        title = "Assign Order",
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
                // return Ok(sResponseFromServer);


                #endregion


            }
            return RedirectToAction("test");
        }

         
    }
}
