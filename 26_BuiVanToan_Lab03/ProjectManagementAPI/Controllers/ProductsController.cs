using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_BusinessObjects;
using _26_BuiVanToan_Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        //GET: api/Products
        [HttpGet]
  
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();
                // POST: ProductsController/Products
               [HttpPost]
        public IActionResult PostProduct(ProductRequest productReq)
                {
            var product = new Product
            {
                ProductName = productReq.ProductName,
                CategoryId = productReq.CategoryId,
                UnitPrice = productReq.UnitPrice,
                UnitsInStock = productReq.UnitsInstock,
            };
            repository.SaveProduct(product);
            return NoContent();
        }
        // GET: ProductsController/Delete/5
        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
                {
            var p = repository.GetProductById(id); 
            if (p == null)
            return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, ProductRequest p)
                {
            var pTmp = repository.GetProductById(id);   
            if(pTmp == null)
                return NotFound();
            pTmp.ProductName = p.ProductName;
            pTmp.UnitPrice = p.UnitPrice;
            pTmp.UnitsInStock =p.UnitsInstock;
            pTmp.CategoryId = p.CategoryId;

            repository.UpdateProduct(pTmp);
            return NoContent();
                }
            }
}
