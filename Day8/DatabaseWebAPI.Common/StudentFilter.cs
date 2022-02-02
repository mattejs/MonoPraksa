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

        public string AddFilter()
        {
            if (SearchBy == null || SearchBy == "" || FilterValue =="" || FilterValue == null)
            {
                return String.Format("");
            }
            else 
            {

                return String.Format(" WHERE {0} LIKE '%{1}%'", SearchBy, FilterValue);
            }

        }
    }
}
