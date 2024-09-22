using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.InMemoryDatabase;
using System.Linq.Expressions;

namespace LibraryApp.DataAccess.Concrete.InMemory
{
    public class InMemoryBookDao : IBookDao
    {
        public void Add(Book entity)
        {
            var index = InMemoryDbContext.Books.Count + 1;

            entity.Id = index;

            InMemoryDbContext.Books.Add(entity);
        }

        public void Delete(Book entity)
        {
            InMemoryDbContext.Books.Remove(entity);
        }

        public Book Get(Expression<Func<Book, bool>> expression)
        {
            var book = InMemoryDbContext.Books.Where(expression.Compile()).SingleOrDefault();

            return book;
        }

        public List<Book> GetAll(Expression<Func<Book, bool>>? expression = null)
        {
            var books = expression is null
                ? InMemoryDbContext.Books.ToList()
                : InMemoryDbContext.Books.Where(expression.Compile()).ToList();

            return books;
        }

        public void SoftDelete(bool isDeleted, int id)
        {
            var deletedEntity = Get(a => a.Id.Equals(id));

            deletedEntity.IsDeleted = isDeleted;
        }

        public void Update(Book entity)
        {
            var updatedEntity = Get(b => b.Id.Equals(entity.Id));

            updatedEntity.Title = entity.Title;
            updatedEntity.AuthorId = entity.AuthorId;
            updatedEntity.Genre = entity.Genre;
            updatedEntity.PublishDate = entity.PublishDate;
            updatedEntity.ISBN = entity.ISBN;
            updatedEntity.CopiesAvailable = entity.CopiesAvailable;
        }
    }
}
