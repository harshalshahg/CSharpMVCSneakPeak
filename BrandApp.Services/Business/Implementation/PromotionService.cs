using BrandApp.Services.Domain.Model;
using BrandApp.Services.Integration.Implementation.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandApp.Services.Business.Implementation
{
    public class PromotionService
    {
        public static List<Promotion> GetPromotionsForBrandId(int BrandId)
        {
            List<Promotion> promoList = new List<Promotion>();
            using (CustomContext ctx = new CustomContext())
            {
                promoList = ctx.PromotionTable.Where(a => a.BrandId == BrandId).ToList();
                    
            }
            return promoList;
        }

        public static Promotion GetPromotionsByPromotionId(int promoId)
        {
            Promotion promo = new Promotion();
            using (CustomContext ctx = new CustomContext())
            {
                promo = ctx.PromotionTable.Where(a => a.Id == promoId).FirstOrDefault();

            }
            return promo;
        }
    }
}
