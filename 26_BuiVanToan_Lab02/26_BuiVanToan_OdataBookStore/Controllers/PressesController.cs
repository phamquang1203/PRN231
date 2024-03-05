using _26_BuiVanToan_OdataBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace _26_BuiVanToan_OdataBookStore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PressesController : ODataController
    {
        private BookStoreContext db;

        public PressesController(BookStoreContext context)
        {
            db    = context;
            if (context.Books.Count() == 0)
            {
                foreach (var book in DataSource.GetBooks())
                {
                    context.Books.Add(book);
                    context.Presses.Add(book.Press);
                }
                context.SaveChanges();
            }
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(db.Presses);
        }
    }
}
