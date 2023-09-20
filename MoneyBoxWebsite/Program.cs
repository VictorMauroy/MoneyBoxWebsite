using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MoneyBoxWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var conStrBuilder = new SqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("SQLConnection")
            );

            conStrBuilder.UserID = builder.Configuration["DB_USERID"];
            conStrBuilder.Password = builder.Configuration["DB_PASSWORD"];

            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    conStrBuilder.ConnectionString
                )
            );

            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

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