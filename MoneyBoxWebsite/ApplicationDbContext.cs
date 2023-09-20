using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MoneyBoxWebsite
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necessary for Identity to initialize its tables.


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Client",
                },
                new IdentityRole()
                {
                    Name = "Assistant"
                },
                new IdentityRole()
                {
                    Name = "Manager"
                },
                new IdentityRole()
                {
                    Name = "Moderator"
                },
                new IdentityRole()
                {
                    Name = "Administrator"
                }
            );
            
        }
    }
}
