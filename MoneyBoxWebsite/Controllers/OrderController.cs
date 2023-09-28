using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoneyBoxWebsite.Models;
using Newtonsoft.Json;

namespace MoneyBoxWebsite.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [HttpGet, Route("/myorders")]
        public IActionResult MyOrders()
        {
            List<ProductOrder> orders = new List<ProductOrder>();
            
            if (!HttpContext.Session.GetString("ShippingCart").IsNullOrEmpty())
            {
                string shippingCartJson = HttpContext.Session.GetString("ShippingCart");
                List<ProductOrder> ordersList = JsonConvert.DeserializeObject<List<ProductOrder>>(shippingCartJson);
                
                orders = ordersList;
                Console.WriteLine("\n\n Seeding list of products \n\n");
            }
            
            return View(orders);
        }
    }
}