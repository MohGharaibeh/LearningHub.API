using LearningHub.core.Data;
using LearningHub.core.Repository;
using LearningHub.core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public string Login(Apilogin apilogin)
        {
            var userLogin = _loginRepository.Login(apilogin);
            if (userLogin == null)
            {
                return null;
            }
            else
            {
                // 1- Create SymmetricSecurityKey --> Clien - Server , Raghad - Gharaibeh
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MohammedAlGharaibeh@2000"));
                // 2- Create SigningCredentials object ( secret key, algorithm)
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                // 3- Generate Token
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userLogin.Loginusername),

                    new Claim(ClaimTypes.Role, userLogin.Roleid.ToString())
                };
                // generate token 
                var tokenOptions = new JwtSecurityToken(

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(60),

                    signingCredentials: signingCredentials

                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                // return token;
                return token;
            }
        }
    }
}
