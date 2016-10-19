namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somevaribleisintnow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupMessages", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.GroupMessages", new[] { "Group_GroupId" });
            DropColumn("dbo.GroupMessages", "GroupId");
            RenameColumn(table: "dbo.GroupMessages", name: "Group_GroupId", newName: "GroupId");
            AlterColumn("dbo.GroupMessages", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.GroupMessages", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.GroupMessages", "GroupId");
            AddForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMessages", "GroupId", "dbo.Groups");
            DropIndex("dbo.GroupMessages", new[] { "GroupId" });
            AlterColumn("dbo.GroupMessages", "GroupId", c => c.Int());
            AlterColumn("dbo.GroupMessages", "GroupId", c => c.String());
            RenameColumn(table: "dbo.GroupMessages", name: "GroupId", newName: "Group_GroupId");
            AddColumn("dbo.GroupMessages", "GroupId", c => c.String());
            CreateIndex("dbo.GroupMessages", "Group_GroupId");
            AddForeignKey("dbo.GroupMessages", "Group_GroupId", "dbo.Groups", "GroupId");
        }
    }
}
