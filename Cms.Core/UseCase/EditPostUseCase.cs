using Cms.Core.Dtos.General;
using Cms.Core.Dtos.UseCase;
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
        public Task HandleASync(EditPost.EditPostRequest message, IOutputPort<GenericResponse<EditPostResponse>> outputPort)
        {
            throw new NotImplementedException();
        }
    }
}
