using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Repository
{
    public interface IStudentRepository
    {
        List<Apistudent> GetAllStudent();
        Apistudent GetStudent(int id);
        bool CreateStudent(Apistudent apiStudent);
        bool DeleteStudent(int id);
        bool UpdateStudent(Apistudent apiStudent);
    }
}
