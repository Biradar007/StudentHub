using SH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository.Configuration
{
    public class CourseInfoConfig : EntityTypeConfiguration<CourseInfo>
    {
        public CourseInfoConfig()
        {
            ToTable("CourseInfo");
            HasKey(i => i.CourseId);
            Property(i => i.CourseName).IsRequired();
            Property(i => i.Cloak);
        }
    }
}
