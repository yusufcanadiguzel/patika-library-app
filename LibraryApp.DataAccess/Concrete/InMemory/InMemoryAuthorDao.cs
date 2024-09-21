using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.InMemoryDatabase;
using System.Linq.Expressions;

namespace LibraryApp.DataAccess.Concrete.InMemory
{
    public class InMemoryAuthorDao : IAuthorDao
    {
        public void Add(Author entity)
        {
            var index = InMemoryDbContext.Authors.Count + 1;

            entity.Id = index;

            InMemoryDbContext.Authors.Add(entity);
        }

        public void Delete(Author entity)
        {
            InMemoryDbContext.Authors.Remove(entity);
        }

        public Author Get(Expression<Func<Author, bool>> expression)
        {
            var author = InMemoryDbContext.Authors.Where(expression.Compile()).FirstOrDefault();

            return author;
        }

        public List<Author> GetAll(Expression<Func<Author, bool>>? expression = null)
        {
            var authors = InMemoryDbContext.Authors.Where(expression.Compile()).ToList();

            return authors;
        }

        public void Update(Author entity)
        {
            var updatedEntity = Get(a => a.Id.Equals(entity.Id));

            updatedEntity.FirstName = entity.FirstName;
            updatedEntity.LastName = entity.LastName;
            updatedEntity.DateOfBirth = entity.DateOfBirth;
        }
    }
}
