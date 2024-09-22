using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Author author)
        {
            _serviceManager.AuthorService.AddAuthor(author);

            return RedirectToAction("Index");
        }

        public IActionResult Edit([FromRoute(Name = "id")] int id)
        {
            var author = _serviceManager.AuthorService.GetOneAuthorById(id);

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Author author)
        {
            _serviceManager.AuthorService.UpdateAuthor(author);

            return RedirectToAction("Index");
        }

        public IActionResult SoftDelete([FromRoute(Name = "id")] int id)
        {
            var authorSoftDeleteDto = new AuthorSoftDeleteDto() { IsDeleted = true, Id = id };

            return View(authorSoftDeleteDto);
        }

        [HttpPost]
        public IActionResult SoftDelete([FromForm] AuthorSoftDeleteDto authorSoftDeleteDto)
        {
            _serviceManager.AuthorService.SoftDeleteAuthor(authorSoftDeleteDto);

            return RedirectToAction("Index");
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var author = _serviceManager.AuthorService.GetOneAuthorById(id);

            return View(author);
        }
    }
}
