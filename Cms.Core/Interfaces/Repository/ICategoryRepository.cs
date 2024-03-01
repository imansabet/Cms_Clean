using Cms.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Core.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task<int> AddAsync(Category category);
        Task EditAsync(Category category);
        Task DeleteAsync(int id);
    }
}
