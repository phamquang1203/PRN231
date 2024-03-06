using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize(Roles = "ADMIN")]

    public class BooksController : ODataController
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [EnableQuery]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                //IEnumerable<Book> books = await bookRepository.GetBooksAsync();
                return StatusCode(200, await bookRepository.GetBooksAsync());
            }   
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [EnableQuery]
        public async Task<IActionResult> GetBook([FromODataUri] int key)
        {
            try
            {
                Book book = await bookRepository.GetBookAsync(key);
                if (book == null)
                {
                    return StatusCode(404, "Book is not existed!!");
                }
                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [EnableQuery]
        public async Task<IActionResult> PutBook([FromODataUri] int key, Book book)
        {
            if (key != book.BookId)
            {
                return StatusCode(400, "ID is not the same!!");
            }
            try
            {
                await bookRepository.UpdateBookAsync(book);
                return StatusCode(204, "Update successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [EnableQuery]
        public async Task<IActionResult> PostBook(Book book)
        {
            try
            {
                Book createdBook = await bookRepository.AddBookAsync(book);
                return StatusCode(201, createdBook);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [EnableQuery]
        public async Task<IActionResult> DeleteBook([FromODataUri] int key)
        {
            try
            {
                await bookRepository.DeleteBookAsync(key);
                return StatusCode(204, "Delete successfully!");
            }
            catch (Exception ex ) {
                return BadRequest();
            }
        }
    }
}
