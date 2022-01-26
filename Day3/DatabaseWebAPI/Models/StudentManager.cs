using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DatabaseWebAPI.Models
{
    public class StudentManager
    {

        public static List<Student> Read(SqlConnection connection)
        {
            List<Student> students = new List<Student>();
            using (connection)
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

        public static Student ReadById(int id, SqlConnection connection)
        {
            Student studentobj = new Student();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Student WHERE StudentID=" + id + ";", connection);
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
                    studentobj = student;
                }
                reader.Close();
                connection.Close();
            }
            return studentobj;
        }

        public static void Create(Student student, SqlConnection connection)
        {
            using (connection)
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

        public static void Update(int id, Student student, SqlConnection connection)
        {
            using (connection)
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

        public static void Delete(int id, SqlConnection connection)
        {
            using (connection)
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