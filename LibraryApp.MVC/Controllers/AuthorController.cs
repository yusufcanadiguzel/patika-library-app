using AutoMapper;
using LibraryApp.Business.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public AuthorController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var authors = _serviceManager.AuthorService.GetAllAuthors();

            return View(authors);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var author = _serviceManager.AuthorService.GetOneAuthorById(id);

            var viewModel = _mapper.Map<AuthorDetailsViewModel>(author);

            return View(viewModel);
        }
    }
}
