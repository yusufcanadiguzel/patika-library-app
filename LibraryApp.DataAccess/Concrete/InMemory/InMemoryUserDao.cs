using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using LibraryApp.InMemoryDatabase;
using System.Linq.Expressions;

namespace LibraryApp.DataAccess.Concrete.InMemory
{
    public class InMemoryUserDao : IUserDao
    {
        public void Add(User entity)
        {
            var index = InMemoryDbContext.Users.Count + 1;

            entity.Id = index;

            InMemoryDbContext.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            InMemoryDbContext.Users.Remove(entity);
        }

        public User Get(Expression<Func<User, bool>> expression)
        {
            var user = InMemoryDbContext.Users.SingleOrDefault(expression.Compile());

            return user;
        }

        public List<User> GetAll(Expression<Func<User, bool>>? expression = null)
        {
            var products = expression is null
                ? InMemoryDbContext.Users.ToList()
                : InMemoryDbContext.Users.Where(expression.Compile()).ToList();

            return products;
        }

        public void SoftDelete(bool isDeleted, int id)
        {
            var deletedEntity = Get(a => a.Id.Equals(id));

            deletedEntity.IsDeleted = isDeleted;
        }

        public void Update(User entity)
        {
            var updatedEntity = Get(u => u.Id.Equals(entity.Id));

            updatedEntity.FullName = entity.FullName;
            updatedEntity.Email = entity.Email;
            updatedEntity.PhoneNumber = entity.PhoneNumber;
        }

    }
}
