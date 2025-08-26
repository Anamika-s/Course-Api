using CourseApi.Context;
using CourseApi.IRepo;
using CourseApi.Models;

namespace CourseApi.Repository
{
    public class CourseRepo : ICourseRepo
    {
        AppDbContext _context;
        public CourseRepo(AppDbContext context)
        {
            _context= context;  
        }
        public Course AddCourse(Course course)
        {
          _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int id)
        {

            Course course = GetCourseById(id)
;
            if (course != null)
                _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;

                    }

        public Course GetCourseById(int id)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            return course;
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course UpdateCourse(int id, Course course)
        {
            Course obj = GetCourseById(id)
;
            if (obj != null)
            {
                obj.Duration = course.Duration;
                obj.ModifiedBy = 1;
                obj.ModifiedOn = DateTime.Now;
            }
            _context.SaveChanges();
            return obj;

        }
    }
}
