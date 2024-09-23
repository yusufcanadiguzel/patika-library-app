using FluentValidation;
using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class AuthorController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IValidator<Author> _validator;

        public AuthorController(IServiceManager serviceManager, IValidator<Author> validator)
        {
            _serviceManager = serviceManager;
            _validator = validator;
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
            var validationResult = _validator.Validate(author);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(e => ModelState.AddModelError("", e.ErrorMessage));

                return View();
            }

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
            var validationResult = _validator.Validate(author);

            if (!validationResult.IsValid)
            {
                validationResult.Errors.ForEach(e => ModelState.AddModelError("", e.ErrorMessage));

                return View(author);
            }

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

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
