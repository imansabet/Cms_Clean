using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryEntity = Cms.Infrastructure.Data.Entities.Category;  //Inside Methods
using CategoryDomain = Cms.Core.Domain.Category;  //

namespace Cms.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CmsDbContext _cmsDbContext;

        public CategoryRepository(CmsDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        public int Add(CategoryDomain category)
        {
            var dbModel = new CategoryEntity
            { 
                CreatedDate = DateTime.Now,
                Title = category.Title,
            };
            _cmsDbContext.Categories.Add(dbModel); 
            _cmsDbContext.SaveChanges();
            return dbModel.Id;

        }

        public void Delete(int id)
        {
            var finded = GetCategory(id);
            _cmsDbContext.Remove(finded);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(CategoryDomain category)
        {
            var finded = GetCategory(category.Id);
            finded.Title = category.Title;
            _cmsDbContext.Categories.Update(finded);
            _cmsDbContext.SaveChanges();
        }

        public List<CategoryDomain> GetAll()
        {
            return _cmsDbContext.Categories.Select(x => new CategoryDomain { 
                Title = x.Title,
                CreatedDate = x.CreatedDate,
                Id = x.Id
            }).ToList();
        }

        public Category GetById(int id)
        {
            var item = _cmsDbContext.Categories.Select( x => new CategoryDomain 
            { 
                Id = x.Id,
                CreatedDate = x.CreatedDate
            }).FirstOrDefault(x => x.Id == id );
            if ( item == null)
            {
                throw new Exception("Not Found");
            }
            return item;
        }

        private CategoryEntity GetCategory(int id)
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
