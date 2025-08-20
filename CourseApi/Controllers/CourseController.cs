using CourseApi.Context;
using CourseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        AppDbContext _context;
        // Dependency Injection
        public CourseController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Get()
        {
            if(_context.Courses.ToList().Count == 0)
               return NotFound();
            else
            return Ok(_context.Courses.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            if(course == null)
                return NotFound();
            else 
                return Ok(course);
    
        }

        [HttpPost]
        public IActionResult Post(Course course)
        {
            course.CreatedBy = 1;
            course.CreatedOn = DateTime.Now;
            course.IsActive = true;
            _context.Courses.Add(course);
            _context.SaveChanges();
             return Created("Aded", course);    

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            if (course == null)
                return NotFound();
            else
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Course temp)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            if (course == null)
                return NotFound();
            else
            {
                course.ModifiedOn = DateTime.Now;
                course.ModifiedBy = 1;
                course.Description= temp.Description;
                course.Duration = temp.Duration;

                _context.SaveChanges();
                return Ok();
            }
        }

    }
}
