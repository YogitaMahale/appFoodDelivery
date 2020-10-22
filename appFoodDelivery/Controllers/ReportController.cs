using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class ReportController : Controller
    {
        private readonly IordersServices _ordersServices;
        private readonly ISP_Call _ISP_Call;
        public ReportController(IordersServices ordersServices, ISP_Call ISP_Call)
        {
            _ordersServices = ordersServices;
            _ISP_Call = ISP_Call;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
       
        public async Task<IActionResult> GetOrderList(string status)
        {
            // return Json(new { data = "" });
            var paramter = new DynamicParameters();
            paramter.Add("@storeid", "");
            paramter.Add("@status", status);

            //storedetailsListViewmodel
            var orderheaderList1 = _ISP_Call.List<orderselectallViewModel>("orderSelectAll1", paramter);
            orderheaderList1 = orderheaderList1.Where(x => x.placedate.ToString() == DateTime.Today.ToString("dd/MM/yyyy").Replace("-", "/"));
            //return Json(new { data = orderheaderList });
            return Json(new { data = orderheaderList1 });
            /*
             var paramter = new DynamicParameters();
             paramter.Add("@storeid", "");
             paramter.Add("@status", status);

             //storedetailslistviewmodel
             var orderheaderlist1 = _ISP_Call.List<reportViewModel>("searchOrderSP", paramter);
          //   orderheaderlist1 = orderheaderlist1.where(x => x.placedate.tostring() == datetime.today.tostring("dd/mm/yyyy").replace("-", "/"));
             //return json(new { data = orderheaderlist });
             return json(new { data = orderheaderlist1 });


  */

        }
        
        #endregion
    }
}
