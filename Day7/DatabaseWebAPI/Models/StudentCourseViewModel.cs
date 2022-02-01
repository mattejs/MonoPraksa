using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseWebAPI.Models
{
    public class StudentCourseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}