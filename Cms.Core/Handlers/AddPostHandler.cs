using Cms.Core.Commands;
using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using Cms.Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Handlers
{
    public class AddPostHandler : IRequestHandler<PostAddCommand, AddPostResponse>
    {
        private readonly IPostRepositorty _postRepositorty;

        public AddPostHandler(IPostRepositorty postRepositorty)
        {
            _postRepositorty = postRepositorty;
        }

        public async Task<AddPostResponse> Handle(PostAddCommand request, CancellationToken cancellationToken)
        {
            var result =  await _postRepositorty.Add(request);
            return new AddPostResponse { Id = await _postRepositorty.Add(request) };
        }
    }
}
