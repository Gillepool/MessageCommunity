namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "NumberOfMessages", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumberOfReadMessages", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NumberOfdeletedMessages", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastLogin", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "numberOfLoginsLastMonth", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "ApplicationUser_Id");
            CreateIndex("dbo.Messages", "ApplicationUser_Id1");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "numberOfLoginsLastMonth");
            DropColumn("dbo.AspNetUsers", "LastLogin");
            DropColumn("dbo.AspNetUsers", "NumberOfdeletedMessages");
            DropColumn("dbo.AspNetUsers", "NumberOfReadMessages");
            DropColumn("dbo.AspNetUsers", "NumberOfMessages");
            DropColumn("dbo.Messages", "ApplicationUser_Id1");
            DropColumn("dbo.Messages", "ApplicationUser_Id");
        }
    }
}
