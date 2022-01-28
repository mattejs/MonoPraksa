using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;

namespace DatabaseWebAPI.Service.Common
{
    public interface IStudentService
    {

        Task<List<IStudent>> Get();

        Task<IStudent> GetById(int id);
        Task Post(IStudent student);
        Task Put(int id, IStudent student);
        Task Delete(int id);
    }
}
