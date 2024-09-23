using FluentValidation;
using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.MVC.Areas.Admin.Controllers
{
    [Area (areaName: "Admin")]
    public class BookController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IValidator<Book> _validator;

        public BookController(IServiceManager serviceManager, IValidator<Book> validator)
        {
            _serviceManager = serviceManager;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var books = _serviceManager.BookService.GetAllBooks();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(items: _serviceManager.AuthorService.GetAllAuthors(), selectedValue: "1", dataTextField: "FullName", dataValueField: "Id");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Book book)
        {
            var validationResult = _validator.Validate(book);

            if (!validationResult.IsValid)
            {
                ViewBag.Authors = new SelectList(items: _serviceManager.AuthorService.GetAllAuthors(), selectedValue: "1", dataTextField: "FullName", dataValueField: "Id");

                validationResult.Errors.ForEach(e => ModelState.AddModelError("", e.ErrorMessage));

                return View();
            }

            _serviceManager.BookService.AddBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult Edit([FromRoute(Name = "id")] int id)
        {
            ViewBag.Authors = new SelectList(items: _serviceManager.AuthorService.GetAllAuthors(), selectedValue: "1", dataTextField: "FullName", dataValueField: "Id");

            var book = _serviceManager.BookService.GetOneBookById(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var validationResult = _validator.Validate(book);

            if (!validationResult.IsValid)
            {
                ViewBag.Authors = new SelectList(items: _serviceManager.AuthorService.GetAllAuthors(), selectedValue: "1", dataTextField: "FullName", dataValueField: "Id");

                validationResult.Errors.ForEach(e => ModelState.AddModelError("", e.ErrorMessage));

                return View(book);
            }

            _serviceManager.BookService.UpdateBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult SoftDelete([FromRoute(Name = "id")] int id)
        {
            var bookSoftDeleteDto = new BookSoftDeleteDto() { IsDeleted = true, Id = id };

            return View(bookSoftDeleteDto);
        }

        [HttpPost]
        public IActionResult SoftDelete([FromForm] BookSoftDeleteDto bookSoftDeleteDto)
        {
            _serviceManager.BookService.SoftDeleteBook(bookSoftDeleteDto);

            return RedirectToAction("Index");
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var book = _serviceManager.BookService.GetOneBookById(id);

            return View(book);
        }
    }
}
