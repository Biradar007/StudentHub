using SH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository.Configuration
{
    public class StudentInfoConfig : EntityTypeConfiguration<StudentInfo>
    {
        public StudentInfoConfig()
        {
            ToTable("StudentInfo");
            HasKey(i => i.StudentId);
            Property(i => i.StudentName).IsRequired();
            Property(i => i.StudentEmail);
            Property(i => i.StudentPhone);
            Property(i => i.DOB).IsRequired();
            Property(i => i.State).IsRequired();
            Property(i => i.City).IsRequired();
            Property(i => i.Country).IsRequired();
            Property(i => i.StudentStatus);
            Property(i => i.Gender).IsRequired();
            Property(i => i.Courses);
            Property(i => i.Cloak);
            Property(i => i.Description);
        }
    }
}
