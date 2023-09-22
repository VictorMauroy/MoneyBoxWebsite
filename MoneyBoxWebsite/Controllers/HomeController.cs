using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoneyBoxWebsite.Data;
using MoneyBoxWebsite.Models;
using System.Diagnostics;

namespace MoneyBoxWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _ctx;
        private RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext ctx, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this._ctx = ctx;
            this._roleManager = roleManager;
        }

        public /*async Task<IActionResult>*/ IActionResult Index()
        {
        /*  await DataSeeder.SeedProducts(_ctx);
            await DataSeeder.SeedRoles(_roleManager);
            await _ctx.SaveChangesAsync();*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}