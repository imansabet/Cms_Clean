using Cms.Core.Dtos.General;
using Cms.Core.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Dtos.UseCase
{
    public class EditPost
    {
        public class EditPostRequest : IUseCaseRequest<GenericResponse<EditPostResponse>>
        {
            public string Title { get; set; }
            public string Content { get; set; }

        }
        public class EditPostResponse
        {
            public int Id { get; set; }

        }
    }
}
