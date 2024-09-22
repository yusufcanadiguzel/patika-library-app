using LibraryApp.Entities.Contract;
using System.Linq.Expressions;

namespace LibraryApp.DataAccess.Contracts
{
    // Base repository class
    public interface IEntityRepository<T>
        where T: class, IEntity, new()
    {
        // Get all entities or filtered entities
        List<T> GetAll(Expression<Func<T, bool>>? expression = null);

        // Get entity by condition
        T Get(Expression<Func<T, bool>> expression);

        // Add entity
        void Add(T entity);

        //Update entity
        void Update(T entity);

        //Delete entity
        void Delete(T entity);

        //Soft delete entity
        void SoftDelete(bool isDeleted, int id);
    }
}
