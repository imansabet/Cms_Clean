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
    public class GetLatestPostsHandler : IRequestHandler<GetLatestPostsQuery, List<Post>>
    {
        private readonly IPostRepositorty _postRepositorty;

        public GetLatestPostsHandler(IPostRepositorty postRepositorty)
        {
            _postRepositorty = postRepositorty;
        }
        public async Task<List<Post>> Handle(GetLatestPostsQuery request, CancellationToken cancellationToken)
        {
            return await _postRepositorty.GetLatestPostsAsync(20); 
        }
    }
}
