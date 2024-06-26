﻿using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;

namespace _26_BuiVanToan_Repository
{
    public class BookRepository : IBookRepository

    {
        public async Task<Book> AddBookAsync(Book newBook)
   =>await BookDAO.Instance.AddBookAsync(newBook);

        public async Task DeleteBookAsync(int bookId)
    =>await BookDAO.Instance.DeleteBookAsync(bookId);

        public async Task<Book> GetBookAsync(int bookId)
    => await BookDAO.Instance.GetBookAsync(bookId);

        public  async Task<IEnumerable<Book>> GetBooksAsync()
   => await BookDAO.Instance.GetBooksAsync();

        public async Task<Book> UpdateBookAsync(Book updatedBook)
   => await BookDAO.Instance.UpdateBookAsync(updatedBook);
    }
}
