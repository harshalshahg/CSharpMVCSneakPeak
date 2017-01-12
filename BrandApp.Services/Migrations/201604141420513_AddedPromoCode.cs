namespace BrandApp.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPromoCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "PromoCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "PromoCode");
        }
    }
}
