using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsWebAPI.Models
{
    public static class StudentsList
    {
        static List<Student> students = new List<Student>();
        static int nextId = 1;

        public static Student GetById(int id) => students.FirstOrDefault(p => p.Id == id);

        public static void Create(Student student)
        {
            student.Id = nextId++;
            students.Add(student);
        }

        public static List<Student> Read()
        {
            return students;
        }
        public static void Update(int id, Student student)
        {
            var index = new Student();
            index= students.Where(p => p.Id == id).FirstOrDefault();
            index.FirstName = student.FirstName;
            index.LastName = student.LastName;
        }

        public static void Delete(int id)
        {            
            var student = GetById(id);
            students.Remove(student);            
        }

    }
}