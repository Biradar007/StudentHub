using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Entities
{
    public class StudentDocs
    {
        public int Id { get; set; }
        public string StudentID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public String FilePath { get; set; }
        public bool Cloak { get; set; }
    }
}
