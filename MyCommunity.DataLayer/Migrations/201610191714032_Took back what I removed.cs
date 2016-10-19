namespace MyCommunity.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookbackwhatIremoved : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GroupMessages", name: "Sender_Id", newName: "SenderId");
            RenameIndex(table: "dbo.GroupMessages", name: "IX_Sender_Id", newName: "IX_SenderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GroupMessages", name: "IX_SenderId", newName: "IX_Sender_Id");
            RenameColumn(table: "dbo.GroupMessages", name: "SenderId", newName: "Sender_Id");
        }
    }
}
