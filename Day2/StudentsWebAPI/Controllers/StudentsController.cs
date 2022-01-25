using StudentsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsWebAPI.Controllers
{
    public class StudentsController : ApiController
    {             

        // GET api/students
        public HttpResponseMessage Get()
        {
            if(StudentsList.Read().Count == 0) 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data");
            }
            else if(StudentsList.Read() != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, StudentsList.Read());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }
        }

        // GET api/students/5
        public HttpResponseMessage GetById(int id)
        {
            if(StudentsList.GetById(id) != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, StudentsList.GetById(id));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no student with ID: " + id);
            }            
        }


        // POST api/students
        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {
                StudentsList.Create(student);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }
        }

        // PUT api/students/5
        public HttpResponseMessage Put(int id, [FromBody] Student student)
        {
            if (StudentsList.GetById(id) != null)
            {
                StudentsList.Update(id, student);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Can't update, there is no student with ID: " + id);
            }

        }

        // DELETE api/students/5
        public HttpResponseMessage Delete(int id)
        {
            if (StudentsList.GetById(id) != null)
            {
                StudentsList.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Can't delete, there is no student with ID: " + id);
            }
        }
    }

}
