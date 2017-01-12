using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Model
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FullName { get; set; }

        [Index("UserNameIndex", IsUnique = true)]
        [MaxLength(20)]
        public string UserName { get; set; }

        public string Password { get; set; }
        public ICollection<UserBrand> UserBrand { get; set; }
    }
}
