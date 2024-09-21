using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataAccess.Contracts
{
    public interface IBookDao : IEntityRepository<Book>
    {
    }
}
