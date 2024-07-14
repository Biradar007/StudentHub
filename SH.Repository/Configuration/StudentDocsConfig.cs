using SH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository.Configuration
{
    public class StudentDocsConfig : EntityTypeConfiguration<StudentDocs>
    {
        public StudentDocsConfig()
        {
            ToTable("StudentDocs");
            HasKey(i => i.Id);
            Property(i => i.StudentID).IsRequired();
            Property(i => i.FileName).IsRequired();
            Property(i => i.FileType).IsRequired();
            Property(i => i.FilePath).IsRequired();
            Property(i => i.Cloak);
        }
    }
}
