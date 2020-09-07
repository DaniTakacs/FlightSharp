using FlightSharpWebSite.Areas.Identity.Data;
using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightSharpWebSite.Data
{
    public class FlightSharpWebSiteContext : IdentityDbContext<ApplicationUser>
    {
        public FlightSharpWebSiteContext(DbContextOptions<FlightSharpWebSiteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(appUser => appUser.UserAddress)
                .WithOne(address => address.ApplicationUser)
                .HasForeignKey<UserAddress>(u => u.UserAddressId);

        }
    }
}
