using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _26_BuiVanToan_Repository;
using _26_BuiVanToan_Repository.impl;
using eStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace eStoreAPI.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository repository = new CategoryRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => repository.GetCategories();

        [HttpGet("id")]
        public ActionResult<Category> GetCategoryById(int id) => repository.GetCategoryById(id);

        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            repository.SaveCategory(category);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteCategory(int id)
        {
            var c = repository.GetCategoryById(id);
            if (c == null)
            {
                return NotFound();
            }
            repository.DeleteCategory(c);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult PutCategory(int id, Category category)
        {
            var cTmp = repository.GetCategoryById(id);
            if (cTmp == null)
            {
                return NotFound();
            }

            cTmp.CategoryName = category.CategoryName;

            repository.UpdateCategory(cTmp);
            return NoContent();
        }
    }
}
