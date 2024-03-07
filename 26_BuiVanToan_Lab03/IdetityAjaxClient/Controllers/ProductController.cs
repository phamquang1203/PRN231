using _26_BuiVanToan_BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace IdetityAjaxClient.Controllers
{

    public class ProductController : Controller
    {

    
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }
        // GET: ProductController/Details/5 
        public ActionResult Details(int id)
        { return View();
        }
        // GET: ProductController/Create 

        public ActionResult Create()
        {
            return View();
        }
// POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(IFormCollection collection)
                {
        return View();
                }


        public ActionResult Edit(int id)
                {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the product in the database
     
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

     
    }
}
