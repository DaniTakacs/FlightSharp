using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightSharpWebSite.Data
{
    public class FlightSharpWebSiteContext : IdentityDbContext<IdentityUser>
    {
        public FlightSharpWebSiteContext(DbContextOptions<FlightSharpWebSiteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<UserAddress>()
                .HasOne(u => u.User)
                .WithOne(a => a.Address)
                .HasForeignKey<UserAddress>(a => a.ApplicationUserId);


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper() 
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admintest@example.com",
                    NormalizedUserName = "ADMINUSER",
                    Email = "admintest@example.com",
                    NormalizedEmail = "ADMINTEST@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Asdasd1-"),
                }
            );

            modelBuilder.Entity<UserAddress>()
                .HasData(new
                {
                    UserAddressId = 1,
                    Country = "Hungary",
                    City = "Budapest",
                    PostalCode = 1027,
                    Street = "Csalogany utca",
                    StreetNo = "45.",
                    ApplicationUserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
                );

            // seed admin into role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                }
                );
            ;

        }
    }
}
