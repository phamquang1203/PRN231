using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementAPI.Controllers
{

    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductRepository repository = new ProductRepository();

        //GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        //GET: api/products/id
        [HttpGet("{id:int}")]
        public ActionResult<Product> GetProduct(int id) => repository.GetProductById(id);

        [HttpPost]
        public IActionResult PostProduct(ProductRequest productReq)
        {
            var product = new Product
            {
                ProductName = productReq.ProductName,
                CategoryId = productReq.CategoryId,
                UnitPrice = productReq.UnitPrice,
                UnitsInstock = productReq.UnitsInstock,
            };
            repository.SaveProduct(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductRequest productReq)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }

            pTmp.ProductName = productReq.ProductName;
            pTmp.UnitPrice = productReq.UnitPrice;
            pTmp.UnitsInstock = productReq.UnitsInstock;
            pTmp.CategoryId = productReq.CategoryId;

            repository.UpdateProduct(pTmp);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
                return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }


    }
}
