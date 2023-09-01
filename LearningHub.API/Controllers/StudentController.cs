using LearningHub.core.Data;
using LearningHub.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public bool CreateStudent(Apistudent apiStudent)
        {
            return _studentService.CreateStudent(apiStudent);
        }
        [Route("Update")]
        [HttpPut]
        public bool UpdateStudent(Apistudent apiStudent)
        {
            return _studentService.UpdateStudent(apiStudent);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }
        [HttpGet]
        public List<Apistudent> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }
        [Route("GetId/{id}")]
        [HttpGet]
        public Apistudent GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }
    }
}
