using LibraryApp.Entities.Concrete;
using LibraryApp.Entities.Dtos;

namespace LibraryApp.Business.Contracts
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetOneAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        void SoftDeleteAuthor(AuthorSoftDeleteDto authorSoftDeleteDto);
    }
}
