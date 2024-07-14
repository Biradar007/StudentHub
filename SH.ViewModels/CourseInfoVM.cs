using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SH.ViewModels
{
    public class CourseInfoVM
    {
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public bool Cloak { get; set; }

        //Server side
        public string start { get; set; }
        public string draw { get; set; }
        public string length { get; set; }
        public string sortColumnName { get; set; }
        public string sortDirection { get; set; }
        public string searchValue { get; set; }
        public int recordsTotal { get; set; }
        public int skip { get; set; }
        public int pageSize { get; set; }
    }
}
