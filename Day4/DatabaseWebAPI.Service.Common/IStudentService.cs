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

        List<IStudent> Get();

        IStudent GetById(int id);
        void Post(IStudent student);
        void Put(int id, IStudent student);
        void Delete(int id);
    }
}
