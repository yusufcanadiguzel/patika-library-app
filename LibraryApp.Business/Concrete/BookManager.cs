using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using System.Linq.Expressions;

namespace LibraryApp.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDao _bookDao;

        public BookManager(IBookDao bookDao)
        {
            _bookDao = bookDao;
        }

        public void AddBook(Book book)
        {
            _bookDao.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            var books = _bookDao.GetAll();

            return books;
        }

        public void RemoveBook(Book book)
        {
            _bookDao.Update(book);
        }

        public void UpdateBook(Book book)
        {
            _bookDao.Update(book);
        }
    }
}
