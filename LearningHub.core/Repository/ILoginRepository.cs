using LearningHub.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.Repository
{
    public interface ILoginRepository
    {
        public List<Apilogin> GetAllLogin();
        public bool CreateLogin(Apilogin login);
        public bool UpdateLogin(Apilogin login);
        public bool DeleteLogin(int id);
        public Apilogin GetLoginById(int id);
    }
}
