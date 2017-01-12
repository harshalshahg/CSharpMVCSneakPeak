using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Mappings
{
    class UserBrandMapping : EntityTypeConfiguration<UserBrand>
    {
        public UserBrandMapping()
        {
            this.ToTable("UserBrand");
            //BrandId
            this.HasRequired(ub => ub.Brand)
                .WithMany(brand => brand.UserBrand)
                .HasForeignKey(ub => ub.BrandId)
                .WillCascadeOnDelete(true);

            //UserId
            this.HasRequired(ub => ub.User)
                .WithMany(brand => brand.UserBrand)
                .HasForeignKey(ub => ub.UserId)
                .WillCascadeOnDelete(true);

        }
    }
}
