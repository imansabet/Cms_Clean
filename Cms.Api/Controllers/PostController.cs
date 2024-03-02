using Cms.Core.Interfaces.Repository;
using Cms.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : BaseController
    {
        private readonly IMediator _mediatR;

        public PostController(IMediator mediatR )
        {
            _mediatR = mediatR;
        }

        [HttpGet("GetLatestPost")]
        public async Task<IActionResult> GetLatestPost() 
        {
            var query = new GetLatestPostsQuery();
            var result = await _mediatR.Send(query);
            return CustomOk(result);
        }
        
    }
}
