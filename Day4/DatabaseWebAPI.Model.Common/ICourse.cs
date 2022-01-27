using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseWebAPI.Model.Common
{
    public interface ICourse
    {
        int CourseId { get; set; }
        string CourseName { get; set; }
    }
}
