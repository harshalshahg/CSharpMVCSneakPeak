namespace BrandApp.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMovingContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        BrandImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandId = c.Int(nullable: false),
                        PromotionName = c.String(),
                        PromotionDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.UserBrands",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BrandId })
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FullName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBrands", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBrands", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Promotions", "BrandId", "dbo.Brands");
            DropIndex("dbo.UserBrands", new[] { "BrandId" });
            DropIndex("dbo.UserBrands", new[] { "UserId" });
            DropIndex("dbo.Promotions", new[] { "BrandId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserBrands");
            DropTable("dbo.Promotions");
            DropTable("dbo.Brands");
        }
    }
}
