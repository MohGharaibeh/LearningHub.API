using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Service
{
    public interface IStudentService
    {
        public List<Apistudent> GetAllStudent();
        public Apistudent GetStudent(int id);
        public bool CreateStudent(Apistudent apiStudent);
        public bool DeleteStudent(int id);
        public bool UpdateStudent(Apistudent apiStudent);
    }
}
