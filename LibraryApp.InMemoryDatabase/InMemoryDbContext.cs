using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InMemoryDatabase
{
    public static class InMemoryDbContext
    {
        public static List<User> Users { get; set; }
        public static List<Author> Authors { get; set; }
        public static List<Book> Books { get; set; }

        static InMemoryDbContext()
        {
            Users = new List<User>();
            Authors = new List<Author>();
            Books = new List<Book>();
        }
    }
}
