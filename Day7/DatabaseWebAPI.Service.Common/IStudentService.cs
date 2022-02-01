using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Common;

namespace DatabaseWebAPI.Service.Common
{
    public interface IStudentService
    {

        Task<List<IStudent>> Get(Paging paging, StudentFilter filter, Sort sorter);
        Task<IStudent> GetById(int id);
        Task<IStudent> GetStudentCourse(int id);
        Task Post(IStudent student);
        Task Put(int id, IStudent student);
        Task Delete(int id);
    }
}
