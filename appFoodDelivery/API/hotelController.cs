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
        public hotelController(ICustomerRegistrationservices _CustomerRegistrationservices, IstoredetailsServices storedetailsServices, IWebHostEnvironment hostingEnvironment, Iproductcuisinemasterservices productcuisinemasterservices, Iproductservices productservices)
        {
            _storedetailsServices = storedetailsServices;
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
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
    }
}
