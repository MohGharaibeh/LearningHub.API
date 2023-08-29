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
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public List<Apilogin> GetAllLogin()
        {
            return _loginRepository.GetAllLogin();
        }
        public bool CreateLogin(Apilogin login)
        {
            return _loginRepository.CreateLogin(login);
        }
        public bool UpdateLogin(Apilogin login)
        {
            return _loginRepository.UpdateLogin(login);
        }
        public bool DeleteLogin(int id)
        {
            return _loginRepository.DeleteLogin(id);
        }
        public Apilogin GetLoginById(int id)
        {
            return _loginRepository.GetLoginById(id);
        }
    }
}
