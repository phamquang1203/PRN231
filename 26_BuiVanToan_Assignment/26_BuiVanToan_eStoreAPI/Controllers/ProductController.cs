using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_BusinessObject.DTO;
using _26_BuiVanToan_DataAccess;
using _26_BuiVanToan_DataAccess.Repositories;
using _26_BuiVanToan_DataAccess.Repositories.impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _26_BuiVanToan_eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();
        [HttpGet("Search/{keyword}")]
        public ActionResult <IEnumerable<Product>> Search (string keyword) => repository.Search(keyword);
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)=> repository.GetProductById(id);
        [HttpPost]
        public IActionResult PostProduct(ProductRequest productReq)
        {
            var product = new Product
            {
                ProductName = productReq.ProductName,
                CategoryId = productReq.CategoryId,
                UnitPrice = productReq.UnitPrice,
                UnitsInStock = productReq.UnitsInStock,
                Weight =  productReq.Weight
            };
            repository.SaveProduct(product);
                return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
    
                repository.DeleteProduct(p);

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
            pTmp.UnitPrice =productReq.UnitPrice;
            pTmp.UnitsInStock = productReq.UnitsInStock;
            pTmp.CategoryId= productReq.CategoryId;
            pTmp.Weight = productReq.Weight;

            repository.UpdateProduct(pTmp);
            return NoContent();
        }

    }
}
