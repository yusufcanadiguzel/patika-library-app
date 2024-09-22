using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public BookController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var books = _serviceManager.BookService.GetAllBooks();

            return View(books);
        }

        public IActionResult Get([FromRoute (Name = "id")] int id)
        {
            var book = _serviceManager.BookService.GetOneBookById(id);

            return View(book);
        }
    }
}
