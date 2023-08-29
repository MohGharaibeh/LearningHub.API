using LearningHub.core.Data;
using LearningHub.core.DTO;
using LearningHub.core.Repository;
using LearningHub.core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Service
{
    public class StdCourseService : IStdCourseService
    {
        private readonly IStdCourseRepository _stdCourseRepository;

        public StdCourseService(IStdCourseRepository stdCourseRepository)
        {
            _stdCourseRepository = stdCourseRepository;
        }

        public List<Apistdcourse> GetAllStdCourse()
        {
            return _stdCourseRepository.GetAllStdCourse();
        }
        public Apistdcourse GetStdCourse(int id)
        {
            return _stdCourseRepository.GetStdCourse(id);
        }
        public bool CreateStdCourse(Apistdcourse apiStdcourse)
        {
            return _stdCourseRepository.CreateStdCourse(apiStdcourse);
        }
        public bool DeleteStdCourse(int id)
        {
            return _stdCourseRepository.DeleteStdCourse(id);
        }
        public bool UpdateStdCourse(Apistdcourse apiStdcourse)
        {
            return _stdCourseRepository.UpdateStdCourse(apiStdcourse);
        }
        public List<Search> SearchStrCourse(Search search)
        {
            return _stdCourseRepository.SearchStrCourse(search);
        }
    }
}
