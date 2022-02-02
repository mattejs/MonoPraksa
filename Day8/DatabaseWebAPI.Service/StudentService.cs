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
        public StudentService(IStudentRepository studentRepository)
        {
            this.StudentRepository = studentRepository;
        }
        protected IStudentRepository StudentRepository { get; set; }
        public async Task<List<IStudent>> Get(Paging paging, StudentFilter filter, Sort sorter)
        {
            return await StudentRepository.Read(paging, filter, sorter);
        }

        public async Task<IStudent> GetById(int id)
        {
            return await StudentRepository.ReadById(id);
        }

        public async Task<IStudent> GetStudentCourse(int id)
        {
            return await StudentRepository.ReadStudentCourse(id);
        }

        public async Task Post(IStudent student)
        {
            await StudentRepository.Create(student);
        }

        public async Task Put(int id, IStudent student)
        {
            await StudentRepository.Update(id, student);
        }

        public async Task Delete(int id)
        {
            await StudentRepository.Delete(id);
        }
    }
}
