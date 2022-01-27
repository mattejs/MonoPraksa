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
        List<IStudent> Read();
        IStudent ReadById(int id);
        void Create(IStudent student);
        void Update(int id, IStudent student);
        void Delete(int id);
    }
}
