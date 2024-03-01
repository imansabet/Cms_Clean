﻿using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepositorty
    {
        private readonly CmsDbContext _cmsDbContext;

        public PostRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        public List<Post> GetLatestPosts(int count)
        {
            return _cmsDbContext.Posts.Select(x=>new Post
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
            }).OrderByDescending(x=>x.CreatedDate)
              .Take(count).ToList();
        }
    }
}
 