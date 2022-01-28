using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;

namespace DatabaseWebAPI.Repository.Common
{
    public interface ICourseRepository
    {
        Task<List<ICourse>> Read();
        Task<ICourse> ReadById(int id);
        Task Create(ICourse course);
        Task Update(int id, ICourse course);
        Task Delete(int id);
    }
}
