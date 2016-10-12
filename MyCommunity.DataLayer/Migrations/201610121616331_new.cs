namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "LastLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime(nullable: false));
        }
    }
}
