using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int authorId);
        Task<Author> AddAuthorAsync(Author newAuthor);
        Task<Author> UpdateAuthorAsync(Author updateAuthor);
        Task DeleteAuthorAsync(int authorId);
    }
}
