using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Repositories;

namespace MoneyBoxWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Database connection
            var conStrBuilder = new SqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("SQLConnection")
            );
            conStrBuilder.UserID = builder.Configuration["DB_USERID"];
            conStrBuilder.Password = builder.Configuration["DB_PASSWORD"];

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(conStrBuilder.ConnectionString));


            // Identity configuration
            builder.Services.AddIdentity<Client, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true; // default
                options.Password.RequireLowercase = true; // default
                options.Password.RequireNonAlphanumeric = true; // default
                options.Password.RequireUppercase = true; // default
                options.Password.RequiredLength = 6; // default
                options.Password.RequiredUniqueChars = 1; // default

                // SignIn settings.
                options.SignIn.RequireConfirmedEmail = false; // default
                options.SignIn.RequireConfirmedPhoneNumber = false; // default

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // default
                options.Lockout.MaxFailedAccessAttempts = 5; // default
                options.Lockout.AllowedForNewUsers = true; // default

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; // default
                options.User.RequireUniqueEmail = true; //UPDATED
            });


            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}