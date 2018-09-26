namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Find : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrugFinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugName = c.String(nullable: false),
                        DrugDescribtion = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrugFinds", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DrugFinds", new[] { "UserId" });
            DropTable("dbo.DrugFinds");
        }
    }
}
