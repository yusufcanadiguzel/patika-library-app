using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;
using LibraryApp.InMemoryDatabase;

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
            var authors = _authorDao.GetAll(a => a.IsDeleted.Equals(false));

            return authors;
        }

        public Author GetOneAuthorById(int id)
        {
            var author = InMemoryDbContext.Authors.Where(a => a.Id.Equals(id)).SingleOrDefault();

            return author;
        }

        // Set author to passive
        public void SoftDeleteAuthor(AuthorSoftDeleteDto authorSoftDeleteDto)
        {
            _authorDao.SoftDelete(authorSoftDeleteDto.IsDeleted, authorSoftDeleteDto.Id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorDao.Update(author);
        }
    }
}
