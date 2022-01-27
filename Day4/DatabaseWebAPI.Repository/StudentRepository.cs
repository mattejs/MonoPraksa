using DatabaseWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Model.Common;

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

        public List<IStudent> Read()
        {
            List<IStudent> students = new List<IStudent>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Student;", connection);
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

        public IStudent ReadById(int id)
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

        public void Create(IStudent student)
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

        public void Update(int id, IStudent student)
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

        public void Delete(int id)
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
