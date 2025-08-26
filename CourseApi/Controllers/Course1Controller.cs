using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseApi.Repository;
using CourseApi.Models;
using CourseApi.IRepo;
namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course1Controller : ControllerBase
    {
        //CourseRepo _repo;
        ICourseRepo _repo;
        public Course1Controller(ICourseRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Get()
        {
            return Ok(_repo.GetCourses());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetCourseById(id));

        }
        [HttpPost]
        public IActionResult Post(Course course)
        {
            return Created("Added", _repo.AddCourse(course));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.DeleteCourse(id));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Course course, int id)
        {
            return Ok(_repo.UpdateCourse(id, course));
        }
    }
}
