using Dapper;
using LearningHub.core.Common;
using LearningHub.core.Data;
using LearningHub.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Repository
{
    public class DisplayStudentRepository : IDisplayStudentRepository
    {
        private readonly IDbContext _dbContext;
        public DisplayStudentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Apistudent> GetFirstAndLastName()
        {
            IEnumerable<Apistudent> result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetFirstAndLastName",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Apistudent> GetFullName()
        {
            IEnumerable<Apistudent> result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetFullName",
                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Apistudent> GetByFirstName(string firstName)
        {
            var p = new DynamicParameters();
            p.Add("FNAME", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Apistudent> result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetByFirstName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Apistudent> GetByBirthDate(DateTime birthDate)
        {
            var p = new DynamicParameters();
            p.Add("BDATE", birthDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetByBirthDate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Apistudent> GetByBirthDateInterval(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("STARTDATE", startDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("ENDDATE", endDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetByBirthDateInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Apistudent> GetTopMarkStudents(int topN)
        {
            var p = new DynamicParameters();
            p.Add("n", topN, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package_Display.GetnTopMark", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
