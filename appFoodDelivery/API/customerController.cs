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

namespace appFoodDelivery.API
{
    [Route("customer")]
    public class customerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICustomerRegistrationservices CustomerRegistrationservices;
        public customerController(ICustomerRegistrationservices _CustomerRegistrationservices, IWebHostEnvironment hostingEnvironment)
        {
            CustomerRegistrationservices = _CustomerRegistrationservices;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {
                CustomerRegistration obj = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {
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
                    string myJson = "{'otpno': "+ no + "}";
                    return Ok(myJson);
                }
                else
                {
                    return BadRequest("Duplicate Mobile No");
                }


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin(string mobileno, string password)
        {
            try
            {
                CustomerRegistration c = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.password == password && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("CustomerInsert")]
        public async Task<IActionResult> CustomerInsert(string name, string email,string mobileno,string password)
        {
            try
            {
                CustomerRegistration c = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {

                    //                 id, name, profilephoto, address, mobileno1, mobileno2, emailid1, latitude, longitude, password, gender, DOB,
                    //createddate, isdeleted, isactive, deviceid
                    CustomerRegistration obj = new CustomerRegistration();

                    //obj.name = name;
                    //obj.profilephoto = "";
                    //obj.address = "";
                    //obj.mobileno1 = mobileno;
                    //obj.mobileno2 = "";
                    //obj.emailid1 = email;
                    //obj.latitude = "";
                    //obj.longitude = "";
                    //obj.password = password;
                    //obj.gender = "";
                    //obj.DOB = DateTime.UtcNow;
                    //obj.createddate = DateTime.UtcNow;
                    //obj.isdeleted = false;
                    //obj.isactive = false;
                    //obj.deviceid = "";
                    obj.name = name;
                    obj.mobileno1 = mobileno;
                    obj.emailid1 = email;
                    obj.password = password;
                    obj.isdeleted = false;
                    obj.isactive = false;
                    obj.gender = "select";
                    obj.createddate = DateTime.UtcNow;

                    int id=  await CustomerRegistrationservices.CreateAsync(obj);
                    CustomerRegistration obj1 = new CustomerRegistration();
                    obj1 =  CustomerRegistrationservices.GetById(id);
                    return Ok(obj1);
                }
                else
                {
                    return BadRequest("duplicate Mobile No");
                }
                 
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpPut]
        [Route("updateCustomerDeviceId")]
        public async Task<IActionResult> updateCustomerDeviceId(string deviceId, int id)
        {
            try
            {


                var customer = CustomerRegistrationservices.GetById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    customer.deviceid = deviceId;
                    await CustomerRegistrationservices.UpdateAsync(customer);

                    return Ok(customer);
                }
                //return BadRequest();
            }
            catch(Exception obj)
            {
                return Ok(obj.Message );
            }
        }

        //[HttpPut]
        //[Route("updateDeviceId")]
        //public async Task<IActionResult> updateDeviceId(string deviceId, int id)
        //{
        //    try
        //    {
        //        var customer = CustomerRegistrationservices.GetById(id);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            customer.deviceid = deviceId;
        //            await CustomerRegistrationservices.UpdateAsync(customer);

        //            if (id < 0)
        //            {
        //                return BadRequest();
        //            }
        //            else
        //            {

        //                return Ok(customer);
        //            }
        //        }
        //    }
        //    catch(Exception obj)
        //    {
        //        return Ok(obj.Message);
        //    }
        //    finally
        //    {

        //    }
           
        //    //return BadRequest();
        //}



    }
}
