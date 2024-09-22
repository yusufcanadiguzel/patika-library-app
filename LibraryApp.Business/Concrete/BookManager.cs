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

        public Book GetOneBookById(int id)
        {
            var book = _bookDao.Get(b => b.Id.Equals(id));

            return book;
        }

        public void RemoveBook(Book book)
        {
            _bookDao.Update(book);
        }

        public void SoftDeleteUser(bool isDeleted, int id)
        {
            _bookDao.SoftDelete(isDeleted, id);
        }

        public void UpdateBook(Book book)
        {
            _bookDao.Update(book);
        }
    }
}
