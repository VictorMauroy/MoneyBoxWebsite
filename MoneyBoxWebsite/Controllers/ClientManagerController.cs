using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoneyBoxWebsite.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClientManagerController : Controller
    {
        private IUserRepository _userRepository;
        public ClientManagerController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await _userRepository.GetAllClients();
            IEnumerable<Client> orderedClients = from Client client in clients
                                                  orderby client.Id descending
                                                  select client; // Show the last created accounts first.
            return View(orderedClients);
        }
    }
}
