using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public async Task<Author> AddAuthorAsync(Author newAuthor)
         => await AuthorDAO.Instance.AddAuthorAsync(newAuthor);

        public async Task DeleteAuthorAsync(int authorId)
        => await AuthorDAO.Instance.DeleteAuthorAsync(authorId);

        public async Task<Author> GetAuthorAsync(int authorId)
                 => await AuthorDAO.Instance.GetAuthorAsync(authorId);


        public async Task<IEnumerable<Author>> GetAuthorsAsync()
     => await AuthorDAO.Instance.GetAuthorsAsync();


        public async Task<Author> UpdateAuthorAsync(Author updateAuthor)
      => await AuthorDAO.Instance.UpdateAuthorAsync(updateAuthor);

    }
}
