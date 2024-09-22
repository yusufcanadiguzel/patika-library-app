using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Contracts
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetOneUserByEmail(string email);
        bool CheckUserPassword(string password, string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void SoftDeleteUser(bool isDeleted, int id);
    }
}
