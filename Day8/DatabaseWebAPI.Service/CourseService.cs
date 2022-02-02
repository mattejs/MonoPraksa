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
            this.CourseRepository = courseRepository;
        }
        protected ICourseRepository CourseRepository { get; set; }
        public async Task<List<ICourse>> Get(Paging paging, CourseFilter filter, Sort sorter)
        {
            return await CourseRepository.Read(paging, filter, sorter);      
        }

        public async Task<ICourse> GetById(int id)
        {
            return await CourseRepository.ReadById(id);
        }
        public async Task<ICourse> GetCourseStudent(int id)
        {
            return await CourseRepository.ReadCourseStudent(id);
        }

        public async Task Post(ICourse course)
        {
            await CourseRepository.Create(course);
        }

        public async Task Put(int id, ICourse course)
        {
            await CourseRepository.Update(id, course);
        }

        public async Task Delete(int id)
        {
            await CourseRepository.Delete(id);
        }
    }
}
