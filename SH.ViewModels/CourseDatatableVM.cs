using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.ViewModels
{
    public class CourseDatatableVM
    {
        public List<CourseInfoVM> courseInfoVM { get; set; }

        //ServerSide
        public string start { get; set; }
        public string draw { get; set; }
        public string length { get; set; }
        public string sortColumnName { get; set; }
        public string sortDirection { get; set; }
        public string searchValue { get; set; }
        public string recordsTotal { get; set; }
        public int skip { get; set; }
        public int pageSize { get; set; }
    }
}
