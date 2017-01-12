using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Mappings
{
    class PromotionMapping : EntityTypeConfiguration<Promotion>
    {
        public PromotionMapping()
        {
            this.ToTable("Promotion");

            this.HasRequired(p => p.Brand) //  Object
                .WithMany(brand => brand.Promotion) //collection
                .HasForeignKey(ub => ub.BrandId) //F.K. ID
                .WillCascadeOnDelete(true);

            this.Property(p => p.PromotionName)
                .HasMaxLength(100);

        }
    }
}
