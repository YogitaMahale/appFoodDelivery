﻿using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Notification;
using appFoodDelivery.pagination;
using appFoodDelivery.Services;
using appFoodDelivery.Services.Implementation;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(int? PageNumber, string from1, string to1, string status)
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
                decimal amount = 0;
                foreach (var item in orderheaderList1)
                {
                    amount += item.amount;
                    builder.AppendLine($"{item.id},{item.storeid},{item.customerName},{item.amount},{item.placedate}");
                }
                builder.AppendLine($"{""},{""},{"Total :"},{amount },{""}");
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Report.csv");
            }


            else
            {
                return View();
            }



        }


        //--------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> orderHistoryReport(int? PageNumber, string from1, string to1, string status, string deliveryboyid)
        {
            List<SelectList> cl = new List<SelectList>();
            // cl = (from c in _auc.country select c).ToList();
       
            //List<SelectListItem> mySkills = new List<SelectListItem>() {

            //ViewData["MySkills"] = mySkills;
            IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
            ViewData["deliveryboylist"] = obj;

            ViewBag.deliveryboyid1 = deliveryboyid;

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
            paramter.Add("@deliveryboyid", deliveryboyid);

            var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);


            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<orderHistoryReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> orderHistoryReport(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload, int deliveryboyid)
        {
            IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
            ViewData["deliveryboylist"] = obj;
            //---------------------------------------------
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            ViewBag.status1 = status;
            ViewBag.deliveryboyid1 = deliveryboyid;

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
                paramter.Add("@deliveryboyid", deliveryboyid);
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
                paramter.Add("@deliveryboyid", deliveryboyid);
                var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport", paramter);

                string deliveryname = _driverRegistrationServices.GetById(deliveryboyid).name;


                var builder = new StringBuilder();
                builder.AppendLine("Order ID,Store ,Customer,Fianl Amount,Customer Amount,Customer Delivery Charges,Delivery boy Charges,Order Status,Deliveryboy ,Date,Payment Method");
                decimal tot_finalamt = 0;
                decimal tot_customeramt = 0;
                decimal tot_customerdeliverycharges = 0;
                decimal tot_deliveryboycharges = 0;
                foreach (var item in orderheaderList1)
                {
                    tot_finalamt += item.finalamt;
                    tot_customeramt += item.customeramt;
                    tot_customerdeliverycharges += item.customerdeliverycharges;
                    tot_deliveryboycharges += item.deliveryboycharges;
                    builder.AppendLine($"{item.id},{item.storename},{item.customerName},{item.finalamt },{item.customeramt},{item.customerdeliverycharges},{item.deliveryboycharges},{item.orderstatus },{item.deliveryboyName},{item.placedate },{item.paymentstatus}");
                }
                builder.AppendLine($"{""},{""},{"Total :"},{tot_finalamt },{tot_customeramt},{tot_customerdeliverycharges},{tot_deliveryboycharges},{"" },{""},{"" }");
                string namee = deliveryname + "_OrderHistory.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
            }


            else
            {
                return View();
            }



        }

        //---------------------------
        [HttpGet]
        public async Task<IActionResult> HotelEarningReport(int? PageNumber, string from1, string to1, string status, string storeid)
        {

            IEnumerable<SelectListItem> obj = _storedetailsServices.GetAllStore();
            ViewData["storelist"] = obj;

            ViewBag.storeid1 = storeid;
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
                paramter.Add("@storeid", storeid);
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
        public async Task<IActionResult> HotelEarningReport(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload, string storeid)
        {

            IEnumerable<SelectListItem> obj = _storedetailsServices.GetAllStore();
            ViewData["storelist"] = obj;

            ViewBag.storeid1 = storeid;
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
                    paramter.Add("@storeid", storeid);
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
                    paramter.Add("@storeid", storeid);
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


                decimal tot_hotelamt = 0;
                decimal tot_packingcharges = 0;
                decimal tot_subtotal1 = 0;
                decimal tot_storecommission = 0;
                decimal tot_tofozamt = 0;
                decimal tot_netpayable = 0;
                decimal tot_servicestax = 0;
                decimal tot_TCStax = 0;


                builder.AppendLine(" Order Id ,Date ,Store  ,Hotel Amount ,Packing Charges ,Subtotal ,Commission (%) ,TOFOZ Amount , Service tax, TCS, Netpayable, Tax, Promo Code, Status, Deliveryboy");
                foreach (var item in orderheaderList1)
                {


                    tot_hotelamt += Convert.ToDecimal(item.hotelamount);
                    tot_packingcharges += item.packingcharges;
                    tot_subtotal1 += item.subtotal1;
                    tot_storecommission += item.storecommission;
                    tot_tofozamt += item.tofozamt;
                    tot_netpayable += item.netpayable;
                    tot_servicestax += item.storetax;
                    tot_TCStax += item.TCS;

                    builder.AppendLine($"{item.id},{item.placedate },{item.storename },{item.hotelamount  },{item.packingcharges },{item.subtotal1  },{item.storecommission},{item.tofozamt },{item.servicetax  },{item.TCS},{item.netpayable   },{item.promocode},{item.storetaxStatus},{item.deliveryboyName   }");

                }
                builder.AppendLine($"{""},{"" },{"Total :" },{tot_hotelamt },{tot_packingcharges},{tot_subtotal1 },{tot_storecommission},{tot_tofozamt },{tot_servicestax   },{tot_TCStax },{tot_netpayable   },{""},{""   },{""}");
                string namee = _storedetailsServices.GetAll().Where(x => x.storeid == storeid).FirstOrDefault().storename;
                string abc = namee + "_HotelEarning.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", abc);
            }


            else
            {
                return View();
            }



        }
        //--------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> DeliveryboyReport(int? PageNumber, string from1, string to1, string status)
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

            var orderheaderList1 = _ISP_Call.List<deliveryboyViewModel>("orderHistoryReport", paramter);


            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<deliveryboyViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> DeliveryboyReport(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload)
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

                var orderheaderList1 = _ISP_Call.List<deliveryboyViewModel>("orderHistoryReport", paramter);

                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(OrderPagination<deliveryboyViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

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
                var orderheaderList1 = _ISP_Call.List<deliveryboyViewModel>("orderHistoryReport", paramter);




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
        //--------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> orderHistoryReport1(int? PageNumber, string from1, string to1, string status)
        {
            List<SelectListItem> mySkills = new List<SelectListItem>() {
        new SelectListItem {
            Text = "ASP.NET MVC", Value = "1"
        },
        new SelectListItem {
            Text = "ASP.NET WEB API", Value = "2"
        },
        new SelectListItem {
            Text = "ENTITY FRAMEWORK", Value = "3"
        },
        new SelectListItem {
            Text = "DOCUSIGN", Value = "4"
        },
        new SelectListItem {
            Text = "ORCHARD CMS", Value = "5"
        },
        new SelectListItem {
            Text = "JQUERY", Value = "6"
        },
        new SelectListItem {
            Text = "ZENDESK", Value = "7"
        },
        new SelectListItem {
            Text = "LINQ", Value = "8"
        },
        new SelectListItem {
            Text = "C#", Value = "9"
        },
        new SelectListItem {
            Text = "GOOGLE ANALYTICS", Value = "10"
        },
    };
            ViewData["MySkills"] = mySkills;




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

            var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport1", paramter);


            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<orderHistoryReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> orderHistoryReport1(int? PageNumber, string from1, string to1, string status, string search, string ExcelFileDownload, string deliveryboyid)
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

                var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport1", paramter);

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
                var orderheaderList1 = _ISP_Call.List<orderHistoryReportViewModel>("orderHistoryReport1", paramter);




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
        //--------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> collectionReport(int? PageNumber, string from1, string to1, string deliveryboyid)
        {
            List<SelectList> cl = new List<SelectList>();
            // cl = (from c in _auc.country select c).ToList();

            //List<SelectListItem> mySkills = new List<SelectListItem>() {

            //ViewData["MySkills"] = mySkills;
            IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
            ViewData["deliveryboylist"] = obj;

            ViewBag.deliveryboyid1 = deliveryboyid;

            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
           //ViewBag.status1 = status;
            

           
            var paramter = new DynamicParameters();
           
            
            paramter.Add("@from", from1);
            paramter.Add("@to", to1);
            paramter.Add("@deliveryboyid", deliveryboyid);

            var orderheaderList1 = _ISP_Call.List<amtcollectionReportViewModel>("amtcollectionReport", paramter);


            //  return View(orderheaderList1.ToList());
            int PageSize = 10;
            return View(OrderPagination<amtcollectionReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));




        }

        [HttpPost]
        public async Task<IActionResult> collectionReport(int? PageNumber, string from1, string to1,  string search, string ExcelFileDownload, int deliveryboyid)
        {
            IEnumerable<SelectListItem> obj = _driverRegistrationServices.GetAlldriver();
            ViewData["deliveryboylist"] = obj;
            //---------------------------------------------
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
             
            ViewBag.deliveryboyid1 = deliveryboyid;

            
            if (search != null)
            {

                var paramter = new DynamicParameters();
                 
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

               
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@deliveryboyid", deliveryboyid);
                var orderheaderList1 = _ISP_Call.List<amtcollectionReportViewModel>("amtcollectionReport", paramter);

                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(OrderPagination<amtcollectionReportViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();
                
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@deliveryboyid", deliveryboyid);
                var orderheaderList1 = _ISP_Call.List<amtcollectionReportViewModel>("amtcollectionReport", paramter);

                string deliveryname = _driverRegistrationServices.GetById(deliveryboyid).name;


                var builder = new StringBuilder();
                builder.AppendLine("Date,Amount");
                decimal tot_amt = 0;
                 
                foreach (var item in orderheaderList1)
                {
                    tot_amt += item.amount;
                   
                    builder.AppendLine($"{item.date1 },{item.amount}");
                }
                builder.AppendLine($" {"Total :"},{tot_amt }");
                string namee = deliveryname + "_collectionReport.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
            }


            else
            {
                return View();
            }



        }

    }
}
