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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbConnection;

        public LoginRepository(IDbContext dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Apilogin> GetAllLogin()
        {
            IEnumerable<Apilogin> result = _dbConnection.Connection.Query<Apilogin>
                ("API_Login_Package.GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateLogin(Apilogin login)
        {
            var p = new DynamicParameters();
            p.Add("username", login.Loginusername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass", login.Loginpassword, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("stdid", login.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rolid", login.Roleid, dbType: DbType.Int32 , direction: ParameterDirection.Input);
            var result = _dbConnection.Connection.Execute("API_Login_Package.CreateLogin", 
                p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool UpdateLogin(Apilogin login)
        {
            var p = new DynamicParameters();
            p.Add("logId", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("usernamenew", login.Loginusername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("passnew", login.Loginpassword, dbType: DbType.String , direction: ParameterDirection.Input);
            p.Add("stdidnew", login.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rolidnew", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConnection.Connection.Execute("API_Login_Package.UpdateLogin",
                p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("lnId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConnection.Connection.Execute("API_Login_Package.DeleteLogin", 
                p, commandType: CommandType.StoredProcedure); 
            return result < 0;
        }
        public Apilogin GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("lgnId", id, dbType: DbType.Int32 , direction: ParameterDirection.Input);
            var result = _dbConnection.Connection.Query<Apilogin>("API_Login_Package.GetByID", 
                p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public Apilogin Login(Apilogin apilogin)
        {
            var p = new DynamicParameters();
            p.Add("usrname", apilogin.Loginusername, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pasword", apilogin.Loginpassword, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConnection.Connection.Query<Apilogin>("API_Login_Package.Authentications",
                p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }
    }
}
