using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Entities
{
    public class StudentInfo
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set;}
        public string StudentPhone { get; set;} 
        public DateTime DOB { get;set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool StudentStatus { get; set;}
        public string Gender { get; set; }
        public string Courses { get; set; }
        public bool Cloak { get; set; }
        public string Description { get; set; }

    }
}
