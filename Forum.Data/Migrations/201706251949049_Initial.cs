namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ThreadID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(),
                        Stars = c.Int(),
                        MessageStatusID = c.Int(nullable: false),
                        MessageTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .ForeignKey("dbo.MessageStatus", t => t.MessageStatusID)
                .ForeignKey("dbo.MessageType", t => t.MessageTypeID)
                .ForeignKey("dbo.Thread", t => t.ThreadID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.ThreadID)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID)
                .Index(t => t.MessageStatusID)
                .Index(t => t.MessageTypeID);
            
            CreateTable(
                "dbo.MessageStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MessageType",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Thread",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ViewsCount = c.Int(nullable: false),
                        Stars = c.Int(),
                        ThreadStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ThreadStatus", t => t.ThreadStatusID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ThreadStatusID);
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(maxLength: 250),
                        UserStatusID = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Reputation = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusID)
                .Index(t => t.UserStatusID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SysAppEvent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SysAppEventTypeID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        UserIP = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysAppEventType", t => t.SysAppEventTypeID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.SysAppEventTypeID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.SysAppEventType",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysLoginLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UserIP = c.String(nullable: false),
                        SourceInfo = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Signature = c.String(),
                        UserID = c.Int(nullable: false),
                        UserReputationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Seniority", t => t.UserReputationID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.UserReputationID);
            
            CreateTable(
                "dbo.Seniority",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserStatusID", "dbo.UserStatus");
            DropForeignKey("dbo.UserRole", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserRole", "RoleID", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserProfile", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfile", "UserReputationID", "dbo.Seniority");
            DropForeignKey("dbo.Thread", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.SysLoginLog", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.SysAppEvent", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.SysAppEvent", "SysAppEventTypeID", "dbo.SysAppEventType");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Message", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Thread", "ThreadStatusID", "dbo.ThreadStatus");
            DropForeignKey("dbo.Message", "ThreadID", "dbo.Thread");
            DropForeignKey("dbo.Message", "MessageTypeID", "dbo.MessageType");
            DropForeignKey("dbo.Message", "MessageStatusID", "dbo.MessageStatus");
            DropForeignKey("dbo.Message", "CategoryID", "dbo.Category");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleID" });
            DropIndex("dbo.UserRole", new[] { "UserID" });
            DropIndex("dbo.UserProfile", new[] { "UserReputationID" });
            DropIndex("dbo.UserProfile", new[] { "UserID" });
            DropIndex("dbo.SysLoginLog", new[] { "UserID" });
            DropIndex("dbo.SysAppEvent", new[] { "UserID" });
            DropIndex("dbo.SysAppEvent", new[] { "SysAppEventTypeID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "UserStatusID" });
            DropIndex("dbo.Thread", new[] { "ThreadStatusID" });
            DropIndex("dbo.Thread", new[] { "UserID" });
            DropIndex("dbo.Message", new[] { "MessageTypeID" });
            DropIndex("dbo.Message", new[] { "MessageStatusID" });
            DropIndex("dbo.Message", new[] { "CategoryID" });
            DropIndex("dbo.Message", new[] { "UserID" });
            DropIndex("dbo.Message", new[] { "ThreadID" });
            DropTable("dbo.UserStatus");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserRole");
            DropTable("dbo.Seniority");
            DropTable("dbo.UserProfile");
            DropTable("dbo.SysLoginLog");
            DropTable("dbo.SysAppEventType");
            DropTable("dbo.SysAppEvent");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ThreadStatus");
            DropTable("dbo.Thread");
            DropTable("dbo.MessageType");
            DropTable("dbo.MessageStatus");
            DropTable("dbo.Message");
            DropTable("dbo.Category");
        }
    }
}
