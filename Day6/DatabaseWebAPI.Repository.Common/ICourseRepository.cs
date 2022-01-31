using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Repository.Common
{
    public interface ICourseRepository
    {
        Task<List<ICourse>> Read(Paging paging, CourseFilter filter, Sort sorter);
        Task<ICourse> ReadById(int id);
        Task<ICourse> ReadCourseStudent(int id);
        Task Create(ICourse course);
        Task Update(int id, ICourse course);
        Task Delete(int id);
    }
}
