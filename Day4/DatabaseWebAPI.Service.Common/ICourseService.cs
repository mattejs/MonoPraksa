using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseWebAPI.Model.Common;

namespace DatabaseWebAPI.Service.Common
{
    public interface ICourseService
    {
        List<ICourse> Get();

        ICourse GetById(int id);
        void Post(ICourse course);
        void Put(int id, ICourse course);
        void Delete(int id);
    }
}
