namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class News : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Date = c.DateTime(nullable: false),
                        NewsCategories_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategories_Id)
                .Index(t => t.NewsCategories_Id);
            
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewsCategories_Id", "dbo.NewsCategories");
            DropIndex("dbo.News", new[] { "NewsCategories_Id" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.News");
        }
    }
}
