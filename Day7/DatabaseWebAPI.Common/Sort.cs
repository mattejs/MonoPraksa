using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Common
{
    public class Sort
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string Sorting()
        {
            if (SortBy == null || SortOrder == null)
            {
                return String.Format("");
            }
            else 
            {
                return String.Format(" ORDER BY {0} {1}", SortBy, SortOrder);
            }


        }
    }
}
