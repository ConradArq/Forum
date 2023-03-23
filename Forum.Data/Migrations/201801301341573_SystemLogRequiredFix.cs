namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemLogRequiredFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SysAppEvent", "Description", c => c.String());
            AlterColumn("dbo.SysAppEvent", "UserIP", c => c.String());
            AlterColumn("dbo.SysLoginLog", "UserIP", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SysLoginLog", "UserIP", c => c.String(nullable: false));
            AlterColumn("dbo.SysAppEvent", "UserIP", c => c.String(nullable: false));
            AlterColumn("dbo.SysAppEvent", "Description", c => c.String(nullable: false));
        }
    }
}
