﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DCC_TrashCollector.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.Day> Days { get; set; }

        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.ZipCode> ZipCodes { get; set; }

        public System.Data.Entity.DbSet<DCC_TrashCollector.Models.State> States { get; set; }

 
    }
}