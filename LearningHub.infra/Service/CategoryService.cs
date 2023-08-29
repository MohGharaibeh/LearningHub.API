using LearningHub.core.Data;
using LearningHub.core.Repository;
using LearningHub.core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Apicategory> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }
        public bool CreateCategory(Apicategory apiCategory)
        {
            return _categoryRepository.CreateCategory(apiCategory);
        }
        public bool UpdateCategory(Apicategory apiCategory)
        {
            return _categoryRepository.UpdateCategory(apiCategory);
        }
        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }
        public Apicategory GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
    }
}
