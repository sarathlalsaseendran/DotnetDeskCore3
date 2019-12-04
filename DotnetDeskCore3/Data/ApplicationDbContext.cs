using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetDeskCore3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Organization> Organization { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<SupportAgent> SupportAgent { get; set; }

        public DbSet<SupportEngineer> SupportEngineer { get; set; }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
