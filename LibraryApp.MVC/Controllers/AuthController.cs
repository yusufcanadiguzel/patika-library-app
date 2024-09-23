using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.MVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Security.Claims;

namespace LibraryApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IDataProtector _dataProtector;

        public AuthController(IDataProtectionProvider dataProtectionProvider, IServiceManager serviceManager)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("security");
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(signUpViewModel);
            }

            var user = _serviceManager.UserService.GetOneUserByEmail(signUpViewModel.Email);

            if (user is not null)
            {
                ViewBag.Error = "User already exits.";
                return View(signUpViewModel);
            }

            _serviceManager.UserService.AddUser(new User
            {
                Email = signUpViewModel.Email,
                Password = _dataProtector.Protect(signUpViewModel.Password)
            });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            var user = _serviceManager.UserService.GetOneUserByEmail(signInViewModel.Email);

            if (user is null)
            {
                ViewBag.Error = "User not found.";

                return View(signInViewModel);
            }

            var rawPassword = _dataProtector.Unprotect(user.Password);

            if (rawPassword == signInViewModel.Password)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("id", user.Id.ToString()));

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var autProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(48)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autProperties);
            }
            else
            {
                ViewBag.Error = "User or password is incorrect.";
                return View(signInViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
