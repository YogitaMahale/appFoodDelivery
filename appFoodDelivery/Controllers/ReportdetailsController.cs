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
using appFoodDelivery.Notification;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class ReportdetailsController : Controller
    {
        // GET: /<controller>/
        private readonly ISP_Call _ispcall;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IordersServices _ordersServices;
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        private readonly ISP_Call _ISP_Call;
        private readonly IdriverRegistrationServices _driverRegistrationServices;
        private readonly IstoredetailsServices _storedetailsServices;
        private readonly IdistanceServices _distanceServices;
        public fcmNotification objfcmNotification = new fcmNotification();
        public ReportdetailsController(UserManager<ApplicationUser> usermanager, ISP_Call ispcall, IordersServices ordersServices, ICustomerRegistrationservices CustomerRegistrationservices, ISP_Call ISP_Call, IdriverRegistrationServices driverRegistrationServices, IstoredetailsServices storedetailsServices, IdistanceServices distanceServices)
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
        /*
        public async Task<IActionResult> Index()
        {
            
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();


            string s1 = DateTime.Now.ToShortDateString().ToString();

            var paramter = new DynamicParameters();
            if (roles == "Admin")
            {
                paramter.Add("@storeid", "");
            }
            else
            {
                paramter.Add("@storeid", usr.Id);
            }
            string s = DateTime.Today.ToString("dd/MM/yyyy");
            paramter.Add("@status", "Placed");
            paramter.Add("@from", DateTime.Today.ToString("dd/MM/yyyy"));
            paramter.Add("@to", DateTime.Today.ToString("dd/MM/yyyy"));            
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));


            // int PageSize = 10;
           return View(orderheaderList1.ToList());
            //int PageSize = 100;
            //return View(OrderPagination<orderselectallViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime from,DateTime to,string status,string  search,string ExcelFileDownload)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();

            if (search != null)
            {
                ViewBag.message="From Date  : "+ from.ToShortDateString().ToString() + " - To Date : " + to.ToShortDateString().ToString();
                //string ss = status + "," + from.ToShortDateString().ToString() + "," + to.ToShortDateString().ToString();
                string ss = status + "," + from.ToString("dd/MM/yyyy") + "," + to.ToString("dd/MM/yyyy");
                 
                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }
                paramter.Add("@status", status);
                paramter.Add("@from", from.ToString("dd/MM/yyyy"));
                paramter.Add("@to", to.ToString("dd/MM/yyyy"));
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);
            //   orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));


            // int PageSize = 10;
             return View(orderheaderList1.ToList());
                //int PageSize = 10;
                //return View(OrderPagination<orderselectallViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {
               
                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }
                paramter.Add("@status", status);
                paramter.Add("@from", from.ToString("dd/MM/yyyy"));
                paramter.Add("@to", to.ToString("dd/MM/yyyy"));
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);
                
                var builder = new StringBuilder();
                builder.AppendLine("Order ID,Store Name,CustomerName,Amount,Date");
                foreach (var item  in orderheaderList1)
                {
                    builder.AppendLine($"{item.id},{item.storeid},{item.customerName},{item.amount},{item.placedate}");
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Report.csv");
            }


            else
            {
                return View();
            }



        }

        */


        [HttpGet]
        public async Task<IActionResult> Index(int? PageNumber, string from1, string to1,string status)
        {

            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();


            string s1 = DateTime.Now.ToShortDateString().ToString();

            var paramter = new DynamicParameters();
            if (roles == "Admin")
            {
                paramter.Add("@storeid", "");
            }
            else
            {
                paramter.Add("@storeid", usr.Id);
            }
            paramter.Add("@status", status);

            paramter.Add("@from", from1);
            paramter.Add("@to", to1);

            

            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);
            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<orderselectallViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> Index(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload)
        {
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();

            if (search != null)
            {

                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);

                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);
                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(OrderPagination<orderselectallViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                 
                var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAllSearch", paramter);



                var builder = new StringBuilder();
                builder.AppendLine("Order ID,Store Name,CustomerName,Amount,Date");
                foreach (var item in orderheaderList1)
                {
                    builder.AppendLine($"{item.id},{item.storeid},{item.customerName},{item.amount},{item.placedate}");
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Report.csv");
            }


            else
            {
                return View();
            }



        }


        //--------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> orderHistoryReport(int? PageNumber, string from1, string to1, string status)
        {

            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();


            string s1 = DateTime.Now.ToShortDateString().ToString();

            var paramter = new DynamicParameters();
            if (roles == "Admin")
            {
                paramter.Add("@storeid", "");
            }
            else
            {
                paramter.Add("@storeid", usr.Id);
            }
            paramter.Add("@status", status);
          
            paramter.Add("@from", from1);
            paramter.Add("@to", to1);
            
            var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);
           
            
            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<orderHistoryReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }
         
        [HttpPost]
        public async Task<IActionResult> orderHistoryReport(int? PageNumber,string from1, string to1, string status, string search, string ExcelFileDownload)
        {
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();

            if (search != null)
            {
               
                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }              

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1 , "dd/MM/yyyy", CultureInfo.InvariantCulture);
             
                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
               
                var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);
               
                //  return View(orderheaderList1.ToList());
                int PageSize = 10;
              
                return View(OrderPagination<orderHistoryReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);


                

                var builder = new StringBuilder();
                builder.AppendLine("Order ID,Store ,Customer,Fianl Amount,Customer Amount,Customer Delivery Charges,Delivery boy Charges,Order Status,Deliveryboy ,Date");
                foreach (var item in orderheaderList1)
                {
                    builder.AppendLine($"{item.id},{item.storename},{item.customerName},{item.finalamt },{item.customeramt},{item.customerdeliverycharges},{item.deliveryboycharges},{item.orderstatus },{item.deliveryboyName},{item.placedate }");
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "OrderHistory.csv");
            }


            else
            {
                return View();
            }


   
        }

        //---------------------------
        [HttpGet]
        public async Task<IActionResult> HotelEarningReport(int? PageNumber, string from1, string to1, string status)
        {

            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();


            string s1 = DateTime.Now.ToShortDateString().ToString();

            var paramter = new DynamicParameters();
            if (roles == "Admin")
            {
                paramter.Add("@storeid", "");
            }
            else
            {
                paramter.Add("@storeid", usr.Id);
            }
            paramter.Add("@status", status);

            paramter.Add("@from", from1);
            paramter.Add("@to", to1);

            var orderheaderList1 = _ISP_Call.List<HotelEarningViewModel>("HotelEarningReport", paramter);

            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<HotelEarningViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> HotelEarningReport(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload)
        {
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ApplicationUser usr = await GetCurrentUserAsync();
            var user = await _usermanager.FindByIdAsync(usr.Id);
            var role = await _usermanager.GetRolesAsync(user);
            string roles = role[0].ToString();

            if (search != null)
            {

                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);

                var orderheaderList1 = _ISP_Call.List<HotelEarningViewModel>("HotelEarningReport", paramter);

                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(OrderPagination<HotelEarningViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();
                if (roles == "Admin")
                {
                    paramter.Add("@storeid", "");
                }
                else
                {
                    paramter.Add("@storeid", usr.Id);
                }
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                paramter.Add("@status", status);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                 

                var orderheaderList1 = _ISP_Call.List<HotelEarningViewModel>("HotelEarningReport", paramter);



                var builder = new StringBuilder();
                builder.AppendLine(" Order Id,Date,Store,Hotel Amount,Packing Charges,Subtotal,Commission,tofozamt,netpayable,storetax, promocode, Status, Deliveryboy");
                foreach (var item in orderheaderList1)
                {
                    builder.AppendLine($"{item.id},{item.placedate },{item.customeramt },{item.packingcharges },{item.subtotal1 },{item.storecommission},{item.tofozamt },{item.netpayable  },{item.storetax},{item.promocode  },{item.orderstatus},{item.deliveryboyName   }");
                }

              
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "HotelEarning.csv");
            }


            else
            {
                return View();
            }



        }

    }
}
