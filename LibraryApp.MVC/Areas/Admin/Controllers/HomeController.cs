using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
