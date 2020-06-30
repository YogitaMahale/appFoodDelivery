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
using System.Security.Policy;
using System.Net.Mail;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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
                name = users.name,
                mobileno = users.mobileno,
                gender = users.gender,
                UserName = users.UserName

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
                if (res.Succeeded)
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

        [HttpGet]
        public IActionResult forgetpassword()
        {
            var model = new storeForgetPasswordViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> forgetpassword(storeForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);
                //if (user != null && await usermanager.IsEmailConfirmedAsync(user))
                //{
                //    var token = await usermanager.GeneratePasswordResetTokenAsync(user);
                //    var passwordresetLink = Url.Action("ResetPassword", "Account",
                //        new { email = model.Email, token = token }, Request.Scheme);
                //    bool send = SendMail(model.Email,passwordresetLink);
                //    return View("storeForgotPasswordConfimation");
                //}
                if (user != null)
                {
                    var token = await usermanager.GeneratePasswordResetTokenAsync(user);
                    var passwordresetLink = Url.Action("ResetPassword", "Account",
                        new { email = model.Email, token = token }, Request.Scheme);
                   bool send = SendConfirmationMail(model.Email, passwordresetLink);
                    return View("storeForgotPasswordConfimation");
                }
                return View("storeForgotPasswordConfimation");
            }
            return View();
        }
        private bool SendConfirmationMail(string email,string link)
        {
            //----  msg--
            string oSB = string.Empty;
            oSB += "<br/>";
           oSB += "<div>Hello ,</div>";
            oSB += "<a href=\"'"+link+"'"+">Change Password</a>";
            // oSB += "<table><tr><td>Login Name  </td> <td>'" +"" + "'</td> </tr> <tr> <td>Password  </td><td>'" + "" + "'</td> </tr> <tr> <td>Email  </td><td>'" + "" + "'</td> </tr> <tr> <td>Bank  </td><td>'" + "" + "'</td>  </tr> <tr><td>Branch Name  </td><td>'" + "" + "'</td> </tr> <tr> <td>Branch Code  </td><td>'" + "" + "'</td> </tr>   <tr> <td>State </td><td>'" + "" + "'</td> </tr> <tr><td>City</td><td>'" +"" + "'</td> </tr> <tr> <td>PinCode</td><td>'" + "" + "'</td>   </tr> <tr>    <td>Mobile No </td><td>'" +""+ "'</td>     </tr> <tr>       <td>Phone No </td><td>'" + "" + "'</td>  </tr> <tr>   <td>GST No </td><td>'" +"" + "'</td> </tr> <tr> <td>Zonal Admin Manager Name </td><td>'" + "" + "'</td>  </tr> <tr><td>Appartment/ Building </td><td>'" + "" + "'</td> </tr><tr> <td>Landmark </td><td>'" + "" + "'</td> </tr><tr> <td>Street / Road</td><td>'" + ""+ "'</td> </tr> <tr>  <td>Zonal Admin Manager Email </td><td>'" + "" + "'</td>  </tr></table>";

            //oSB += "<hr/>";
            //  oSB += "<div>Thank you,</div>";
            // oSB += "<div>Food Delivery- Support Team.</div>";
            //----------------
            // common ocommon = new common();
            //   string oSB = string.Empty;
            bool send = false;
            MailMessage mail = new MailMessage();
            //mail.To.Add("all4stationery@gmail.com");

            //  mail.To.Add("technologiesvsys@gmail.com");
            // mail.CC.Add("info@all-stationery.com");
            //  mail.CC.Add("yogesh.m@gmail.com");
           // mail.CC.Add("info4stationery@gmail.com");
            // mail.CC.Add("manekar.yogesh1@gmail.com");
            //mail.To.Add("ploutos.kiran@gmail.com");
            if (email.ToString().Trim() == "".Trim())
            {
            }
            else
            {
                mail.To.Add(new MailAddress(email.ToString().Trim()));
            }
            



            // mail.To.Add(new MailAddress("mahaleyogita233@gmail.com"));
            //  mail.From = new MailAddress("accounts@all-stationery.com", "Stationery Order");
            mail.From = new MailAddress("info@picindia.in", "Stationery Registration");

            mail.Subject = "Forget Password";
            mail.Body = oSB.ToString();
            //string Filepath = Server.MapPath("~\\PDF\\") + "Invoice" + count + ".pdf";

            //string PdfFile = Request.PhysicalApplicationPath + "1.pdf";
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(Filepath);
            //mail.Attachments.Add(attachment);

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential("accounts@all-stationery.com", "kiran@123");
            smtp.Credentials = new System.Net.NetworkCredential("info@picindia.in", "sumit@2020");

            //info@all-stationery.com
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
             //   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + ex.Message + "," + ex.StackTrace + "')", true);
                // ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            return send;
        }
        //private bool SendMail(string email,string link)
        //{
        //    //----  msg--
        //    string oSB = string.Empty;
        //    oSB += "<br/>";
        //    oSB += "<div>Hello Admin,</div>";
        //   // oSB += "<table><tr><td>Login Name  </td> <td>'" + txtloginname.Text + "'</td> </tr> <tr> <td>Password  </td><td>'" + txtpassword.Text + "'</td> </tr> <tr> <td>Email  </td><td>'" + txtemail.Text + "'</td> </tr> <tr> <td>Bank  </td><td>'" + ddlbank.SelectedItem.ToString() + "'</td>  </tr> <tr><td>Branch Name  </td><td>'" + txtname.Text + "'</td> </tr> <tr> <td>Branch Code  </td><td>'" + txtbranchcode.Text + "'</td> </tr>   <tr> <td>State </td><td>'" + ddlState.SelectedItem + "'</td> </tr> <tr><td>City</td><td>'" + ddlCity.SelectedItem + "'</td> </tr> <tr> <td>PinCode</td><td>'" + txtpincode.Text + "'</td>   </tr> <tr>    <td>Mobile No </td><td>'" + txtmobileno.Text + "'</td>     </tr> <tr>       <td>Phone No </td><td>'" + txtphone.Text + "'</td>  </tr> <tr>   <td>GST No </td><td>'" + txtgstno.Text + "'</td> </tr> <tr> <td>Zonal Admin Manager Name </td><td>'" + txtzonalname.Text + "'</td>  </tr> <tr><td>Appartment/ Building </td><td>'" + txtapartment.Text + "'</td> </tr><tr> <td>Landmark </td><td>'" + txtroad.Text + "'</td> </tr><tr> <td>Street / Road</td><td>'" + txtaddress.Text + "'</td> </tr> <tr>  <td>Zonal Admin Manager Email </td><td>'" + txtzonalmail.Text + "'</td>  </tr></table>";

        //    oSB += "<hr/>";
        //    oSB += "<div>Thank you,</div>";
        //    oSB += "<div>all-stationery- Support Team.</div>";
        //    //----------------

        //    bool send = false;
        //    MailMessage mail = new MailMessage();

        //   // mail.CC.Add("info4stationery@gmail.com");

        //    if (email.ToString().Trim() == "".Trim())
        //    {
        //    }
        //    else
        //    {
        //        mail.To.Add(new MailAddress(email.ToString().Trim()));
        //    }

        //    mail.From = new MailAddress("info@picindia.in", "Stationery Registration");

        //    mail.Subject = "Forget Password";
        //    mail.Body = link.ToString();          

        //    mail.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "103.250.184.62";
        //    smtp.Port = 25;
        //    smtp.UseDefaultCredentials = false;
        //    //smtp.Credentials = new System.Net.NetworkCredential("accounts@all-stationery.com", "kiran@123");
        //    smtp.Credentials = new System.Net.NetworkCredential("info@picindia.in", "sumit@2020");

        //    //info@all-stationery.com
        //    try
        //    {
        //        smtp.Send(mail);
        //        send = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        send = false;
        //      //  ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + ex.Message + "," + ex.StackTrace + "')", true);
        //        // ErrHandler.writeError(ex.Message, ex.StackTrace);
        //    }
        //    return send;
        //}
        [HttpGet]
        public IActionResult ResetPassword(string token, string email) 
        {
           if(token==null||email==null)
            {
                ModelState.AddModelError("", "Invalid Password Reset Token");
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(storeResetPasswordViewmodel model)
        {
            if(ModelState.IsValid)
            {
                var user = await usermanager.FindByEmailAsync(model.Email);
                if(user!=null)
                {
                    var result = await usermanager.ResetPasswordAsync(user, model.Token, model.Password);
                    if(result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }

             

            return View(model);
        }
    }
}
