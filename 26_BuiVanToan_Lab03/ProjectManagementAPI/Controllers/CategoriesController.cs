using _26_BuiVanToan_BusinessObjects;
using _26_BuiVanToan_Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => repository.GetCategories();
    
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var prod = repository.GetCategoryById(id);
        if (prod == null) return NotFound("Product not found.");

        return Ok(prod);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Product prod)
    {
        if (prod == null) return BadRequest("Information is required");

        if (ModelState.IsValid) repository.SaveProduct(prod);
        else return BadRequest("Invalid");

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Product prod)
    {
        if (prod == null) return BadRequest("information is required");

        var p = repository.GetProductById(id);
        if (p == null) return NotFound("Product not found");

        repository.UpdateProduct(prod);
        return Ok(prod);
    }


}
}
