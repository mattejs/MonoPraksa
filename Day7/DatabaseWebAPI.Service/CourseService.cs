using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Service
{
    public class CourseService : ICourseService
    {
        public CourseService(ICourseRepository courseRepository)
        {
            this.Course = courseRepository;
        }
        protected ICourseRepository Course { get; set; }
        public async Task<List<ICourse>> Get(Paging paging, CourseFilter filter, Sort sorter)
        {
            return await Course.Read(paging, filter, sorter);      
        }

        public async Task<ICourse> GetById(int id)
        {
            return await Course.ReadById(id);
        }
        public async Task<ICourse> GetCourseStudent(int id)
        {
            return await Course.ReadCourseStudent(id);
        }

        public async Task Post(ICourse course)
        {
            await Course.Create(course);
        }

        public async Task Put(int id, ICourse course)
        {
            await Course.Update(id, course);
        }

        public async Task Delete(int id)
        {
            await Course.Delete(id);
        }
    }
}
