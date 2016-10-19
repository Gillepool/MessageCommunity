namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsomething : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GroupMessages", "GroupSenderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupMessages", "GroupSenderId", c => c.String());
        }
    }
}
