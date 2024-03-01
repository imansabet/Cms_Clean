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
        Category GetById(int id);
        List<Category> GetAll();
        int Add(Category category);
        Category Edit(Category category);
        void Delete(int id);
    }
}
