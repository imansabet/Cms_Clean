using Cms.Core.Domain;
using Cms.Core.Dtos.General;
using Cms.Core.Dtos.UseCase;
using Cms.Core.Interfaces.Repository;
using Cms.Core.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cms.Core.Dtos.UseCase.EditPost;

namespace Cms.Core.UseCase
{
    public class EditPostUseCase : IEditPostUseCase
    {
        private readonly IPostRepositorty _postRepositorty;

        public EditPostUseCase(IPostRepositorty postRepositorty)
        {
            _postRepositorty = postRepositorty;
        }

        public async Task HandleASync(EditPostRequest message, IOutPutPort<GenericResponse<EditPostResponse>> outputPort)
        {
            var post = new Post
            {
                Id = message.Id,
                Content = message.Content,
                Title = message.Title,
            };
             var id =  await _postRepositorty.Edit(post);
            outputPort.Handle(new GenericResponse<EditPostResponse> ( new EditPostResponse { Id = await _postRepositorty.Edit(post) } ));

        }   
    }
}
