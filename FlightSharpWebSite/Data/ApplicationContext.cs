using FlightSharpWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlightSharpWebSite.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() }
                );

            modelBuilder.Entity<WebUser>()
                .HasOne<UserAccount>(fk => fk.UserAccount)
                .WithOne(ad => ad.WebUser)
                .HasForeignKey<UserAccount>(ad => ad.WebUserId);

        }
    }
}
