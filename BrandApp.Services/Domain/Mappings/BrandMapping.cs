using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Mappings
{
    class BrandMapping : EntityTypeConfiguration<Brand>
    {
        public BrandMapping()
        {
            this.ToTable("Brand");

            this.Property(p => p.Name)
                .HasMaxLength(100);

            this.Property(p => p.Name)
                .HasMaxLength(256);
        }
         
    }
}
