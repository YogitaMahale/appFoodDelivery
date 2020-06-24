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
using System;

namespace appFoodDelivery.Controllers
{
    public class productcuisineController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Iproductcuisinemasterservices _productcuisinemasterservices;
        public productcuisineController(Iproductcuisinemasterservices productcuisinemasterservices, UserManager<ApplicationUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _productcuisinemasterservices = productcuisinemasterservices;
            _hostingEnvironment = hostingEnvironment;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var listt = _productcuisinemasterservices.GetAll().Where(x => x.storeid == id).Select(x => new productcuisineIndexViewModel
            {
                id = x.id
                ,
                name = x.name,
                img=x.img

            }).ToList();
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new productcuisineCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(productcuisineCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                var store = new productcuisinemaster
                {
                    id = model.id
                    ,
                    name = model.name
                   //   , profilephoto=model.profilephoto
                   ,
                    isdeleted = false
                    ,
                    isactive = false
                    ,  
                    storeid = id

                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/cuisine";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.img = '/' + uploadDir + '/' + fileName;

                }
                await _productcuisinemasterservices.CreateAsync(store);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public IActionResult Edit(int id)
        {
            var storeowner = _productcuisinemasterservices.GetById(id);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new productcuisineEditViewModel()
            {
                id = storeowner.id,
                name = storeowner.name,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(productcuisineEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _productcuisinemasterservices.GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.name = model.name;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/cuisine";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.img = '/' + uploadDir + '/' + fileName;

                }
                await _productcuisinemasterservices.UpdateAsync(storeobj);
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
            await _productcuisinemasterservices.Delete(id);
            return RedirectToAction(nameof(Index));



        }
    }
}
