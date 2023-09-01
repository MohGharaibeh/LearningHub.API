using LearningHub.core.Data;
using LearningHub.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Apicategory> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }
        [HttpPost]
        public bool CreateCategory(Apicategory apiCategory)
        {
            return _categoryService.CreateCategory(apiCategory);
        }
        [Route("UpdateCategory")]
        [HttpPut]
        public bool UpdateCategory(Apicategory apiCategory)
        {
            return _categoryService.UpdateCategory(apiCategory);
        }
        [Route("DeleteCategory/{id}")]
        [HttpDelete]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
        [Route("GetById/{id}")]
        [HttpGet]
        public Apicategory GetCategoryById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
    }
}
