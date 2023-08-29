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
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext _dbContext;

        public StudentRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Apistudent> GetAllStudent()
        {
            IEnumerable<Apistudent> result = _dbContext.Connection.Query<Apistudent>
                ("API_STUDENT_PACKAGE.GETALLSTUDENT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Apistudent GetStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("STID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apistudent>
                ("API_Student_Package.GETBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool CreateStudent(Apistudent apiStudent)
        {
            var p = new DynamicParameters();
            p.Add("SFNAME", apiStudent.Studentfirstname, dbType: DbType.String,
                direction: ParameterDirection.Input);
            p.Add("SLNAME", apiStudent.Studentlastname, dbType: DbType.String,
                direction: ParameterDirection.Input);
            p.Add("BDATE", apiStudent.Studentdateofbirth, dbType: DbType.Date,
                direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Student_Package.CreateStudent", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("STID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Student_Package.DeleteStudent", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool UpdateStudent(Apistudent apiStudent)
        {
            var p = new DynamicParameters();
            p.Add("STID", apiStudent.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("SFNAME", apiStudent.Studentfirstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("SLNAME", apiStudent.Studentlastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BDATE", apiStudent.Studentdateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Student_Package.UpdateStudent", p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
