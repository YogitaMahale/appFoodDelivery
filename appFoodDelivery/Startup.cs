using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using appFoodDelivery.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using appFoodDelivery.Services;
using appFoodDelivery.Services.Implementation;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using appFoodDelivery.Entity;
using appFoodDelivery.Models;
using plathora.Services.Implementation;

namespace appFoodDelivery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders()
                 .AddDefaultUI();

            services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequireDigit = true;
                Options.Password.RequireLowercase = true;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireUppercase = true;
                Options.Password.RequiredLength = 6;
                Options.Password.RequiredUniqueChars = 1;
                Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                Options.Lockout.MaxFailedAccessAttempts = 5;
                Options.Lockout.AllowedForNewUsers = true;

            });

            //.AddDefaultUI(UIFrameworkAttribute.boot)



            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddScoped<Istoreownerservices, storeownerservices>();
            services.AddScoped<IstoredetailsServices, storedetailsServices>();
            services.AddScoped<IRadiusMasterServices, RadiusMasterServices>();
            services.AddScoped<IDeliveryTimeMasterServices, DeliveryTimeMasterServices>();
            services.AddScoped<Iproductcuisinemasterservices , productcuisinemasterservices>();
            services.AddScoped<Iproductservices, productservices>();
            services.AddScoped<IdriverRegistrationServices , driverRegistrationServices>();
            services.AddScoped<ICustomerRegistrationservices, CustomerRegistrationservices>();
            services.AddScoped<IStateRegistrationService, StateRegistrationService>();
            services.AddScoped<ICountryRegistrationservices,CountryRegistrationServices>();
            services.AddScoped<ICityRegistrationservices,CityRegistrationservices>();

            services.AddScoped<IordersServices,ordersServices>();
            services.AddScoped<IorderproductServices, orderproductServices>();
            services.AddScoped<IorderhistoryServices, orderhistoryServices>();
            //services.AddScoped<IEmailSender, EmailSender>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                             IWebHostEnvironment env,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager
                             )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           DataSeedingInitializer.UserAndRoleSeedAsync(userManager, roleManager).Wait();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
