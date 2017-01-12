using BrandApp.Services.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Integration.Implementation.EF
{
    public class CustomContext : DbContext
    {
        public CustomContext() : base("name = CustomContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Brand> BrandTable { get; set; }
        public DbSet<Promotion> PromotionTable { get; set; }
        public DbSet<UserBrand> UserBrandTable { get; set; }
        public DbSet<User> UserTable { get; set; }
    }
}
