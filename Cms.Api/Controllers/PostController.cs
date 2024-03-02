using Cms.Core.Commands;
using Cms.Core.Interfaces.Repository;
using Cms.Core.Queries;
using Cms.Core.ViewModels;
using Cms.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [HttpPost]
        public async Task<IActionResult> Post(PostAddVm post)
        {
            var command = new PostAddCommand 
            {
                Content = post.Content,
                Title = post.Title,
            };
            var result = await _mediatR.Send(command);
            return CustomOk(result);
        }

    }
}
