using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DatabaseWebAPI.Models
{
    public class CourseManager
    {
        public static List<Course> Read(SqlConnection connection)
        {
            List<Course> courses = new List<Course>();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Class;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseId = (int)reader["ClassID"],
                        CourseName = reader["ClassName"].ToString()
                    };
                    courses.Add(course);
                }

                reader.Close();
                connection.Close();
            }
            return courses;
        }

        public static Course ReadById(int id, SqlConnection connection)
        {
            Course courseObject = new Course();
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Class WHERE ClassID=" + id + ";", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        CourseId = (int)reader["ClassID"],
                        CourseName = reader["ClassName"].ToString()
                    };
                    courseObject = course;
                }
                reader.Close();
                connection.Close();
            }
            return courseObject;
        }

        public static void Create(Course course, SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "INSERT INTO dbo.Class VALUES (@ClassName)", connection);

                command.Parameters.AddWithValue("@ClassName", course.CourseName);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Update(int id, Course course, SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "UPDATE Class SET ClassName=@ClassName WHERE ClassID=@ClassID", connection);

                command.Parameters.AddWithValue("@ClassID", id);
                command.Parameters.AddWithValue("@ClassName", course.CourseName);

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
                  "DELETE FROM dbo.Class WHERE ClassID=@ClassID", connection);

                command.Parameters.AddWithValue("@ClassID", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}