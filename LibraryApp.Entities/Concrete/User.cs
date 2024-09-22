using LibraryApp.Entities.Contract;

namespace LibraryApp.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
