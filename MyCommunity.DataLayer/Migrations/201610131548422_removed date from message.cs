namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeddatefrommessage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false));
        }
    }
}