using LearningHub.core.Data;
using LearningHub.core.DTO;
using LearningHub.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdCourseController : ControllerBase
    {
        private readonly IStdCourseService _service;

        public StdCourseController(IStdCourseService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Apistdcourse> GetAllStdCourse()
        {
            return _service.GetAllStdCourse();
        }
        [HttpGet]
        [Route("GetId/{id}")]
        public Apistdcourse GetStdCourse(int id)
        {
            return _service.GetStdCourse(id);
        }
        [HttpPost]
        public bool CreateStdCourse(Apistdcourse apiStdcourse)
        {
            return _service.CreateStdCourse(apiStdcourse);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool DeleteStdCourse(int id)
        {
            return _service.DeleteStdCourse(id);
        }
        [Route("Update/{id}")]
        [HttpPut]
        public bool UpdateStdCourse(Apistdcourse apiStdcourse)
        {
            return _service.UpdateStdCourse(apiStdcourse);
        }
        [Route("SearchStdCourse")]
        [HttpPost]
        public List<Search> SearchStrCourse(Search search)
        {
            return _service.SearchStrCourse(search);
        }
    }
}
