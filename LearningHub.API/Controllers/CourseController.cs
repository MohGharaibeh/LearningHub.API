using LearningHub.core.Data;
using LearningHub.core.Service;
using LearningHub.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public bool CreateCourse(Apicourse apiCourse)
        {
            return _courseService.CreateCourse(apiCourse);
        }
        [Route("Update")]
        [HttpPut]
        public bool UpdateCourse(Apicourse apiCourse)
        {
            return _courseService.UpdateCourse(apiCourse);
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public bool DeleteCourse(int id)
        {
            return _courseService.DeleteCourse(id);
        }
        [HttpGet]
        //[Route("GetAll")]
        public List<Apicourse> GetAllCourse()
        {
            return _courseService.GetAllCourse();
        }
        [HttpGet]
        [Route("GetId/{id}")]
        public Apicourse GetCourseById(int id)
        {
            return _courseService.GetCourseById(id);
        }

        [Route("uploadImage")]
        [HttpPost]
        public Apicourse UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() +"_" + file.FileName;
            var fullPath = Path.Combine("photo", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Apicourse item = new Apicourse();
            item.Courseimagepath = fileName;
            return item;
        }

        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<Apicategory>>GetAllCategoryCourse()
        {
            return _courseService.GetAllCategoryCourse();
        }

    }
}
