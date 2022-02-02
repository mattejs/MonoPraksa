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
    public class CoursesController : ApiController
    {
        public CoursesController(ICourseService courseService)
        {
            this.CourseService = courseService;
        }
        protected ICourseService CourseService { get; set; }

        [Route("courses")]
        public async Task<HttpResponseMessage> Get([FromUri]Paging paging, [FromUri] CourseFilter filter, [FromUri] Sort sorter)
        {
            try 
            {
                List<CourseViewModel> courses = new List<CourseViewModel>();
                List<ICourse> courseList = await CourseService.Get(paging, filter, sorter);
                foreach (Course c in courseList)
                {
                    courses.Add(new CourseViewModel()
                    {
                        CourseName = c.CourseName
                    });

                };

                return Request.CreateResponse(HttpStatusCode.OK, courses);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }

        }

        [Route("courses/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {

            try
            {
                CourseViewModel courseViewModelById = new CourseViewModel();
                ICourse courseById = await CourseService.GetById(id);

                courseViewModelById.CourseName = courseById.CourseName;

                return Request.CreateResponse(HttpStatusCode.OK, courseViewModelById);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }

        [Route("courses")]
        public async Task<HttpResponseMessage> Post([FromBody] CourseViewModel course)
        {
            try
            {
                ICourse coursePost = new Course();
                await CourseService.Post(coursePost);
                return Request.CreateResponse(HttpStatusCode.OK, "New course created");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Route("courses/{id}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody] CourseViewModel course)
        {
            try
            {
                ICourse coursePut = new Course();
                await CourseService.Put(id, coursePut);
                return Request.CreateResponse(HttpStatusCode.OK, "Course updated");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        [Route("courses/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                await CourseService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Course deleted");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("courses/{id}/students")]
        public async Task<HttpResponseMessage> GetCourseStudent(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await CourseService.GetCourseStudent(id));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
