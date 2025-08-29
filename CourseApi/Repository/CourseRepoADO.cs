//using CourseApi.IRepo;
//using CourseApi.Models;
//using Microsoft.Data.SqlClient;

//namespace CourseApi.Repository
//{
//    public class CourseRepoADO : ICourseRepo
//    {
//        SqlConnection connection;
//        SqlCommand command; 
//        public string GetConnectionString()
//        {
//            return "";
//        }
//        public SqlConnection GetConnection()
//        {
//            return new SqlConnection(GetConnectionString());
//        }
//        //  PUT ADO.NET CODE HERE
//        public Course AddCourse(Course course)
//        {
//            using (connection = GetConnection())
//            {
//                using (command = new SqlCommand())
//                {
//                    command.CommandText = "insert into courses ()";
//                    command.Connection = connection;
//                    connection.Open();
//                    command.ExecuteNonQuery();
//                    connection.Close();
//                }
//            }
//            return course;  
//          }
     

//        public bool DeleteCourse(int id)
//        {
//            using (connection = GetConnection())
//            {
//                using (command = new SqlCommand())
//                {
//                    command.CommandText = $"delete from courses where courseid ={id}";
//                    command.Connection = connection;
//                    connection.Open();
//                    command.ExecuteNonQuery();
//                }
//            }
//            return true;

//        }

//        public Course GetCourseById(int id)
//        {
//            Course course = null;
//            using (connection = GetConnection())
//            {
//                using (command = new SqlCommand($"select * from courses where courseid={id}";))
//                {
//                    connection.Open();
//                    SqlDataReader reader = command.ExecuteReader();
//                    course = new Course()
//                    {
//                        CourseId = (int)reader["courseid"],
//                        CourseName = reader["coursename"].ToString(),
//                        Description = reader["description"].ToString()
//                    };
//                    reader.Close();
//                    connection.Close();
//                }
//            }
//            return course;
//        }

//                public List<Course> GetCourses()
//        {
//            throw new NotImplementedException();
//        }

//        public Course UpdateCourse(int id, Course course)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
