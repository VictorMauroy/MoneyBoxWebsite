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

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Name = "Classic Pink",
                    Description = "You all have it in mind and now it's on sale!",
                    Price = 50,
                    Height = 15,
                    Width = 20,
                    Length = 15,
                    Weigth = 1,
                    MoneyCapacity = 56,
                    ImageFilePath = "/images/0001.jpg",
                    Reference = "#" + "000001",
                    Manufacturer = "Database",
                    Color = "Pink"
                },
                new Product()
                {
                    Name = "Pink pink",
                    Description = "There will never be enough of pink in your life.",
                    Price = 65,
                    Height = 10,
                    Width = 15,
                    Length = 15,
                    Weigth = 0.7f,
                    MoneyCapacity = 42,
                    ImageFilePath = "/images/0002.jpg",
                    Reference = "#" + "000002",
                    Manufacturer = "Database",
                    Color = "Pink"
                },
                new Product()
                {
                    Name = "Red pink",
                    Description = "Should be red but we didn't have any red colorant in our stock.",
                    Price = 25,
                    Height = 15,
                    Width = 20,
                    Length = 15,
                    Weigth = 1.5f,
                    MoneyCapacity = 51,
                    ImageFilePath = "/images/0003.jpg",
                    Reference = "#" + "000003",
                    Manufacturer = "Database",
                    Color = "Red"
                }
            );
        }

        
    }
}
