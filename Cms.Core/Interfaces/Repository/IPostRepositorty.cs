using Cms.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Interfaces.Repository
{
    public interface IPostRepositorty
    {
        List<Post> GetLatestPosts (int count);
    }
}
