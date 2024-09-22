using LibraryApp.Business.Contracts;

namespace LibraryApp.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public ServiceManager(IAuthorService authorService, IBookService bookService, IUserService userService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _userService = userService;
        }

        public IAuthorService AuthorService => _authorService;

        public IBookService BookService => _bookService;

        public IUserService UserService => _userService;
    }
}
