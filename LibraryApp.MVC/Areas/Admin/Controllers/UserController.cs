using LibraryApp.Business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var users = _serviceManager.UserService.GetAllUsers();

            return View(users);
        }
    }
}
