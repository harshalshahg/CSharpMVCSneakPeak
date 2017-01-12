using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Domain.Model
{
    public class Promotion : BaseEntity
    {
        public int BrandId { get; set; }
        public string PromotionName { get; set; }
        public string PromotionDescription { get; set; }
        public Brand Brand { get; set; }
        public string PromoCode { set; get; }
    }
}
