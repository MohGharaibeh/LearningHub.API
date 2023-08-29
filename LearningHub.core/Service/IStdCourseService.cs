using LearningHub.core.Data;
using LearningHub.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Service
{
    public interface IStdCourseService
    {
        public List<Apistdcourse> GetAllStdCourse();
        public Apistdcourse GetStdCourse(int id);
        public bool CreateStdCourse(Apistdcourse apiStdcourse);
        public bool DeleteStdCourse(int id);
        public bool UpdateStdCourse(Apistdcourse apiStdcourse);
        public List<Search> SearchStrCourse(Search search);
    }
}
