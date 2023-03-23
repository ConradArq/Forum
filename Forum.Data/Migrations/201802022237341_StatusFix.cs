namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "MessageStatusID", "dbo.MessageStatus");
            DropForeignKey("dbo.Thread", "ThreadStatusID", "dbo.ThreadStatus");
            DropForeignKey("dbo.AspNetUsers", "UserStatusID", "dbo.UserStatus");
            DropIndex("dbo.Message", new[] { "MessageStatusID" });
            DropIndex("dbo.Thread", new[] { "ThreadStatusID" });
            DropIndex("dbo.AspNetUsers", new[] { "UserStatusID" });
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Message", "StatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Thread", "StatusID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "StatusID", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "StatusID");
            CreateIndex("dbo.Thread", "StatusID");
            CreateIndex("dbo.AspNetUsers", "StatusID");
            AddForeignKey("dbo.Message", "StatusID", "dbo.Status", "ID");
            AddForeignKey("dbo.Thread", "StatusID", "dbo.Status", "ID");
            AddForeignKey("dbo.AspNetUsers", "StatusID", "dbo.Status", "ID");
            DropColumn("dbo.Message", "MessageStatusID");
            DropColumn("dbo.Thread", "ThreadStatusID");
            DropColumn("dbo.AspNetUsers", "UserStatusID");
            DropTable("dbo.MessageStatus");
            DropTable("dbo.ThreadStatus");
            DropTable("dbo.UserStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ThreadStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MessageStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "UserStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Thread", "ThreadStatusID", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "MessageStatusID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Thread", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Message", "StatusID", "dbo.Status");
            DropIndex("dbo.AspNetUsers", new[] { "StatusID" });
            DropIndex("dbo.Thread", new[] { "StatusID" });
            DropIndex("dbo.Message", new[] { "StatusID" });
            DropColumn("dbo.AspNetUsers", "StatusID");
            DropColumn("dbo.Thread", "StatusID");
            DropColumn("dbo.Message", "StatusID");
            DropTable("dbo.Status");
            CreateIndex("dbo.AspNetUsers", "UserStatusID");
            CreateIndex("dbo.Thread", "ThreadStatusID");
            CreateIndex("dbo.Message", "MessageStatusID");
            AddForeignKey("dbo.AspNetUsers", "UserStatusID", "dbo.UserStatus", "ID");
            AddForeignKey("dbo.Thread", "ThreadStatusID", "dbo.ThreadStatus", "ID");
            AddForeignKey("dbo.Message", "MessageStatusID", "dbo.MessageStatus", "ID");
        }
    }
}
