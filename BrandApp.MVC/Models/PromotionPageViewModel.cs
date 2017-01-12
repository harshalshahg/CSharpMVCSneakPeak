using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApp.MVC.Models
{
    public class PromotionPageViewModel
    {
        public string PromotionName { get; set; }
        public string PromotionDescription { get; set; }
        public int PromotionId { get; set; }
        public string PromoCode { get; set; }
    }
}