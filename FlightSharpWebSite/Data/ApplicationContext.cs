using System.Runtime.CompilerServices;
using FlightSharpWebSite.Models;
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
            modelBuilder.Entity<WebUser>()
                .HasOne<UserAccount>(fk => fk.UserAccount)
                .WithOne(ad => ad.WebUser)
                .HasForeignKey<UserAccount>(ad => ad.WebUserId); 
        }
    }
}
