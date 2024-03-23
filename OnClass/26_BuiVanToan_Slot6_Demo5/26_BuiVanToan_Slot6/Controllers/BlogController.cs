using _26_BuiVanToan_Slot6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _26_BuiVanToan_Slot6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public IActionResult Get()
        {
            var blogs = new List<Blog>();
            var blogsPosts = new List<BlogPost>();
            blogsPosts.Add(new BlogPost
            {
                Title = "Content negotiation in  .NetCore",
                MetaDescription = "Content negotiation is one of",
                Published = true,
            });
            blogs.Add(new Blog
            {
                BlogPosts = blogsPosts,
                Description= " Nice try",
                Name= "Supper Human",
            });
                return Ok(blogs);

               
            
        }
    }
}
