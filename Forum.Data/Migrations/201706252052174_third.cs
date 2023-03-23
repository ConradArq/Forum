namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "RoleID", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserRole", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.UserRole", new[] { "RoleID" });
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String(maxLength: 100));
            DropTable("dbo.UserRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String());
            CreateIndex("dbo.UserRole", "RoleID");
            CreateIndex("dbo.UserRole", "UserID");
            AddForeignKey("dbo.UserRole", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserRole", "RoleID", "dbo.AspNetRoles", "Id");
        }
    }
}
