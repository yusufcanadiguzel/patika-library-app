namespace LibraryApp.Business.Contracts
{
    public interface IServiceManager
    {
        // Author manager
        public IAuthorService AuthorService { get; }
        // Book manager
        public IBookService BookService { get; }
        // User manager
        public IUserService UserService { get; }
    }
}