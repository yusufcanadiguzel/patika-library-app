using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddUser(User user)
        {
            _userDao.Add(user);
        }

        public void DeleteUser(User user)
        {
            _userDao.Delete(user);
        }

        public List<User> GetAllUsers(Expression<Func<User, bool>>? expression = null)
        {
            var users = _userDao.GetAll(expression);

            return users;
        }

        public User GetUser(Expression<Func<User, bool>> expression)
        {
            var user = _userDao.Get(expression);

            return user;
        }

        public void UpdateUser(User user)
        {
            _userDao.Update(user);
        }
    }
}
