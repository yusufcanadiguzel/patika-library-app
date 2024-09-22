using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;

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
            var books = _bookDao.GetAll(b => b.IsDeleted.Equals(false));

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

        // Set book to passive
        public void SoftDeleteBook(BookSoftDeleteDto bookSoftDeleteDto)
        {
            _bookDao.SoftDelete(bookSoftDeleteDto.IsDeleted, bookSoftDeleteDto.Id);
        }

        public void UpdateBook(Book book)
        {
            _bookDao.Update(book);
        }
    }
}
