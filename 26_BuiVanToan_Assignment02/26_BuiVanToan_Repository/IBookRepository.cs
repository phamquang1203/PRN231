using _26_BuiVanToan_BusinessObject;

namespace _26_BuiVanToan_Repository
{
    public interface IBookRepository
    {

        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int bookId);
        Task<Book> AddBookAsync(Book newBook);
        Task<Book> UpdateBookAsync(Book updatedBook);
        Task DeleteBookAsync(int bookId);

    }
}
