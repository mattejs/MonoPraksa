using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseWebAPI.Model.Common;

namespace DatabaseWebAPI.Repository.Common
{
    public interface IStudentRepository
    {
        Task<List<IStudent>> Read();
        Task<IStudent> ReadById(int id);
        Task Create(IStudent student);
        Task Update(int id, IStudent student);
        Task Delete(int id);
    }
}
