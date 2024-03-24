using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eStoreAPI.Models;
using _26_BuiVanToan_BusinessObject;
namespace eStoreClient.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
        public async Task<IActionResult> Report(string startDate, string endDate)
        {
           

            return View();
        }
    }
}
