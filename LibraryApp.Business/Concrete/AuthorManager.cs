using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDao _authorDao;

        public AuthorManager(IAuthorDao authorDao)
        {
            _authorDao = authorDao;
        }

        public void AddAuthor(Author author)
        {
            _authorDao.Add(author);
        }

        public void DeleteAuthor(Author author)
        {
            _authorDao.Delete(author);
        }

        public List<Author> GetAllAuthors()
        {
            var authors = _authorDao.GetAll();

            return authors;
        }

        public void UpdateAuthor(Author author)
        {
            _authorDao.Update(author);
        }
    }
}
