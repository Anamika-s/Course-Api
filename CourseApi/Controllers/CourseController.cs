using CourseApi.Context;
using CourseApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseApi.ViewModel;
namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        //[Authorize(Roles="Admin")]
        [Authorize(Policy = "RequireAdminRoleOnly")]
        public IActionResult Post(Course course)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            course.CreatedBy = 1;
            course.CreatedOn = DateTime.Now;
            course.IsActive = true;
            _context.Courses.Add(course);
            _context.SaveChanges();
             return Created("Aded", course);    

        }

        [HttpDelete("{id}")]

        //[Authorize(Roles ="Admin,Manager")]
        [Authorize(Policy = "RequireManagerAndAdmin")]
        public IActionResult Delete(int id)
        {
            if (!User.IsInRole("Admin,Manager"))
            {
                return StatusCode(403);
            }
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

        [HttpGet]
        [Route("/batchdetails")]
        public IActionResult BatchDetails()
        {
             List<BatchViewModel>  batchdetailslist = 
               
                (from batch in _context.Batches
                join course in _context.Courses
                on batch.CourseId equals course.CourseId
                join trainer in _context.Trainers
                on batch.TrainerId equals trainer.TrainerCode
                select new BatchViewModel()
                {
                    BatchCode = batch.BatchId,
                    BatchName = batch.BatchName,
                    CourseName = course.CourseName,
                    CourseDuration = course.Duration,
                    StartDate = batch.StartDate,
                    TrainerName = trainer.TrainerName
                }
                ).ToList();
            return Ok(batchdetailslist);
            }


        }


}


