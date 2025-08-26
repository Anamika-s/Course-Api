using CourseApi.Models;

namespace CourseApi.IRepo
{
    public interface ICourseRepo
    {
        public List<Course> GetCourses();
        public Course GetCourseById(int id);
        public Course AddCourse(Course course);
        public Course UpdateCourse(int id, Course course);
        public bool DeleteCourse(int id);
    }
    public interface IBatchRepo
    {
        public List<Course> GetBatches();
        public Course GetBatchById(int id);
        public Course AddBatch(Batch batch);
        public Course UpdateBatch(int id, Batch batch);
        public bool DeleteBatch(int id);
    }

}
