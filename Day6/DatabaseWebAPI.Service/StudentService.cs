using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service.Common;
using DatabaseWebAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Service
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {
        }
        protected IStudentRepository Student = new StudentRepository();
        public async Task<List<IStudent>> Get(Paging paging, StudentFilter filter, Sort sorter)
        {
            return await Student.Read(paging, filter, sorter);
        }

        public async Task<IStudent> GetById(int id)
        {
            return await Student.ReadById(id);
        }

        public async Task<IStudent> GetStudentCourse(int id)
        {
            return await Student.ReadStudentCourse(id);
        }

        public async Task Post(IStudent student)
        {
            await Student.Create(student);
        }

        public async Task Put(int id, IStudent student)
        {
            await Student.Update(id, student);
        }

        public async Task Delete(int id)
        {
            await Student.Delete(id);
        }
    }
}
