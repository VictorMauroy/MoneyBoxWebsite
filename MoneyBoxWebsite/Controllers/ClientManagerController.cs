using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Repositories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.Build.Framework;
using Microsoft.IdentityModel.Tokens;

namespace MoneyBoxWebsite.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClientManagerController : Controller
    {
        private IUserRepository _userRepository;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<Client> _userManager;
        public ClientManagerController(
            IUserRepository userRepository, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<Client> userManager) 
        { 
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await _userRepository.GetAllClients();
            IEnumerable<Client> orderedClients = from Client client in clients
                                                  orderby client.Id descending
                                                  select client; // Show the last created accounts first.
            return View(orderedClients);
        }


        public async Task<IActionResult> Manage(Guid id)
        {
            Client client = await _userRepository.GetClientById(id);

            var roleNames = _roleManager.Roles.Select(r => r.Name).OrderBy(r => r).ToList();
            ViewBag.RolesList = roleNames;

            List<string> currentRole = (List<string>) await _userManager.GetRolesAsync(client);
            ViewBag.CurrentRole = currentRole.Count > 0 ? currentRole[0] : "";

            return View(client);
        }

        /*[HttpPost]
        public async Task<IActionResult> ChangeActivationState()
        {

        }*/

        [HttpPost]
        public async Task<IActionResult> ChangeRole(Guid id)
        {
            string newRole = Request.Form["SelectedRole"];
            string previousRole = Request.Form["PreviousRole"];
            
            Client client = await _userRepository.GetClientById(id);

            if(previousRole != "")
                await _userManager.RemoveFromRoleAsync(client, previousRole);
            
            if(await _roleManager.RoleExistsAsync(newRole))
                await _userManager.AddToRoleAsync(client, newRole);

            return RedirectToAction("Manage", new { id });
        }
    }
}
