using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.API
{
    [Route("deliveryboy")]
    public class deliveryboyController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public readonly IdriverRegistrationServices _driverRegistrationServices;
        public readonly IordersServices _ordersServices;
        public readonly IorderhistoryServices _orderhistoryServices;
        public readonly ISP_Call _ISP_Call;
        public readonly IDeliveryboytoCustomerfeedbackSerivces _DeliveryboytoCustomerfeedbackSerivces;
        public deliveryboyController(IdriverRegistrationServices driverRegistrationServices, IWebHostEnvironment hostingEnvironment, IordersServices ordersServices, ISP_Call ISP_Call, IorderhistoryServices orderhistoryServices, IDeliveryboytoCustomerfeedbackSerivces DeliveryboytoCustomerfeedbackSerivces)
        {
            _driverRegistrationServices = driverRegistrationServices;
            _hostingEnvironment = hostingEnvironment;
            _ordersServices = ordersServices;
            _ISP_Call = ISP_Call;
            _orderhistoryServices = orderhistoryServices;
            _DeliveryboytoCustomerfeedbackSerivces = DeliveryboytoCustomerfeedbackSerivces;
        }
        [HttpGet]
        [Route("deliveryboyLogin")]
        public async Task<IActionResult> deliveryboyLogin(string mobileno, string password)
        {
            try
            {
                driverRegistration c = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.password == password && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    string myJson = "{'message': " + "Record Not Found" + "}";
                    return Ok(myJson);
                    // return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("deliveryboyInsert")]
        public async Task<IActionResult> deliveryboyInsert(string name, string gender, string email, string mobileno, string password)
        {
            try
            {
                driverRegistration c = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {

                    driverRegistration obj = new driverRegistration();

                    obj.name = name;
                    obj.mobileno = mobileno;
                    obj.emailid = email;
                    obj.password = password;
                    obj.isdeleted = false;
                    obj.isactive = false;
                    obj.gender = gender;
                    obj.createddate = DateTime.UtcNow;

                    int id = await _driverRegistrationServices.CreateAsync(obj);
                    driverRegistration obj1 = new driverRegistration();
                    obj1 = _driverRegistrationServices.GetById(id);
                    return Ok(obj1);
                }
                else
                {
                    string myJson = "{'message': " + "duplicate Mobile No" + "}";
                    return Ok(myJson);
                    // return BadRequest("duplicate Mobile No");
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {
                //driverRegistration obj = _driverRegistrationServices.GetAll().Where(x => x.mobileno == mobileno && x.isdeleted == false).FirstOrDefault();
                ////  var categories = await _context.CustomerRegistration.ToListAsync(); 
                //if (obj == null)
                //{
                String no = null;
                Random random = new Random();
                for (int i = 0; i < 1; i++)
                {
                    int n = random.Next(0, 999);
                    no += n.ToString("D4") + "";
                }
                #region "sms"
                try
                {

                    string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";

                    string OPTINS = "STRLIT";

                    string type = "3";
                    string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "ezacus@2020" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                    //    Response.Write("Sent");
                }

                catch
                { }
                #endregion
                string myJson = "{'otpno': " + no + "}";
                return Ok(myJson);
                //}
                //else
                //{
                //    return BadRequest("Duplicate Mobile No");
                //}


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }


        [HttpPut]
        [Route("updateVehicleDocument")]
        public async Task<IActionResult> updateVehicleDocument(string biketype, string manufacturename, int id, string modelname, string modelyear, string vehicleplateno, string drivinglicphoto, string vehicleinsurancephoto)
        {
            try
            {


                var deliveryboy = _driverRegistrationServices.GetById(id);
                if (deliveryboy == null)
                {
                    string myJson = "{'message': " + "Not Found" + "}";
                    return NotFound(myJson);
                    // return NotFound();
                }
                else
                {
                    deliveryboy.biketype = biketype;
                    deliveryboy.manufacturename = manufacturename;
                    deliveryboy.modelname = biketype;
                    deliveryboy.modelyear = manufacturename;
                    deliveryboy.vehicleplateno = vehicleplateno;
                    if (drivinglicphoto != null || drivinglicphoto != string.Empty)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\driver\drivingLicence";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(drivinglicphoto));
                        deliveryboy.drivinglicphoto = "/uploads/driver/drivingLicence/" + fileName;

                    }
                    if (vehicleinsurancephoto != null || vehicleinsurancephoto != string.Empty)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\driver\vehicleinsurancephoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(vehicleinsurancephoto));
                        deliveryboy.vehicleinsurancephoto = "/uploads/driver/vehicleinsurancephoto/" + fileName;

                    }
                    await _driverRegistrationServices.UpdateAsync(deliveryboy);

                    return Ok(deliveryboy);
                }
                //return BadRequest();
            }
            catch (Exception obj)
            {
                return Ok(obj.Message);
            }
        }

        [HttpPut]
        [Route("DeliveryboyEditProfile")]
        public async Task<IActionResult> DeliveryboyEditProfile(int id, string name, string gender, string email)
        {
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return Ok(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                user.name = name;
                user.gender = gender;
                //  user.mobileno = mobileno;
                user.emailid = email;
                await _driverRegistrationServices.UpdateAsync(user);
                return Ok(user);
            }

        }
        [HttpPut]
        [Route("changepassword")]
        public async Task<IActionResult> changepassword(int id, string newpassword)
        {
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                user.password = newpassword;
                await _driverRegistrationServices.UpdateAsync(user);
                string myJson = "{'message': " + "Password Updated Successfully" + "}";
                return Ok(myJson);
            }

        }

        [HttpPut]
        [Route("acceptOrder")]
        public async Task<IActionResult> acceptOrder(int orderid, int deliveryboyid)
        {
            orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                obj.deliveryboyid = deliveryboyid;
                await _ordersServices.UpdateAsync(obj);

                var driverdetails = _driverRegistrationServices.GetById(deliveryboyid);
                orderhistory objorderhistory = new orderhistory();
                objorderhistory.oid = orderid;
                objorderhistory.placedate = DateTime.UtcNow;
                objorderhistory.orderstatus = driverdetails.name + " accept order. OrderID  :" + orderid;
                await _orderhistoryServices.CreateAsync(objorderhistory);

                string myJson = "{'message': " + "Order Accept Successfully" + "}";
                return NotFound(myJson);
            }

        }
        [HttpGet]
        [Route("selectallPendingOrder")]
        public async Task<IActionResult> selectallPendingOrder()
        {
            //var paramter = new DynamicParameters();
            //paramter.Add("@storeid", storedid);
            //paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllPending", null);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound();
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("deliveryboyorderCount")]
        public async Task<IActionResult> deliveryboyorderCount(int deliveryboyid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@deliveryboyid", deliveryboyid);
            //  paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<storeCountModel>("SP_deliveryboyorderCount", paramter);
            //  orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }
        [HttpGet]
        [Route("getProductdetailsbyOrderid")]
        public async Task<IActionResult> getProductdetailsbyOrderid(int orderid)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@oid", orderid);
            //  paramter.Add("@status", "Placed");
            var orderheaderList1 = _ISP_Call.List<orderselectallDetailsViewModel>("orderinvoice_getProductList", paramter);
            //  orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //var cusineList = _productcuisinemasterservices.GetAll().Where(cusineList => cusineid.Contains(cusineid.p)).ToList();

            if (orderheaderList1 == null)
            {
                string myJson = "{'message': " + "Record Not Found" + "}";
                return NotFound(myJson);
            }
            else
            {
                return Ok(orderheaderList1);
            }
            //return BadRequest();
        }

        [HttpPut]
        [Route("deliveryboyReachtoHotel")]
        public async Task<IActionResult> deliveryboyReachtoHotel(int orderid, int deliveryboyid)
        {
            // orders obj = _ordersServices.GetById(orderid);// await _usermanager.GetUserAsync(User); 
            //if (obj == null)
            //{
            //    string myJson = "{'message': " + "Record Not Found" + "}";
            //    return NotFound(myJson);
            //}
            //else
            //{
            if (orderid.ToString() == "" || deliveryboyid.ToString() == "")
            {
                string myJson = "{'message': " + "Please sent inputparameter values" + "}";
                return NotFound(myJson);

            }
            else
            {
                var driverdetails = _driverRegistrationServices.GetById(deliveryboyid);

                orderhistory objorderhistory = new orderhistory();
                objorderhistory.oid = orderid;
                objorderhistory.placedate = DateTime.UtcNow;
                objorderhistory.orderstatus = driverdetails.name + " reach to Hotel for accepting  order id :" + orderid;
                await _orderhistoryServices.CreateAsync(objorderhistory);
                string myJson = "{'message': " + "Status updated Successfully" + "}";
                return Ok(myJson);

            }
           


            //}

        }
        [HttpPut]
        [Route("changeorderStatus")]
        public async Task<IActionResult> changeorderStatus(int orderid, string status)
        {
            var paramter = new DynamicParameters();
            paramter.Add("@id", orderid);
            paramter.Add("@orderstatus", status);            
            _ISP_Call.Execute("orderStatus_Update", paramter);

            //---------------
            
            orderhistory objorderhistory = new orderhistory();
            objorderhistory.oid = orderid;
            objorderhistory.placedate = DateTime.UtcNow;
            objorderhistory.orderstatus = "Order No :" + orderid + ","+status+" status updated Successfully";
            await _orderhistoryServices.CreateAsync(objorderhistory);
            //---
            string myJson = "{\"Message\": " + "\"Order Status Updated Successfully\"" + "}";
            return Ok(myJson);
            

        }

        [HttpPut]
        [Route("deliveryboyupdatedeviceid")]
        public async Task<IActionResult> deliveryboyupdatedeviceid(int id, string deviceid)
        {
            string myJson = "";
            driverRegistration user = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (user == null)
            {
                  myJson = "{'message': " + "Not Found" + "}";
                return NotFound(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                user.deviceid = deviceid;
                 
                await _driverRegistrationServices.UpdateAsync(user);
                return Ok(user);
            }

        }

        [HttpPost]
        [Route("insertCustomerFeedback")]
        public async Task<IActionResult> insertCustomerFeedback(int deliveryboyid, int customerid, string comment, string rating)
        {
             
            DeliveryboytoCustomerfeedback obj = new DeliveryboytoCustomerfeedback();
            obj.id = 0;
            obj.deliveryboyid = deliveryboyid;
            obj.customerid  = customerid;
          
            obj.comment = comment;
            obj.rating = rating;
            obj.isdeleted = false;
            obj.isactive = false;
            int id = await _DeliveryboytoCustomerfeedbackSerivces.CreateAsync(obj);
            if (id == null)
            {
                string myJson = "{\"Message\": " + "\"NotFound\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                string myJson = "{\"Message\": " + "\"Feedback Insert Successfully\"" + "}";
                return Ok(myJson);

            }
            //return BadRequest();
        }


        [HttpPut]
        [Route("insertbankdetails")]
        public async Task<IActionResult> insertbankdetails(int id, string  accountno, string banklocation, string bankname, string ifsccode)
        {
            driverRegistration obj = _driverRegistrationServices.GetById(id);// await _usermanager.GetUserAsync(User); 
            if (obj == null)
            {
                string myJson = "{'message': " + "Not Found" + "}";
                return Ok(myJson);
                // return NotFound("Not Found");
            }
            else
            {
                obj.accountno = accountno;
                obj.banklocation = banklocation;
                obj.bankname = bankname;
                obj.ifsccode = ifsccode;

                //  user.mobileno = mobileno;
                 
                await _driverRegistrationServices.UpdateAsync(obj);
                return Ok(obj);
            }

        }
    }
}
