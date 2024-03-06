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

    public class BookAuthorsController : ODataController
    {
        private readonly IBookAuthorRepository bookAuthorRepository;

        public BookAuthorsController(IBookAuthorRepository bookAuthorRepository)
        {
            this.bookAuthorRepository = bookAuthorRepository;
        }
        [EnableQuery]
        public async Task<IActionResult> GetBookAuthors()
        {
            try
            {
                return StatusCode(200, await bookAuthorRepository.GetBookAuthorsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [EnableQuery]
        public async Task<IActionResult> GetBookAuthor([FromODataUri] int keyAuthorId, [FromODataUri] int keyBookId)

        {
            try
            {
                BookAuthor bookAuthor = await bookAuthorRepository.GetBookAuthorAsync(keyAuthorId, keyBookId);
                if (bookAuthor == null)
                {
                    return StatusCode(404, "BookAuthor is not existed!!");
                }
                return StatusCode(200, bookAuthor);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
