using Dapper;
using LearningHub.core.Common;
using LearningHub.core.Data;
using LearningHub.core.DTO;
using LearningHub.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Repository
{
    public class StdCourseRepository : IStdCourseRepository
    {
        private readonly IDbContext _dbContext;

        public StdCourseRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Apistdcourse> GetAllStdCourse()
        {
            IEnumerable<Apistdcourse> result = _dbContext.Connection.Query<Apistdcourse>
                ("API_StudentCourse_Package.GetAllStdCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Apistdcourse GetStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("STID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apistdcourse>
                ("API_StudentCourse_Package.GetByID",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        
        public bool CreateStdCourse(Apistdcourse apiStdcourse)
        {
            var p = new DynamicParameters();
            p.Add("crsid", apiStdcourse.Courseid, dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            p.Add("stdid", apiStdcourse.Studentid, dbType: DbType.Int32,
                direction: ParameterDirection.Input);
            p.Add("regdate", apiStdcourse.Stdcoursedateofregistration, dbType: DbType.Date,
                direction: ParameterDirection.Input);
            p.Add("markstd", apiStdcourse.Stdcoursemarkofstd, dbType: DbType.Double,
                direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_StudentCourse_Package.CreateStdCourse", p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool DeleteStdCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("stdid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_StudentCourse_Package.DeleteStdCourse",p,
                commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool UpdateStdCourse(Apistdcourse apiStdcourse)
        {
            var p = new DynamicParameters();
            p.Add("STDID", apiStdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CRSID_NEW", apiStdcourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STDID_NEW", apiStdcourse.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("REGDATE_NEW", apiStdcourse.Stdcoursedateofregistration, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("MARKSTD_NEW", apiStdcourse.Stdcoursemarkofstd, dbType: DbType.Double, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_StudentCourse_Package.UpdateStdCourse",p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
        public List<Search> SearchStrCourse(Search search)
        {
            var p = new DynamicParameters();
            p.Add("sName", search.Studentfirstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cName", search.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DateTo", search.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateFrom", search.DateFrom, dbType: DbType.DateTime, direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Search>
                ("API_StudentCourse_Package.SearchStudentAndCourse", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
