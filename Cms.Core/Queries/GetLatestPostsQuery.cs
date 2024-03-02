using Cms.Core.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Queries
{
    public class GetLatestPostsQuery : IRequest<List<Post>>
    {

    }
}
