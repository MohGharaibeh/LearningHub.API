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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _dbContext;

        public CourseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Apicourse> GetAllCourse()
        {
            IEnumerable<Apicourse> result = _dbContext.Connection.Query<Apicourse>
                ("API_Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateCourse(Apicourse apiCourse)
        {
            var p = new DynamicParameters();
            p.Add("CNAME", apiCourse.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CIMAGE", apiCourse.Courseimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CCATEGORY", apiCourse.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Course_Package.CreateCourse", p
                , commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool UpdateCourse(Apicourse apiCourse)
        {
            var p = new DynamicParameters();
            p.Add("CID", apiCourse.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CNAME", apiCourse.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CIMAGE", apiCourse.Courseimagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CCATEGORY", apiCourse.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Course_Package.UpdateCourse", p
                , commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Course_Package.DeleteCourse",
                p, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public Apicourse GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apicourse>("API_Course_Package.GETBYID",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Apicategory>> GetAllCategoryCourse()
        {
            var result1 = await _dbContext.Connection.QueryAsync<Apicategory, Apicourse,Apicategory>("API_Category_Package.GetAllCategoryCourse",
             (Category, course) =>
             {
                 Category.Apicourses.Add(course);
                 return Category;
             },
             splitOn: "Courseid",
             param: null,
             commandType: CommandType.StoredProcedure
             );
            var result2 = result1.GroupBy(p =>
           p.Categoryid).Select(g =>
           {
               var groupedPost = g.First();
               groupedPost.Apicourses = g.Select(p =>
              p.Apicourses.Single()).ToList();
               return groupedPost;
           });
            return result2.ToList();
        }
    }
}
