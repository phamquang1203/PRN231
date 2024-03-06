using _26_BuiVanToan_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace _26_BuiVanToan_DataAccess
{
    public class BookAuthorDAO
    {
        private static BookAuthorDAO instance = null;
        private static readonly object instanceLock = new object();
        private BookAuthorDAO() { }
        public static BookAuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookAuthorDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<BookAuthor>> GetBookAuthorsAsync()
        {
            var db = new eStoreContext();
            return await db.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author).ToListAsync();
        }
        public async Task<BookAuthor> GetBookAuthorAsync(int authorId,int bookId )
        {
            var db = new eStoreContext();
            return await db.BookAuthors
                .Include(ba => ba.Book)
                .Include(ba => ba.Author)
                .SingleOrDefaultAsync(ba => ba.AuthorId == authorId && ba.BookId == bookId);
        }
        public async Task<BookAuthor> AddBookAuthorAsync(BookAuthor bookAuthor)
        { 
            CheckBookAuthor(bookAuthor);
            if (await GetBookAuthorAsync(bookAuthor.AuthorId,bookAuthor.BookId)!=null)
            {
                throw new Exception("Exsited");

            }
            var db = new eStoreContext();
            bookAuthor.AuthorOrder = await GetNextAuthorOrder(bookAuthor.AuthorOrder);
            await db.BookAuthors.AddAsync(bookAuthor);
            await db.SaveChangesAsync();
            return bookAuthor;
        }
     public async Task<BookAuthor> UpdateBookAuthorAsync(BookAuthor bookAuthor)
        {
            BookAuthor book = await GetBookAuthorAsync(bookAuthor.AuthorId, bookAuthor.BookId);
            if(book == null)
            {
                    throw new Exception();
            }
            CheckBookAuthor (bookAuthor);
            if(book.AuthorOrder!=bookAuthor.AuthorOrder&& await IsExistedAuthorOrder(bookAuthor.BookId,bookAuthor.AuthorId))
                {
                throw new Exception();
            }
            var db = new eStoreContext();
            db.BookAuthors.Update(bookAuthor);
            await db.SaveChangesAsync();
            return bookAuthor;
        }
        private async Task<bool> IsExistedAuthorOrder(int bookId, int authorOrder)
        {
            var db = new eStoreContext();
            BookAuthor bookAuthor = await db.BookAuthors
                .Where(ba => ba.BookId == bookId && ba.AuthorOrder == authorOrder)
                .FirstOrDefaultAsync();
            return bookAuthor != null;
        }
        private  async Task<int> GetNextAuthorOrder(int bookId)
        {
            var db = new eStoreContext();
            IEnumerable<BookAuthor> bookAuthors = await db.BookAuthors
                .Where(ba => ba.BookId == bookId).ToListAsync();
            if (bookAuthors.Any())
            {
                return bookAuthors.Max(ba => ba.AuthorOrder) + 1;
            }
            return 1; throw new NotImplementedException();
        }
        public async Task DeleteBookAuthorAsync(int authorId, int bookId)
        {
            BookAuthor deletedAuthor = await GetBookAuthorAsync(authorId, bookId);
            if (deletedAuthor == null)
            {
                throw new ApplicationException("BookAuthor does not exist!!");
            }
            var db = new eStoreContext();
            db.BookAuthors.Remove(deletedAuthor);
            await db.SaveChangesAsync();
        }

        private async void CheckBookAuthor(BookAuthor bookAuthor)
        {
            var db = new eStoreContext();
            if (await db.Authors.FindAsync(bookAuthor.AuthorId) == null)
            {
                throw new ApplicationException("Author does not exist!!");
            }
            if (await db.Books.FindAsync(bookAuthor.BookId) == null)
            {
                throw new ApplicationException("Book does not exist!!");
            }
        }
    }
}
