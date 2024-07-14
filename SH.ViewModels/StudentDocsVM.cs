using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.ViewModels
{
    public class StudentDocsVM
    {
        public int Id { get; set; }
        public string StudentID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileType { get; set; }
        public String FilePath { get; set; }
        public bool Cloak { get; set; }
    }
}
