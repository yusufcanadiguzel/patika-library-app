using LibraryApp.Entities.Contract;

namespace LibraryApp.Entities.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
