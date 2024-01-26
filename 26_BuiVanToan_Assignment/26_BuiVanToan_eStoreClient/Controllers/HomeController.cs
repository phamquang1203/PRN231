using _26_BuiVanToan_eStoreClient.Models;
using _26_BuiVanToan_BusinessObject;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using _26_BuiVanToan_eStoreClient.Utils;

namespace _26_BuiVanToan_eStoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";

        public HomeController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7283/api/Member";
        }
        [HttpGet]
        public IActionResult Index()
        {
            string User = HttpContext.Session.GetString("USERNAME");
            if (User == null)
            {
                ////TempData["ErrorMessage"] = "You must login to access this page.";
                return View();
            }
            if (User == "admin@estore.com")
                return RedirectToAction("Index", "Member");
            else if (User != "admin@estore.com")
              return RedirectToAction("Profile", "Member");

            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(_26_BuiVanToan_BusinessObject.Member loginRequest)
        {
            HttpResponseMessage response = await client.GetAsync(MemberApiUrl);
            string stringData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();

            _26_BuiVanToan_BusinessObject.Member admin = new _26_BuiVanToan_BusinessObject.Member
            {
                Email = config["Credentials:Email"],
                Password = config["Credentials:Password"],
      
            };

            List<_26_BuiVanToan_BusinessObject.Member> listMember = JsonSerializer.Deserialize<List<_26_BuiVanToan_BusinessObject.Member>>(stringData, options);
            listMember.Add(admin);
            _26_BuiVanToan_BusinessObject.Member account = listMember.Where(c => c.Email == loginRequest.Email && c.Password == loginRequest.Password).FirstOrDefault();

            if (account != null)
            {
                HttpContext.Session.SetInt32("USERID", account.MemberId);
                HttpContext.Session.SetString("USERNAME", account.Email);
                if (account.Email == "admin@estore.com")
                    return RedirectToAction("Index", "Member");
                else
                    return RedirectToAction("Profile", "Member");
            }
            else
            {
                ViewData["ErrorMessage"] = "Email or password is invalid.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            string Role = HttpContext.Session.GetString("ROLE");
            if (Role == "Admin")
                return RedirectToAction("Index", "Member");
            else if (Role == "Customer")
                return RedirectToAction("Profile", "Member");

            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(_26_BuiVanToan_BusinessObject.Member memberRequest)
        {
            _26_BuiVanToan_BusinessObject.Member member = await ApiHandler.DeserializeApiResponse<_26_BuiVanToan_BusinessObject.Member>(MemberApiUrl + "/Email/" + memberRequest.Email, HttpMethod.Get);
            if (memberRequest.Email.Equals("admin@estore.com") ||
                (member != null && member.MemberId != 0))
            {
                ViewData["ErrorMessage"] = "Email already exists.";
                return View("Register");
            }

            await ApiHandler.DeserializeApiResponse(MemberApiUrl, HttpMethod.Post, memberRequest);

            ViewData["SuccessMessage"] = "Register new account successfully.";
            return View("Index");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
