using Cms.Api.Presenter;
using Cms.Core.Commands;
using Cms.Core.Interfaces.Repository;
using Cms.Core.Queries;
using Cms.Core.UseCase.Interfaces;
using Cms.Core.ViewModels;
using Cms.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Cms.Core.Dtos.UseCase.EditPost;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : BaseController
    {
        private readonly IMediator _mediatR;
        private readonly IEditPostUseCase _editPostUseCase;
        private readonly Presenter.PostApiPresenter<EditPostResponse> _postApiPresenter;

        public PostController(IMediator mediatR,IEditPostUseCase editPostUseCase ,PostApiPresenter<EditPostResponse> postApiPresenter)
        {
            _mediatR = mediatR;
            _editPostUseCase = editPostUseCase;
            _postApiPresenter = postApiPresenter;
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(PostEditVm model) 
        {
            var post = new EditPostRequest
            {   
                Id = model.Id,
                Content = model.Content,
                Title = model.Title, 
            };
            await _editPostUseCase.HandleASync(post, _postApiPresenter);
            return _postApiPresenter.ContentResult;
        }  


    }
}
