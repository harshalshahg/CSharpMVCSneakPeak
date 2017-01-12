using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Mappings
{
    class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("User");

            this.Property(u => u.FullName)
                .HasMaxLength(100);

            this.Property(u => u.Email)
                .HasMaxLength(100);
        }
    }
}
