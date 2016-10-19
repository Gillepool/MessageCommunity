namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GroupMessages", "MessageTitle", c => c.String());
            AlterColumn("dbo.GroupMessages", "MessageBody", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GroupMessages", "MessageBody", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.GroupMessages", "MessageTitle", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
