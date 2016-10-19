namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupsandGroupMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupMessages",
                c => new
                    {
                        GroupMessageId = c.Int(nullable: false, identity: true),
                        MessageTitle = c.String(nullable: false, maxLength: 50),
                        MessageBody = c.String(nullable: false, maxLength: 255),
                        PostDate = c.DateTime(nullable: false),
                        GroupSenderId = c.String(),
                        GroupId = c.String(),
                        Group_GroupId = c.Int(),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GroupMessageId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMessages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupMessages", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.GroupMessages", new[] { "Sender_Id" });
            DropIndex("dbo.GroupMessages", new[] { "Group_GroupId" });
            DropTable("dbo.GroupMessages");
        }
    }
}
