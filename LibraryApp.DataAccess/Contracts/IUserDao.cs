using LibraryApp.Entities.Concrete;

namespace LibraryApp.DataAccess.Contracts
{
    public interface IUserDao : IEntityRepository<User>
    {
    }
}
