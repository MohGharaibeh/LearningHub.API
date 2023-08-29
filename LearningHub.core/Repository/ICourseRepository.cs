using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Repository
{
    public interface ICourseRepository
    {
        public List<Apicourse> GetAllCourse();
        public bool CreateCourse(Apicourse apiCourse);
        public bool UpdateCourse(Apicourse apiCourse);
        public bool DeleteCourse(int id);
        public Apicourse GetCourseById(int id);
        Task<List<Apicategory>> GetAllCategoryCourse();

    }
}
