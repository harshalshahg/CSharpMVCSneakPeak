namespace BrandApp.Services.Migrations
{
    using Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BrandApp.Services.Integration.Implementation.EF.CustomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BrandApp.Services.Integration.Implementation.EF.CustomContext context)
        {
            var Brands = new List<Brand>
            {
                new Brand {Name="Coca-Cola", Description="Always", BrandImgUrl="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRq2KSUddkSHKcnuXIOQD4AukfxzPZ_Lw5j62AvGJSus-9OoGhi" },
                new Brand {Name="Kohl's", Description="Incredible savings", BrandImgUrl="http://www.hoursmom.com/themes/outlet/images/testlogo/Kohls.jpeg"},
                new Brand {Name="Macy's", Description="Everything you need", BrandImgUrl="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRAG94iL9Zkwi8L9EFpEfs-G7b2Akl3Gz5oB-HDo3JAx9lkhSxBlA"},
                new Brand {Name="Microsoft", Description="simple power", BrandImgUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRLZIwpmqejYRlkpyIGjNeSGXO4rSigmWkejbESH4AvypyMDLr0FQhQcOS"}

            };
            Brands.ForEach(s => context.BrandTable.Add(s));
            context.SaveChanges();

            var promotions = new List<Promotion>
            {
            new Promotion{PromotionName="2 for one", PromotionDescription="Get 2 pay for one", BrandId = 1, PromoCode = "GET2FOR1"},
            new Promotion{PromotionName="20% off",PromotionDescription="20% off one article", BrandId = 1, PromoCode = "20%TODAY"},
            new Promotion{PromotionName="Buy one Get one 50% off",PromotionDescription="Buy one Get one 50% off", BrandId=1, PromoCode = "GET50%OFF" },
            new Promotion{PromotionName="Free Shipping", PromotionDescription="Free Shipping for order above 50$", BrandId = 2, PromoCode = "SHIPFREE"},
            new Promotion{PromotionName="5$ OFF Shipping", PromotionDescription="5$ Off on your shipping Charges", BrandId = 3, PromoCode = "5$OFFSHIPPING"},
             new Promotion{PromotionName="10% OFF", PromotionDescription="10% OFF on shopping of 100$", BrandId = 3, PromoCode ="10%OVER100$"}
            };

            promotions.ForEach(s => context.PromotionTable.Add(s));
            context.SaveChanges();
        }
    }
}
