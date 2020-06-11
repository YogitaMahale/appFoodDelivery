using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;
namespace appFoodDelivery.Controllers
{
    public class StoreOwnerController:Controller
    {
        private readonly Istoreownerservices _storeownerservices;
        public StoreOwnerController(Istoreownerservices storeownerservices)
        {
            _storeownerservices = storeownerservices;
        }
        public IActionResult Index()
        {
            var storeList = _storeownerservices.GetAll().Select(x => new StoreOwnerIndexViewModel
            {
                id=x.id
                , name=x.name
                , profilephoto=x.profilephoto
                , mobileno=x.mobileno
                , emailid=x.emailid
                , password=x.profilephoto
                , gender=x.gender
                , createddate=x.createddate
                , isactive=x.isactive
            }).ToList();
            return View(storeList);
        }
            
    }
}
