using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Model.Common
{
    public interface IStudent
    {
        int StudentId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
