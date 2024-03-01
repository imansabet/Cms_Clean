using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Cms.Infrastructure.Data.Entities.Category;  //Inside Methods
using CategoryDomain = Cms.Core.Domain.Category;
using Microsoft.EntityFrameworkCore;  //

namespace Cms.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CmsDbContext _cmsDbContext;

        public CategoryRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        public async Task<int> AddAsync(CategoryDomain category)
        {
            var dbModel = new CategoryEntity
            { 
                CreatedDate = DateTime.Now,
                Title = category.Title,
            };
            await _cmsDbContext.Categories.AddAsync(dbModel); 
            await _cmsDbContext.SaveChangesAsync();
            return dbModel.Id;

        }

        public async Task DeleteAsync(int id)
        {
            var finded = GetCategoryAsync(id);
            _cmsDbContext.Remove(finded);
            await _cmsDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(CategoryDomain category)
        {
            var finded = GetCategoryAsync(category.Id);
            finded.Title = category.Title;
            _cmsDbContext.Categories.Update(finded);
            await _cmsDbContext.SaveChangesAsync();
        }

        public async Task<List<CategoryDomain>> GetAllAsync()
        {
            return await _cmsDbContext.Categories.Select(x => new CategoryDomain { 
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Id = x.Id
            }).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var item = await _cmsDbContext.Categories.Select( x => new CategoryDomain 
            { 
                Id = x.Id,
                CreatedDate = x.CreatedDate
            }).FirstOrDefaultAsync(x => x.Id == id );
            if ( item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }

        private CategoryEntity GetCategoryAsync(int id)
        {
            var item = _cmsDbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }
    }
}
