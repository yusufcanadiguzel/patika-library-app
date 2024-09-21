using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Book book)
        {
            _bookService.AddBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult Edit([FromRoute(Name = "id")] int id)
        {
            var book = _bookService.GetOneBookById(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _bookService.UpdateBook(book);

            return RedirectToAction("Index");
        }
    }
}
