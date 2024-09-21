using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Contracts
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetOneBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void RemoveBook(Book book);
    }
}
