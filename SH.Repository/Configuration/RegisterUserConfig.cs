using SH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Repository.Configuration
{
    public class RegisterUserConfig : EntityTypeConfiguration<RegisterUser>
    {
        public RegisterUserConfig()
        {
            ToTable("RegisterUser");
            HasKey(i => i.ID);
            Property(i => i.Type).IsRequired();
            Property(i => i.Name).IsRequired();
            Property(i => i.Email).IsRequired();
            Property(i => i.DOB).IsRequired();
            Property(i => i.Password).IsRequired();
            Property(i => i.Gender).IsRequired();
            Property(i => i.Cloak);
        }
    }
}
