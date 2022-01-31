using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Common
{
    public class Paging
    {
        public int PageNumber { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
        public string Page()
        {

            if (PageNumber == 0 && ItemsPerPage == 0)
            {
                return String.Format("");
            }

            int Offset = (PageNumber - 1) * ItemsPerPage;

            return String.Format(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", Offset, ItemsPerPage);
        }
    }
}
