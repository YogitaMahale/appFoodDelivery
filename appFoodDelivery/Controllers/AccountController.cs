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

namespace appFoodDelivery.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signinmanager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> usermanager,
                                    SignInManager<ApplicationUser> signinmanager,
                                    RoleManager<IdentityRole> roleManager
                                    , IWebHostEnvironment hostingEnvironment)
        {
            this.usermanager = usermanager;
            this.signinmanager = signinmanager;
            this.roleManager = roleManager;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    name = model.name,
                    mobileno = model.mobileno
                };
                var result = await usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    usermanager.AddToRoleAsync(user, "Store").Wait();

                    if (signinmanager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Account");
                    }
                    await signinmanager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> logout()
        {
            await signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await signinmanager.PasswordSignInAsync(model.Email, model.Password,
                       model.RememberMe, false);
                //   return RedirectToAction("Index", "Home");
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");


            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var roleExist = await roleManager.RoleExistsAsync(model.RoleName);
                if (!roleExist)
                {
                    IdentityRole identityRole = new IdentityRole
                    {
                        Name = model.RoleName
                    };

                    IdentityResult result = await roleManager.CreateAsync(identityRole);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = usermanager.Users;
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditListUsers(string id)
        {
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
                name=users.name,
                mobileno= users.mobileno,
                gender=users.gender,
                UserName= users.UserName 

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditListUsers(EditRegisterViewModel model1)
        {
            var users = await usermanager.FindByIdAsync(model1.Id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + model1.Id + "cannot be found";
                return View("NotFound");
            }
            else
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
                if(res.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in res.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model1);
        }

        public async Task<IActionResult> deleteListUsers(string id)
        {
            var users = await usermanager.FindByIdAsync(id);
            if (users == null)
            {
                ViewBag.ErrorMessgae = "User with id =" + id + "cannot be found";
                return View("NotFound");
            }
            else
            {
                // users.isdeleted = true;
                //var result= await usermanager.UpdateAsync (users);
               
                var result = await usermanager.DeleteAsync(users);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View();
        }



    }
}
