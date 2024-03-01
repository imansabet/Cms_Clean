using Cms.Core.Domain;
using Cms.Core.Interfaces.Repository;
using Cms.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet("{int:id}")]
        public async Task<IActionResult> GetCategory(int id) 
        {
            try 
            { 
                var category = await _categoryRepository.GetByIdAsync(id);
                return CustomeOk(category);
            }
            catch (Exception ex) 
            {
                return CustomeError(ex.Message);
            } 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory() 
        {
            try
            {
                var category = await _categoryRepository.GetAllAsync();
                return CustomeOk(category);
            }
            catch (Exception ex) 
            {
                return CustomeError(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(CategoryAddVm categoryAddvm) 
        {
            try
            {
                var id = await _categoryRepository.AddAsync(new Category 
                { 
                    Title = categoryAddvm.Title,
                });
                return CustomeOk(id);
            }
            catch (Exception ex)
            {
                return CustomeError(ex.Message);
            }
        }
        [HttpPut("{int:id}")]
        public async Task<IActionResult> Put(int id ,CategoryEditVm categoryEditVm) 
        {
            if (id != categoryEditVm.Id) 
            {
                return CustomeError();
            }
            try 
            {
                await _categoryRepository.EditAsync(new Category
                { 
                    Id = id,
                    Title = categoryEditVm.Title
                });
                return CustomeOk(true);
            } 
            catch (Exception ex) 
            {
                return CustomeError(ex.Message);
            }
        }
        [HttpDelete("{int:id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try 
            {
                await _categoryRepository.DeleteAsync(id);
                return CustomeOk(true);
            }
            catch (Exception ex) 
            {
                return CustomeError(ex.Message);
            }
        }

    }
}
