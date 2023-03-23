namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemLogRequiredFix1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysLoginLog", "MachineName", c => c.String());
            DropColumn("dbo.SysLoginLog", "SourceInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SysLoginLog", "SourceInfo", c => c.String());
            DropColumn("dbo.SysLoginLog", "MachineName");
        }
    }
}
