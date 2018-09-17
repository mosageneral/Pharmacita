namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDrug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drugs", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Drugs", "UserId");
            AddForeignKey("dbo.Drugs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drugs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Drugs", new[] { "UserId" });
            DropColumn("dbo.Drugs", "UserId");
        }
    }
}
