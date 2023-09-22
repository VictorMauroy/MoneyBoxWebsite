using Microsoft.AspNetCore.Identity;
using MoneyBoxWebsite.Models;

namespace MoneyBoxWebsite.Data
{
    public static class DataSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
                return;

            if (!roleManager.RoleExistsAsync("Client").Result)
            {
                IdentityRole clientRole = new()
                {
                    Name = "Client"
                };
                await roleManager.CreateAsync(clientRole);
            }

            if (!roleManager.RoleExistsAsync("Assistant").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Assistant" });

            if (!roleManager.RoleExistsAsync("Moderator").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Moderator" });

            if (!roleManager.RoleExistsAsync("Manager").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Manager" });

            if (!roleManager.RoleExistsAsync("Admin").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        }

        public static async Task SeedProducts(ApplicationDbContext ctx)
        {
            if (ctx.Products.Any())
                return;

            Product classicPink = new Product()
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
            };
            await ctx.Products.AddAsync(classicPink);
            
            await ctx.Products.AddAsync(new Product() {
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
                Color = "Pink" }
            );

            await ctx.Products.AddAsync(new Product() {
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
                Color = "Red" }
            );
        }
    }
}
