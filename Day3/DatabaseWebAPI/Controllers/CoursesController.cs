using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseWebAPI.Models;

namespace DatabaseWebAPI.Controllers
{
    public class CoursesController : ApiController
    {

        static string connecitonString = "Server=tcp:studentdbpraksa.database.windows.net,1433;Initial Catalog=StudentDB;" +
            "Persist Security Info=False;User ID=adminpraksa;Password=Admin123;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        SqlConnection connection = new SqlConnection(connecitonString);

        public HttpResponseMessage Get()
        {
            try 
            {  
            return Request.CreateResponse(HttpStatusCode.OK, CourseManager.Read(connection));
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
            return Request.CreateResponse(HttpStatusCode.OK, CourseManager.ReadById(id, connection));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        public HttpResponseMessage Post([FromBody] Course course)
        {
            try
            {
                CourseManager.Create(course, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "New course created");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Course course)
        {
            try
            {
                CourseManager.Update(id, course, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Course updated");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CourseManager.Delete(id, connection);
                return Request.CreateResponse(HttpStatusCode.OK, "Course deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
