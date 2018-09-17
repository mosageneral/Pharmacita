namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugsByUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BuyTheDrugs", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BuyTheDrugs", "Message", c => c.String());
        }
    }
}
