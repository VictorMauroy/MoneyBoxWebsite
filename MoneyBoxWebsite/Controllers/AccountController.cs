using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Models.ViewModels;
using System.Security.Claims;

namespace MoneyBoxWebsite.Controllers
{
    public enum Theme
    {
        Default,
        Dark,
        Blue
    }

    public class AccountController : Controller
    {
        private SignInManager<Client> _signInManager;
        private UserManager<Client> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<Client> signInManager, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Too bad");
                return View();
            }

            Client client = new Client
            {
                FirstName = registerModel.FirstName,
                Name = registerModel.LastName,
                Email = registerModel.Email,
                Address = registerModel.Address,
                PhoneNumber = registerModel.PhoneNumber,
                UserName = registerModel.Username,
                CurrentTheme = Enum.GetName(typeof(Theme), 0)
            };

            


            /******************        REQUIRE PASSWORD HASHING ?      ******************/
            IdentityResult result = await _userManager.CreateAsync(client, registerModel.Password);
            
            
            
            
            if (result.Succeeded)
            {
                Console.WriteLine("User created !");
                await _userManager.AddToRoleAsync(client, "Client"); //Client has now the role CLIENT
                
                Microsoft.AspNetCore.Identity.SignInResult resultSignIn = 
                    await _signInManager.PasswordSignInAsync(
                        registerModel.Username, 
                        registerModel.Password, 
                        false,
                        false
                    );

                if (resultSignIn.Succeeded)
                {
                    Console.WriteLine("Signed in !");
                    return RedirectToAction("Index", "Products");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }


    }
}
