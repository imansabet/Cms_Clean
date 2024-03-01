using Cms.Core.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepositorty _postRepository;

        public PostController(IPostRepositorty postRepository )
        {
            _postRepository = postRepository;
        }

        [HttpGet("GetLatestPost")]
        public IActionResult GetLatestPost() 
        {
            return Ok(_postRepository.GetLatestPosts(10));
           
        }
        
    }
}
