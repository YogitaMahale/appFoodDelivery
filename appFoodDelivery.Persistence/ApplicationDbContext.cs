using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using appFoodDelivery.Entity;
namespace appFoodDelivery.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       //public  DbSet<storeowner> storeowner { get; set; }
        public DbSet<radiusmaster> radiusmaster { get; set; }
        public DbSet<deliverytimemaster> deliverytimemaster { get; set; }

        public DbSet<storedetails> storedetails { get; set; }
        public DbSet<productcuisinemaster> productcuisinemaster { get; set; }
        public DbSet<product> product { get; set; }
        public DbSet<driverRegistration> driverRegistration { get; set; }
        public DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public DbSet<CountryRegistration> CountryRegistration { get; set; }
        public DbSet<StateRegistration> StateRegistration { get; set; }
        public DbSet<CityRegistration> CityRegistration { get; set; }

        public DbSet<charges> charges { get; set; }
        public DbSet<slider> slider { get; set; }

        public DbSet<orders> orders { get; set; }
        public DbSet<orderhistory> orderhistory { get; set; }
        public DbSet<orderproducts> orderproducts { get; set; }
        public DbSet<customerfeedback> customerfeedback { get; set; }
        public DbSet<promocodemaster> promocodemaster { get; set; }
        public DbSet<DeliveryboytoCustomerfeedback> DeliveryboytoCustomerfeedback { get; set; }
        public DbSet<distance> distance { get; set; }
        public DbSet<menumaster> menumasters { get; set; }
        public DbSet<denyOrders> denyOrders { get; set; }
    }
}
