﻿using System;
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
//using AspNetCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appFoodDelivery.Controllers
{
    public class productController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly  Iproductservices _productservices;
        public productController(Iproductservices productservices
                               , Iproductcuisinemasterservices productcuisinemasterservices
                               ,  IWebHostEnvironment hostingEnvironment
                                , UserManager<ApplicationUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _productcuisinemasterservices = productcuisinemasterservices;
            _productservices = productservices;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var listt = _productservices.GetAll().Where(x=>x.storeid==id).Select(x => new productIndexViewModel
            {
                id = x.id
               , storeid = x.storeid
               , productcuisineid = x.productcuisineid
               , productcuisinemaster = _productcuisinemasterservices.GetById(x.productcuisineid)
               , name = x.name
               , img = x.img
               , foodtype = x.foodtype
               , amount = x.amount
               , description = x.description
               , discounttype = x.discounttype
               , discountamount = x.discountamount

            }).ToList();
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;

            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().Where(x=>x.storeid==id).ToList();
            var model = new productCreateViewModel();
            return View(model);
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                var store = new product
                {
                    //id, productcuisineid, name, img, foodtype, amount, description, discounttype, discountamount,
                    //createddate, isdeleted, isactive, storeid
                    id = model.id,
                    productcuisineid=model.productcuisineid,
                    name=model.name,
                     
                    foodtype=model.foodtype,
                    amount=model.amount,
                    description=model.description,
                    discounttype=model.discounttype,
                    discountamount=model.discountamount,
                    createddate=model.createddate
                    , isdeleted=false 
                    , isactive= false
                    , storeid=id


                };
                if (model.img  != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    store .img = '/' + uploadDir + '/' + fileName;

                }
                await _productservices.CreateAsync(store);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id1 = usr.Id;

            ViewBag.productcuisine = _productcuisinemasterservices.GetAll().Where(x => x.storeid == id1).ToList();
            var prod = _productservices.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var model = new productEditViewModel()
            {
                id = prod.id,
                name = prod.name,                
                productcuisineid= prod.productcuisineid,      
                foodtype= prod.foodtype,
                amount= prod.amount,
                description= prod.description,
                discounttype= prod.discounttype,
                discountamount= prod.discountamount,
               
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(productEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _productservices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;


                storeobj.productcuisineid = model.productcuisineid;
                storeobj.foodtype = model.foodtype;
                storeobj.amount = model.amount;
                storeobj.description = model.description;
                storeobj.discounttype = model.discounttype;
                storeobj.discountamount = model.discountamount;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.img = '/' + uploadDir + '/' + fileName;

                }
                await _productservices .UpdateAsync(storeobj);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productservices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
    }
}
