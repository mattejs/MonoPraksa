using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseWebAPI.Service;
using DatabaseWebAPI.Model;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseWebAPI.Service.Common;

namespace DatabaseWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        public StudentsController()
        {
        }
        protected IStudentService Student = new StudentService();
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Student.Get());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }

        }

        public HttpResponseMessage GetById(int id)
        {

            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, Student.GetById(id));
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
                Student.Post(student);
                return Request.CreateResponse(HttpStatusCode.OK, "New student created");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            try
            {
                Student.Put(id, student);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated");
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
                Student.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
