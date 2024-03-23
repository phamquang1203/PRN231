using _26_BuiVanToan_BusinessObject;

using _26_BuiVanToan_DataAccess;

using _26_BuiVanToan_Repository;
using _26_BuiVanToan_Repository.impl;
using eStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
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
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult PostProduct(PostProduct productReq)
        {
            var product = new Product
            {
                ProductName = productReq.ProductName,
                CategoryID = productReq.CategoryID,
                UnitPrice = productReq.UnitPrice,
                UnitsInStock = productReq.UnitsInStock,
  
            };
            repository.SaveProduct(product);
                return NoContent();
        }
        //[Authorize(Roles = UserRoles.Admin)]
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
        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, PostProduct productReq)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }

            pTmp.ProductName = productReq.ProductName;
            pTmp.UnitPrice =productReq.UnitPrice;
            pTmp.UnitsInStock = productReq.UnitsInStock;
            pTmp.CategoryID= productReq.CategoryID;

            repository.UpdateProduct(pTmp);
            return NoContent();
        }

    }
}
