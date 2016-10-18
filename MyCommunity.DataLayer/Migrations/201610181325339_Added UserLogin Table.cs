namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserLoginTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        TimeOfLogin = c.DateTime(nullable: false),
                        LoggedInUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.AspNetUsers", t => t.LoggedInUser_Id)
                .Index(t => t.LoggedInUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLogins", "LoggedInUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserLogins", new[] { "LoggedInUser_Id" });
            DropTable("dbo.UserLogins");
        }
    }
}
