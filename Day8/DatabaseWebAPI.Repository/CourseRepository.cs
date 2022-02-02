using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Common;


namespace DatabaseWebAPI.Repository
{
    public class CourseRepository: ICourseRepository
    {

        static string connecitonString = "Server=tcp:studentdbpraksa.database.windows.net,1433;Initial Catalog=StudentDB;" +
            "Persist Security Info=False;User ID=adminpraksa;Password=Admin123;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<List<ICourse>> Read(Paging paging, CourseFilter filter, Sort sorter)
        {
            List<ICourse> courses = new List<ICourse>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = "SELECT * FROM dbo.Course";
                SqlCommand command = new SqlCommand();
                if (filter != null || sorter != null || paging != null)
                {
                    command = new SqlCommand(query + filter.AddFilter() + sorter.AddSorting() + paging.AddPaging(), connection);
                }
                else
                {
                    command = new SqlCommand(
                        "SELECT * FROM dbo.Course", connection);
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseId = (int)reader["CourseID"],
                        CourseName = reader["CourseName"].ToString()
                    };
                    courses.Add(course);
                }

                reader.Close();
                connection.Close();
            }
            return courses;
        }

        public async Task<ICourse> ReadById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Course WHERE CourseID=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                Course course = new Course()
                {
                    CourseId = (int)reader["CourseID"],
                    CourseName = reader["CourseName"].ToString()
                };
                reader.Close();
                connection.Close();
                return course;

            }
        }

        public async Task<ICourse> ReadCourseStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                List<Student> students = new List<Student>();
                SqlCommand command = new SqlCommand(
                  "SELECT Student.StudentID, Student.FirstName, Student.LastName, Course.CourseID, Course.CourseName FROM StudentCourse, Student, Course " +
                  "WHERE StudentCourse.StudentID = Student.StudentID AND StudentCourse.CourseID = Course.CourseID AND StudentCourse.CourseID=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                Course course = new Course();
                while (reader.Read())
                {

                    course.CourseId = (int)reader["CourseID"];
                    course.CourseName = reader["CourseName"].ToString();

                    Student student = new Student()
                    {
                        StudentId = (int)reader["StudentID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    students.Add(student);

                }

                course.Students = students;
                reader.Close();
                connection.Close();

                return course;
            }

        }

        public async Task Create(ICourse course)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "INSERT INTO dbo.Course VALUES (@CourseName)", connection);

                command.Parameters.AddWithValue("@CourseName", course.CourseName);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public async Task Update(int id, ICourse course)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "UPDATE Course SET CourseName=@CourseName WHERE CourseID=@CourseID", connection);

                command.Parameters.AddWithValue("@CourseID", id);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public async Task Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "DELETE FROM dbo.Course WHERE CourseID=@CourseID", connection);

                command.Parameters.AddWithValue("@CourseID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
