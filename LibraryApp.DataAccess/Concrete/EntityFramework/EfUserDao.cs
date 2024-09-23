using LibraryApp.DataAccess.Concrete.EntityFramework.Contexts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;

namespace LibraryApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDao : EfEntityRepositoryBase<User, EfLibraryAppDbContext>, IUserDao
    {
    }
}
