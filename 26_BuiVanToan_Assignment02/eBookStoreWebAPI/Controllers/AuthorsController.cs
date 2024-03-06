using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData;

namespace eBookStoreWebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize (Roles ="ADMIN")]
    public class AuthorsController : ODataController
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            try
            {
                return StatusCode(200, await authorRepository.GetAuthorsAsync());
            }
            catch (Exception ex)    
            {
                return BadRequest(ex);
            }
        }
        [EnableQuery]
        public async Task<IActionResult> Get([FromODataUri] int key)
        {
            try
            {
                Author author = await authorRepository.GetAuthorAsync(key);
                if (author == null)
                {
                    return StatusCode(404, "Author is not existed!!");
                }
                return StatusCode(200, author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [EnableQuery]
        public async Task<IActionResult> Put([FromODataUri] int key, Author author)
        {
            if (key != author.AuthorId)
            {
                return StatusCode(400, "ID is not the same!!");
            }
            try
            {
                await authorRepository.UpdateAuthorAsync(author);
                return StatusCode(204, "Update successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [EnableQuery]
        public async Task<IActionResult> Post(Author author)
        {

            try
            {
                Author createdAuthor = await authorRepository.AddAuthorAsync(author);
                return StatusCode(201, createdAuthor);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            try
            {
                await authorRepository.DeleteAuthorAsync(key);
                return StatusCode(204, "Delete successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
