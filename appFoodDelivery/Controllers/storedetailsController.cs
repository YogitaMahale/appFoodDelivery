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
//using AspNetCore;

namespace appFoodDelivery.Controllers
{
    public class storedetailsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly IstoredetailsServices storedetailsServices;
        private readonly IRadiusMasterServices _RadiusMasterServices;
        private readonly IDeliveryTimeMasterServices _DeliveryTimeMasterServices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly SignInManager<ApplicationUser> _signinmanager;

        public storedetailsController(UserManager<ApplicationUser> usermanager
                                    , IWebHostEnvironment hostingEnvironment
                                     , IRadiusMasterServices RadiusMasterServices
                                    , IDeliveryTimeMasterServices DeliveryTimeMasterServices
                                    , IstoredetailsServices storedetailsServices
                                    , IStateRegistrationService StateRegistrationService
                                    , ICountryRegistrationservices CountryRegistrationservices
                                    , ICityRegistrationservices CityRegistrationservices
                                    , SignInManager<ApplicationUser> signinmanager
            )
        {
            this.usermanager = usermanager;
            this.storedetailsServices = storedetailsServices;
            _hostingEnvironment = hostingEnvironment;
            _RadiusMasterServices = RadiusMasterServices;
            _DeliveryTimeMasterServices = DeliveryTimeMasterServices;
            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;
            _signinmanager = signinmanager;
        }



        private Task<ApplicationUser> GetCurrentUserAsync() => usermanager.GetUserAsync(HttpContext.User);



        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ContactPersonDetails()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();
            var model = new StoreDetailContactPersonDetails();
            if (store == null)
            {

            }
            else
            {
                model.id = store.id;
                model.contactpersonname = store.contactpersonname;
                model.gender = store.gender;
                model.emailaddress = store.emailaddress;
                model.contactno = store.contactno;
                
            }


            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactPersonDetails(StoreDetailContactPersonDetails model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                //  var idd = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault().id;

                var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();

                if (store == null)
                {
                    var details = new storedetails
                    {
                        storeid = id,
                        // id = model.id,
                        contactpersonname = model.contactpersonname,
                        emailaddress = model.emailaddress,
                        gender = model.gender,
                        contactno = model.contactno,
                        isdeleted = false
                       // cityid=0
                        
                        // deliverytimeid = 0,
                        // radiusid = 0


                    };
                    await storedetailsServices.CreateAsync(details);
                }
                else
                {
                    //store.id = idd;
                    store.contactpersonname = model.contactpersonname;
                    store.emailaddress = model.emailaddress;
                    store.gender = model.gender;
                    store.contactno = model.contactno;
                    await storedetailsServices.UpdateAsync(store);
                }


                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Services()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();
            var model = new StoreDetailServicesDetails();
            if (store == null)
            {

            }
            else
            {
                model.id = store.id;
                model.fooddelivery = store.fooddelivery;

            }


            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Services(StoreDetailServicesDetails model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                //  var idd = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault().id;

                var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();

                if (store == null)
                {
                    var details = new storedetails
                    {
                        storeid = id,
                        // id = model.id,
                        fooddelivery = model.fooddelivery,
                        contactpersonname = "",
                        isdeleted = false,
                        // deliverytimeid = 0,
                        // radiusid = 0


                    };
                    await storedetailsServices.CreateAsync(details);
                }
                else
                {
                    //store.id = idd;
                    store.fooddelivery = model.fooddelivery;

                    await storedetailsServices.UpdateAsync(store);
                }


                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(model);
            }

        }

        public JsonResult getCitybyStateid(int stateid)
        {

            IList<CityRegistration> obj = _CityRegistrationservices.GetAll().Where(x => x.stateid == stateid).ToList();
            obj.Insert(0, new CityRegistration { id = 0, cityName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "cityName"));
        }


