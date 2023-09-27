using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MoneyBoxWebsite.Data;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            //builder.Services.AddDefaultIdentity<Client>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddIdentity<Client, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();

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
                options.User.RequireUniqueEmail = false; // default
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Default
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; // Default
            })
            .AddCookie(options =>
            {
                //In case your are trying to load a page that uses the attribute Authorize :
                options.LoginPath = "/Login"; // When not authenticated, you'll be redirected to that page.
                options.AccessDeniedPath = "/AccessDenied"; // When you doesn't have the right role.
            });


            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            // ACCESS DBCONTEXT AND ROLE MANAGER USING A SCOPE
            /*using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var products = context.Products.ToList();
                context.Products.RemoveRange(products);
                var roles = context.Roles.ToList();
                context.Roles.RemoveRange(roles);

                context.SaveChanges();
            }*/

            app.Run();
        }
    }
}