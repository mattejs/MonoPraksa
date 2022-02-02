using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseWebAPI.Service;
using DatabaseWebAPI.Model;
using DatabaseWebAPI.Model.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DatabaseWebAPI.Service.Common;
using System.Threading.Tasks;
using DatabaseWebAPI.Models;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        public StudentsController(IStudentService studentService)
        {
            this.StudentService = studentService;
        }
        protected IStudentService StudentService { get; set; }

        [Route("students")]
        public async Task<HttpResponseMessage> Get([FromUri] Paging paging, [FromUri] StudentFilter filter, [FromUri] Sort sorter)
        {
            try
            {
                List<StudentViewModel> students = new List<StudentViewModel>();
                List<IStudent> studentList = await StudentService.Get(paging, filter, sorter);
                foreach(Student s in studentList)
                {
                    students.Add(new StudentViewModel()
                    {
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    });
                    
                };
                return Request.CreateResponse(HttpStatusCode.OK, students);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }

        }

        [Route("students/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {

            try
            {
                StudentViewModel studentViewModelById = new StudentViewModel();
                IStudent studentById = await StudentService.GetById(id);
                studentViewModelById.FirstName = studentById.FirstName;
                studentViewModelById.LastName = studentById.LastName;

                return Request.CreateResponse(HttpStatusCode.OK, studentViewModelById);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        [Route("students")]
        public async Task<HttpResponseMessage> Post([FromBody] StudentViewModel student)
        {
            try
            {
                IStudent studentPost = new Student();
                await StudentService.Post(studentPost);

                return Request.CreateResponse(HttpStatusCode.OK, "New student created");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Route("students/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] StudentViewModel student)
        {
            try
            {
                IStudent studentPut = new Student();
                await StudentService.Put(id, studentPut);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        [Route("students/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await StudentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("students/{id}/courses")]
        public async Task<HttpResponseMessage> GetStudentCourse(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await StudentService.GetStudentCourse(id));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
