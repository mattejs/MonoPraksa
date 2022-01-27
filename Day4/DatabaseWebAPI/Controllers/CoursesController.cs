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
    public class CoursesController : ApiController
    {
        public CoursesController()
        {
            
        }
        protected ICourseService Course = new CourseService();

        public HttpResponseMessage Get()
        {
            try 
            {
                return Request.CreateResponse(HttpStatusCode.OK, Course.Get());
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
                return Request.CreateResponse(HttpStatusCode.OK, Course.GetById(id));
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
                Course.Post(course);
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
                Course.Put(id, course);
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
                Course.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Course deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
