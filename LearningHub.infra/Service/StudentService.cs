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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Apistudent> GetAllStudent()
        {

            return _studentRepository.GetAllStudent();
        }

        public Apistudent GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }

        public bool CreateStudent(Apistudent apiStudent)
        {
            return _studentRepository.CreateStudent(apiStudent);
        }

        public bool DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
        }

        public bool UpdateStudent(Apistudent apiStudent)
        {
            return _studentRepository.UpdateStudent(apiStudent);
        }
    }
}
