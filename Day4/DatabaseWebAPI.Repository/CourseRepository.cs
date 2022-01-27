using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Repository.Common;


namespace DatabaseWebAPI.Repository
{
    public class CourseRepository: ICourseRepository
    {
        public CourseRepository()
        {
        }
        protected ICourse Course = new Course();


        static string connecitonString = "Server=tcp:studentdbpraksa.database.windows.net,1433;Initial Catalog=StudentDB;" +
            "Persist Security Info=False;User ID=adminpraksa;Password=Admin123;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<ICourse> Read()
        {
            List<ICourse> courses = new List<ICourse>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Course;", connection);
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

        public ICourse ReadById(int id)
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

        public void Create(ICourse course)
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

        public void Update(int id, ICourse course)
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

        public void Delete(int id)
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
