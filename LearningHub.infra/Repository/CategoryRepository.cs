using Dapper;
using LearningHub.core.Common;
using LearningHub.core.Data;
using LearningHub.core.Repository;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Apicategory> GetAllCategory()
        {
            IEnumerable<Apicategory> result = _dbContext.Connection.Query<Apicategory>
                ("API_Category_Package.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateCategory(Apicategory apiCategory)
        {
            var p = new DynamicParameters();
            p.Add("cname", apiCategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Category_Package.CreateCategory", p,
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool UpdateCategory(Apicategory apiCategory)
        {
            var p = new DynamicParameters();
            p.Add("cID", apiCategory.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("cname", apiCategory.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Category_Package.UpdateCategory", p,
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("API_Category_Package.DeleteCategory", p, 
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public Apicategory GetCategoryById(int id)
        {
            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Apicategory>("API_Category_Package.GETBYID",
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
