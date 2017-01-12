using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Model
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string BrandImgUrl { get; set; }
        public virtual ICollection<UserBrand> UserBrand { get; set; }
        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}
