using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Model
{
    public class UserBrand : BaseEntity
    {
        [Key]
        [Column(Order=1)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual User User { get; set; }
    }
}
