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

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Ticket> Tickets {get; set;}
        public DbSet<Flight> Flights { get; set; }

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

            builder.Entity<Cart>()
                .HasOne(c => c.ApplicationUser)
                .WithOne(a => a.Cart)
                .HasForeignKey<Cart>(c => c.CartId);

            builder.Entity<Cart>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Cart);

            builder.Entity<Ticket>()
                .HasOne(t => t.Flight)
                .WithOne(f => f.Ticket)
                .HasForeignKey<Flight>(f => f.FlightId);

        }
    }
}
