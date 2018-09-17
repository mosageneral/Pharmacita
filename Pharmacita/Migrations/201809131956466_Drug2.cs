namespace Pharmacita.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drug2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drugs", "Expire", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drugs", "Expire", c => c.DateTime(nullable: false));
        }
    }
}
