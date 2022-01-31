using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Common
{
    public class StudentFilter
    {
        public string SearchBy { get; set; }
        public string FilterValue { get; set; }

        public string Filter()
        {
            if (SearchBy ==null || FilterValue == null)
            {
                return String.Format("");
            }
            
            return String.Format(" WHERE {0} LIKE '%{1}%'", SearchBy, FilterValue);

        }
    }
}
