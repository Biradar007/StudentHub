using SH.Entities;
using SH.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository
{
    public class SHContext : DbContext
    {
        public SHContext() : base("CONN")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SHContext>(null);
            modelBuilder.Configurations.Add(new StudentInfoConfig());
            modelBuilder.Configurations.Add(new CourseInfoConfig());
            modelBuilder.Configurations.Add(new RegisterUserConfig());
            modelBuilder.Configurations.Add(new StudentDocsConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<CourseInfo> CourseInfo { get; set; }
        public DbSet<RegisterUser> RegisterUser { get; set; }
        public DbSet<StudentDocs> StudentDocs { get; set; }
    }

}
