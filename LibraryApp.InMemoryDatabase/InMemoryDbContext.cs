using LibraryApp.Entities.Concrete;

namespace LibraryApp.InMemoryDatabase
{
    public static class InMemoryDbContext
    {
        public static List<User> Users { get; set; }
        public static List<Author> Authors { get; set; }
        public static List<Book> Books { get; set; }

        static InMemoryDbContext()
        {
            Users = new List<User>(){};
            Authors = new List<Author>();
            Books = new List<Book>();
        }
    }
}