        [HttpGet]
        public async Task<IActionResult> StoreDetails()
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
            ViewBag.radiusList = _RadiusMasterServices.GetAll().ToList();
            ViewBag.deliveryList = _DeliveryTimeMasterServices.GetAll().ToList();
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();
            var model = new StoreDetailsViewModel();
            if (store == null)
            {

            }
            else
            {
                //             storename, radiusid, deliverytimeid, orderMinAmount, packagingCharges, storeBannerPhoto, 
                //address, description, storetim
                int stateid = 0;
                int countryid = 0;
                int cityyid = 0;
                if (store.cityid==null)
                {

                }
                else
                {
                      cityyid = Convert.ToInt32(store.cityid);
                      stateid = _CityRegistrationservices.GetById(cityyid).stateid;
                      countryid = _StateRegistrationService.GetById(stateid).countryid;
                }
                

                model.id = store.id;
                model.storename = store.storename;
                if (store.radiusid == null)
                {
                    model.radiusid = 0;
                }
                else
                {
                    model.radiusid = Convert.ToInt32(store.radiusid.ToString());

                }
                if (store.deliverytimeid == null)
                {
                    model.deliverytimeid = 0;
                }
                else
                {
                    model.deliverytimeid = Convert.ToInt32(store.deliverytimeid.ToString());

                }

                model.orderMinAmount = store.orderMinAmount;
                model.packagingCharges = store.packagingCharges;
                model.address = store.address;
                model.description = store.description;
                model.storetime = store.storetime;

                model.promocode = store.promocode;
                model.discount  = store.discount;


                if (store.cityid == null)
                {

                }
                else
                {
                    model.countryid = countryid;
                    model.stateid = stateid;
                    model.cityid = cityyid;
                }
                model.latitude = model.latitude;
                model.longitude = store.longitude;


                model.accountno = model.accountno;
                model.bankname  = store.bankname;
                model.banklocation = model.banklocation;
                model.ifsccode  = store.ifsccode;
                model.status = store.status;
                ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
                ViewBag.Cities = _CityRegistrationservices.GetAllCity(model.stateid);
            }


            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StoreDetails(StoreDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                //  var idd = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault().id;

                var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();

                if (store == null)
                {
                   
                    var details = new storedetails
                    {
                        storeid = id,
                        storename = model.storename,
                        contactpersonname = "",
                        // id = model.id,
                        radiusid = model.radiusid,
                        deliverytimeid = model.deliverytimeid,
                        orderMinAmount = model.orderMinAmount,
                        packagingCharges = model.packagingCharges,
                        isdeleted = false,
                        address = model.address,
                        description = model.description,
                        storetime = model.storetime,
                        latitude=model.latitude,
                        longitude=model.longitude,
                        cityid=model.cityid,
                        promocode=model.promocode,
                        discount=model.discount,

                         accountno = model.longitude,
                        banklocation  = model.banklocation,
                        bankname = model.bankname,
                        ifsccode = model.ifsccode,
                        status = model.status
                        // deliverytimeid = 0,
                        // radiusid = 0
                    };
                    if (model.storeBannerPhoto != null && model.storeBannerPhoto.Length > 0)
                    {
                        var uploadDir = @"uploads/storeBannerPhoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.storeBannerPhoto.FileName);
                        var extesion = Path.GetExtension(model.storeBannerPhoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.storeBannerPhoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        details.storeBannerPhoto = '/' + uploadDir + '/' + fileName;

                    }
                    await storedetailsServices.CreateAsync(details);
                }
                else
                {
                    //             storename, radiusid, deliverytimeid, orderMinAmount, packagingCharges, storeBannerPhoto, 
                    //address, description, storetim
                    //store.id = idd;
                    store.storename = model.storename;
                    store.radiusid = model.radiusid;
                    store.deliverytimeid = model.deliverytimeid;
                    store.orderMinAmount = model.orderMinAmount;

                    store.packagingCharges = model.packagingCharges;
                    store.address = model.address;
                    store.description = model.description;
                    store.storetime = model.storetime;
                    store.latitude = model.latitude;
                    store.longitude = model.longitude;
                    store.cityid = model.cityid;
                    store.promocode = model.promocode;
                    store.discount  = model.discount;

                    store.bankname = model.bankname;
                    store.banklocation = model.banklocation;
                    store.accountno = model.accountno;
                    store.ifsccode = model.ifsccode;
                    store.status = model.status;
                    if (model.storeBannerPhoto != null && model.storeBannerPhoto.Length > 0)
                    {
                        var uploadDir = @"uploads/storeBannerPhoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.storeBannerPhoto.FileName);
                        var extesion = Path.GetExtension(model.storeBannerPhoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.storeBannerPhoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        store.storeBannerPhoto = '/' + uploadDir + '/' + fileName;

                    }
                    await storedetailsServices.UpdateAsync(store);
                }


                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(model);
            }

        }


        //StoreDetails
        [HttpGet]
        public async Task<IActionResult> Documentation()
        {

            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();
            var model = new storedetaildocumentationviewmodel();



            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Documentation(storedetaildocumentationviewmodel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser usr = await GetCurrentUserAsync();
                var id = usr.Id;
                //  var idd = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault().id;

                var store = storedetailsServices.GetAll().Where(x => x.storeid == id).FirstOrDefault();

                if (store == null)
                {
                    var details = new storedetails
                    {
                        storeid = id,

                        contactpersonname = "",

                        isdeleted = false,

                    };
                    if (model.licPhoto != null && model.licPhoto.Length > 0)
                    {
                        var uploadDir = @"uploads/storeBannerPhoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.licPhoto.FileName);
                        var extesion = Path.GetExtension(model.licPhoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.licPhoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        details.licPhoto = '/' + uploadDir + '/' + fileName;

                    }
                    await storedetailsServices.CreateAsync(details);
                }
                else
                {
                    //             storename, radiusid, deliverytimeid, orderMinAmount, packagingCharges, storeBannerPhoto, 
                    //address, description, storetim
                    //store.id = idd;


                    if (model.licPhoto != null && model.licPhoto.Length > 0)
                    {
                        var uploadDir = @"uploads/licPhoto";
                        var fileName = Path.GetFileNameWithoutExtension(model.licPhoto.FileName);
                        var extesion = Path.GetExtension(model.licPhoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.licPhoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        store.licPhoto = '/' + uploadDir + '/' + fileName;

                    }
                    await storedetailsServices.UpdateAsync(store);
                }


                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View(model);
            }

        }
        [HttpGet]
        public async Task<IActionResult> EditStoreProfile()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var users = await usermanager.FindByIdAsync(id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            var model = new EditRegisterViewModel()
            {
                Id = users.Id,
                Email = users.Email,
                name = users.name,
                mobileno = users.mobileno,
                gender = users.gender,
                UserName = users.UserName

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditStoreProfile(EditRegisterViewModel model1)
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            var id = usr.Id;
            var users = await usermanager.FindByIdAsync(id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + model1.Id + "cannot be found";
                return View("NotFound");
            }
            else
            {
                var chkduplicate = usermanager.Users.Where(x => x.UserName == model1.UserName && x.Id != id).FirstOrDefault();
                if (chkduplicate == null)
                {
                    users.name = model1.name;
                    users.gender = model1.gender;
                    users.mobileno = model1.mobileno;
                    users.Email = model1.Email;
                    users.UserName = model1.UserName;
                    if (model1.profilephoto != null && model1.profilephoto.Length > 0)
                    {
                        var uploadDir = @"uploads/storeowner";
                        var fileName = Path.GetFileNameWithoutExtension(model1.profilephoto.FileName);
                        var extesion = Path.GetExtension(model1.profilephoto.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model1.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                        users.profilephoto = '/' + uploadDir + '/' + fileName;

                    }
                    var res = await usermanager.UpdateAsync(users);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }
                else
                {
                    ModelState.AddModelError("","Duplicate User Name");

                }
            }
            return View(model1);
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(StoreDetailsChangePasswordViewModel model)
        {
           if(ModelState.IsValid)
            {
               var user = await usermanager.GetUserAsync(User);
                if(user==null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    var result = await usermanager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if(!result.Succeeded)
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);

                        }
                    }
                    await _signinmanager.RefreshSignInAsync(user);
                    return View("ChangePasswordConfirmationView");
                }
            }
            return View(model );
        }
    }
}
//Documentation