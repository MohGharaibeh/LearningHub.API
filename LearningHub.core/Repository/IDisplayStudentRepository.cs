using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Repository
{
    public interface IDisplayStudentRepository
    {
        public List<Apistudent> GetFirstAndLastName();
        public List<Apistudent> GetFullName();
        public List<Apistudent> GetByFirstName(string firstName);
        public List<Apistudent> GetByBirthDate(DateTime birthDate);
        public List<Apistudent> GetByBirthDateInterval(DateTime startDate, DateTime endDate);
        public List<Apistudent> GetTopMarkStudents(int topN);
    }
}
