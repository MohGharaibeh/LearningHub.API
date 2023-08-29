using LearningHub.core.Data;
using LearningHub.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public List<Apilogin> GetAllLogin()
        {
            return _loginService.GetAllLogin();
        }
        [HttpPost]
        public bool CreateLogin(Apilogin login)
        {
            return _loginService.CreateLogin(login);
        }
        [Route("update/{id}")]
        [HttpPut]
        public bool UpdateLogin(Apilogin login)
        {
            return _loginService.UpdateLogin(login);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteLogin(int id)
        {
            return _loginService.DeleteLogin(id);
        }
        [Route("getbyid/{id}")]
        [HttpGet]
        public Apilogin GetLoginById(int id)
        {
            return _loginService.GetLoginById(id);
        }
    }
}
