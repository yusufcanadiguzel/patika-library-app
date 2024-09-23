namespace LibraryApp.Entities.Contract
{
    // Type safety object
    public interface IEntity
    {
        public bool IsDeleted { get; set; }
    }
}
