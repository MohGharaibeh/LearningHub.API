using LearningHub.core.Data;
using LearningHub.core.Repository;
using LearningHub.core.Service;
using LearningHub.infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Apicourse> GetAllCourse()
        {
            return _courseRepository.GetAllCourse();
        }

        public bool CreateCourse(Apicourse apiCourse)
        {
            return _courseRepository.CreateCourse(apiCourse);
        }

        public bool UpdateCourse(Apicourse apiCourse)
        {
            return _courseRepository.UpdateCourse(apiCourse);
        }

        public bool DeleteCourse(int id)
        {
            return _courseRepository.DeleteCourse(id);
        }

        public Apicourse GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }
        public Task<List<Apicategory>> GetAllCategoryCourse()
        {
            return _courseRepository.GetAllCategoryCourse();
        }

    }
}
