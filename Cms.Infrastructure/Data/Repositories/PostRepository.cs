using Cms.Core.Commands;
using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostEntity = Cms.Infrastructure.Data.Entities.Post;
using PostDomain = Cms.Core.Domain.Post;

namespace Cms.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepositorty
    {
        private readonly CmsDbContext _cmsDbContext;

        public PostRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public async Task<int> Add(PostAddCommand request)
        {
            var item = new PostEntity 
            {
                Content = request.Content,
                Title = request.Title,
            };

            await _cmsDbContext.Posts.AddAsync(item);
            await _cmsDbContext.SaveChangesAsync();
            return item.Id;
         }

        public async Task<int> Edit(PostDomain post)
        {
            _cmsDbContext.Update(post);
            await _cmsDbContext.SaveChangesAsync();
            return post.Id;
        }

        public async Task<List<Post>> GetLatestPostsAsync(int count)
        {
            return  await _cmsDbContext.Posts.Select(x=>new Post
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
            }).OrderByDescending(x=>x.CreatedDate)
              .Take(count).ToListAsync();
        }

        
    }
}
 