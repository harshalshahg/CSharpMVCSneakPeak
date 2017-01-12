namespace BrandApp.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_index_unique : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(maxLength: 20));
            CreateIndex("dbo.Users", "UserName", unique: true, name: "UserNameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "UserNameIndex");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
