using LibraryApp.Business.Contracts;
using LibraryApp.DataAccess.Contracts;
using LibraryApp.Entities.Concrete;

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

        public bool CheckUserPassword(string password, string email)
        {
            var user = GetOneUserByEmail(email);

            var result = password.ToLower().Equals(user.Password.ToLower());

            return result;
        }

        public void DeleteUser(User user)
        {
            _userDao.Delete(user);
        }

        public List<User> GetAllUsers()
        {
            var users = _userDao.GetAll();

            return users;
        }

        public User GetOneUserByEmail(string email)
        {
            var user = _userDao.Get(u => u.Email.ToLower().Equals(email.ToLower()));

            return user;
        }

        public void SoftDeleteUser(bool isDeleted, int id)
        {
            _userDao.SoftDelete(isDeleted, id);
        }

        public void UpdateUser(User user)
        {
            _userDao.Update(user);
        }
    }
}
