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

    [Authorize]
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

        #region Register

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
                return View();
            }

            //I shouldn't make that, I'll try updating that later
            string address =
                registerModel.StreetNumber + " " +
                registerModel.StreetName + " " +
                registerModel.PostalCode + " " +
                registerModel.City + ", " +
                registerModel.Country;

            Client client = new Client
            {
                FirstName = registerModel.FirstName,
                Name = registerModel.LastName,
                Email = registerModel.Email,
                Address = address,
                PhoneNumber = registerModel.PhoneNumber,
                UserName = registerModel.Username,
                CurrentTheme = Enum.GetName(typeof(Theme), 0)
            };

            IdentityResult result = await _userManager.CreateAsync(client, registerModel.Password); //Auto Password HASHING
            
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(client, "Client"); //The new user has now the role CLIENT
                
                Microsoft.AspNetCore.Identity.SignInResult resultSignIn = 
                    await _signInManager.PasswordSignInAsync(
                        registerModel.Username, 
                        registerModel.Password, 
                        false,
                        false
                    );

                if (resultSignIn.Succeeded)
                {
                    return RedirectToAction("Index", "Products");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
        #endregion


        #region Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, ValidateAntiForgeryToken, HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            Microsoft.AspNetCore.Identity.SignInResult resultSignIn =
                await _signInManager.PasswordSignInAsync(
                    loginModel.Username,
                    loginModel.Password,
                    loginModel.IsPersistent,
                    false
                );

            if (resultSignIn.Succeeded)
            {
                return RedirectToAction("Index", "Products");
            }

            return View();
        }
        #endregion

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult AccessDenied()
        {
            Console.WriteLine("Access Denied");
            return View();
        }
    }
}
