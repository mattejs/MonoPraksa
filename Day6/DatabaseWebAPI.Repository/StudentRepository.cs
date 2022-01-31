using DatabaseWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
        }
        protected IStudent Student = new Student();

        static string connecitonString = "Server=tcp:studentdbpraksa.database.windows.net,1433;Initial Catalog=StudentDB;" +
            "Persist Security Info=False;User ID=adminpraksa;Password=Admin123;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<List<IStudent>> Read(Paging paging, StudentFilter filter, Sort sorter)
        {
            List<IStudent> students = new List<IStudent>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand();
                if(filter == null || sorter == null) {
                    command = new SqlCommand(
                      "SELECT * FROM dbo.Student", connection);
                }                
                if (filter != null)
                {
                    command = new SqlCommand(
                      "SELECT * FROM dbo.Student" + filter.Filter(), connection);
                }
                if (sorter != null)
                {
                    command = new SqlCommand(
                      "SELECT * FROM dbo.Student" + sorter.Sorting(), connection);
                }
                else
                {
                    command = new SqlCommand(
                      "SELECT * FROM dbo.Student" + filter.Filter() + sorter.Sorting(), connection);
                }
                
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        StudentId = (int)reader["StudentID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    };
                    students.Add(student);
                }

                reader.Close();
                connection.Close();
            }
            return students;
        }

        public async Task<IStudent> ReadById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Student WHERE StudentID=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                Student student = new Student()
                {
                    StudentId = (int)reader["StudentID"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                reader.Close();
                connection.Close();
                return student;
            }

        }

        public async Task<IStudent> ReadStudentCourse(int id)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                List<Course> courses = new List<Course>();
                SqlCommand command = new SqlCommand(
                  "SELECT Student.StudentID, Student.FirstName, Student.LastName, Course.CourseID, Course.CourseName FROM StudentCourse, Student, Course " +
                  "WHERE StudentCourse.StudentID = Student.StudentID AND StudentCourse.CourseID = Course.CourseID AND StudentCourse.StudentID=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                Student student = new Student();
                while (reader.Read())
                {

                    student.StudentId = (int)reader["StudentID"];
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();

                   
                    Course course = new Course()
                    {
                        CourseId = (int)reader["CourseID"],
                        CourseName = reader["CourseName"].ToString()
                    };
                    courses.Add(course);

                }

                student.Courses = courses;
                reader.Close();
                connection.Close();

                return student;
            }              

        }

        public async Task Create(IStudent student)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "INSERT INTO dbo.Student VALUES (@FirstName,@LastName)", connection);

                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public async Task Update(int id, IStudent student)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "UPDATE Student SET FirstName=@FirstName, LastName=@LastName WHERE StudentID=@StudentID", connection);

                command.Parameters.AddWithValue("@StudentID", id);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@LastName", student.LastName);

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
                  "DELETE FROM dbo.Student WHERE StudentID=@StudentID", connection);

                command.Parameters.AddWithValue("@StudentID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
