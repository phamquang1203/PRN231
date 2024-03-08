using _26_BuiVanToan_BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IdetityAjaxClient.Controllers
{

    public class ProductController : Controller
    {
        private readonly HttpClient client;
        private string api;
        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            api = "https://localhost:7128/api/products/";
        }
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


        public async Task<ActionResult> EditAsync(int id)
        {
            //HttpResponseMessage res = await client.GetAsync(api + id);

            //var data = await res.Content.ReadAsStringAsync();
            //var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            //var obj = JsonSerializer.Deserialize<Product>(data, opt);
            //await SetCategoryList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            //if (id != product.ProductId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    // Update the product in the database
     
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        //private async Task SetCategoryList()
        //{
        //    HttpResponseMessage res = await client.GetAsync("https://localhost:44357/api/categories");

        //    var data = await res.Content.ReadAsStringAsync();
        //    var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        //    var obj = JsonSerializer.Deserialize<IEnumerable<Category>>(data, opt);
        //    ViewData["cate"] = new SelectList(obj, "CategoryId", "CategoryName");
        //}
    }
}
