namespace LibraryApp.Business.Contracts
{
    public interface IServiceManager
    {
        public IAuthorService AuthorService { get; }
        public IBookService BookService { get; }
        public IUserService UserService { get; }
    }
}