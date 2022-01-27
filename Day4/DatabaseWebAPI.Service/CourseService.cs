using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Service
{
    public class CourseService : ICourseService
    {
        public CourseService()
        {

        }
        protected ICourseRepository Course = new CourseRepository();
        public List<ICourse> Get()
        {
            return Course.Read();      
        }

        public ICourse GetById(int id)
        {
            return Course.ReadById(id);
        }

        public void Post(ICourse course)
        {
            Course.Create(course);
        }

        public void Put(int id, ICourse course)
        {
            Course.Update(id, course);
        }

        public void Delete(int id)
        {
            Course.Delete(id);
        }
    }
}
