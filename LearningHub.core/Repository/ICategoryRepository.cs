using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Repository
{
    public interface ICategoryRepository
    {
        public List<Apicategory> GetAllCategory();
        public bool CreateCategory(Apicategory apiCategory);
        public bool UpdateCategory(Apicategory apiCategory);
        public bool DeleteCategory(int id);
        public Apicategory GetCategoryById(int id);

    }
}
