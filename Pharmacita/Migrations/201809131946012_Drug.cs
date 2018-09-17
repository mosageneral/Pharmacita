namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugName = c.String(nullable: false),
                        DrugDescribtion = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DrugImage = c.String(),
                        Expire = c.DateTime(nullable: false),
                        Off = c.Decimal(nullable: false, precision: 18, scale: 2),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drugs", "categoryId", "dbo.Categories");
            DropIndex("dbo.Drugs", new[] { "categoryId" });
            DropTable("dbo.Drugs");
        }
    }
}
