using DatabaseWebAPI.Model.Common;
using DatabaseWebAPI.Repository;
using DatabaseWebAPI.Repository.Common;
using DatabaseWebAPI.Service.Common;
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
        public List<IStudent> Get()
        {
            return Student.Read();
        }

        public IStudent GetById(int id)
        {
            return Student.ReadById(id);
        }

        public void Post(IStudent student)
        {
            Student.Create(student);
        }

        public void Put(int id, IStudent student)
        {
            Student.Update(id, student);
        }

        public void Delete(int id)
        {
            Student.Delete(id);
        }
    }
}
