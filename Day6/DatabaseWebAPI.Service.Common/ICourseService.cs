using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Service.Common
{
    public interface ICourseService
    {
        Task<List<ICourse>> Get(Paging paging, CourseFilter filter, Sort sorter);

        Task<ICourse> GetById(int id);
        Task<ICourse> GetCourseStudent(int id);
        Task Post(ICourse course);
        Task Put(int id, ICourse course);
        Task Delete(int id);
    }
}
