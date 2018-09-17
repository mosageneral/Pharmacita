namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyTheDrug : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyTheDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        BuyDate = c.DateTime(nullable: false),
                        DrugId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drugs", t => t.DrugId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.DrugId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyTheDrugs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BuyTheDrugs", "DrugId", "dbo.Drugs");
            DropIndex("dbo.BuyTheDrugs", new[] { "UserId" });
            DropIndex("dbo.BuyTheDrugs", new[] { "DrugId" });
            DropTable("dbo.BuyTheDrugs");
        }
    }
}
