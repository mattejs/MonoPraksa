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
        List<ICourse> Read();
        ICourse ReadById(int id);
        void Create(ICourse course);
        void Update(int id, ICourse course);
        void Delete(int id);
    }
}
