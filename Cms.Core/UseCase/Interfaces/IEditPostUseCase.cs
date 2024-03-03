using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cms.Core.Dtos.General;
using Cms.Core.Dtos.UseCase;
using static Cms.Core.Dtos.UseCase.EditPost;

namespace Cms.Core.UseCase.Interfaces
{
    public interface IEditPostUseCase : IUseCaseRequestHandler<EditPostRequest, GenericResponse<EditPostResponse>>
    {

    }
}
