using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Service
{
    public interface ILoginService
    {
        public List<Apilogin> GetAllLogin();
        public bool CreateLogin(Apilogin login);
        public bool UpdateLogin(Apilogin login);
        public bool DeleteLogin(int id);
        public Apilogin GetLoginById(int id);
        public string Login(Apilogin apilogin); // string datatype bacause he not return all information of ApiLogin object
    }
}
