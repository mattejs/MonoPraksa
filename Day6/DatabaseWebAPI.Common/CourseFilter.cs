﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWebAPI.Common
{
    public class CourseFilter
    {
        public string SearchBy { get; set; }
        public string FilterValue { get; set; }

        public string Filter()
        {
            if (FilterValue == null)
            {
                return String.Format("");
            }

            return String.Format(" WHERE {0} LIKE '%{1}%'", SearchBy, FilterValue);

        }
    }
}
