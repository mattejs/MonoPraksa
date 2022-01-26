using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using DatabaseWebAPI.Models;

namespace DatabaseWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        static string connecitonString = "Server=tcp:studentdbpraksa.database.windows.net,1433;Initial Catalog=StudentDB;" +
            "Persist Security Info=False;User ID=adminpraksa;Password=Admin123;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        SqlConnection connection = new SqlConnection(connecitonString);
        //List<Student> students = new List<Student>();

        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, StudentManager.Read(connection));
            }

            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
        }

        public HttpResponseMessage GetById(int id)
        {
            
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, StudentManager.ReadById(id, connection));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {
                StudentManager.Create(student, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "New student created");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
        }

        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            try
            {
                StudentManager.Update(id, student, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                StudentManager.Delete(id, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
        }
    }
}
