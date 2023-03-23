namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaintainableEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Thread", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Message", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Thread", "UserID", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Message", name: "UserID", newName: "CreationUserID");
            RenameColumn(table: "dbo.Thread", name: "UserID", newName: "CreationUserID");
            RenameIndex(table: "dbo.Message", name: "IX_UserID", newName: "IX_CreationUserID");
            RenameIndex(table: "dbo.Thread", name: "IX_UserID", newName: "IX_CreationUserID");
            AddColumn("dbo.Message", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Message", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.Message", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.Message", "DeletedUserID", c => c.Int());
            AddColumn("dbo.Thread", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Thread", "ModifiedUserID", c => c.Int());
            AddColumn("dbo.Thread", "DeletedDate", c => c.DateTime());
            AddColumn("dbo.Thread", "DeletedUserID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ModifiedDate", c => c.DateTime());
            AddForeignKey("dbo.Message", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Thread", "StatusID", "dbo.Status", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Message", "CreationUserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Thread", "CreationUserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thread", "CreationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "CreationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Thread", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Message", "StatusID", "dbo.Status");
            DropColumn("dbo.AspNetUsers", "ModifiedDate");
            DropColumn("dbo.Thread", "DeletedUserID");
            DropColumn("dbo.Thread", "DeletedDate");
            DropColumn("dbo.Thread", "ModifiedUserID");
            DropColumn("dbo.Thread", "ModifiedDate");
            DropColumn("dbo.Message", "DeletedUserID");
            DropColumn("dbo.Message", "DeletedDate");
            DropColumn("dbo.Message", "ModifiedUserID");
            DropColumn("dbo.Message", "ModifiedDate");
            RenameIndex(table: "dbo.Thread", name: "IX_CreationUserID", newName: "IX_UserID");
            RenameIndex(table: "dbo.Message", name: "IX_CreationUserID", newName: "IX_UserID");
            RenameColumn(table: "dbo.Thread", name: "CreationUserID", newName: "UserID");
            RenameColumn(table: "dbo.Message", name: "CreationUserID", newName: "UserID");
            AddForeignKey("dbo.Thread", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Message", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Thread", "StatusID", "dbo.Status", "ID");
            AddForeignKey("dbo.Message", "StatusID", "dbo.Status", "ID");
        }
    }
}
