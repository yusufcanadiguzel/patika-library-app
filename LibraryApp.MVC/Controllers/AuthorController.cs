using LibraryApp.Business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AuthorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var authors = _serviceManager.AuthorService.GetAllAuthors();

            return View(authors);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var author = _serviceManager.AuthorService.GetOneAuthorById(id);

            return View(author);
        }
    }
}
