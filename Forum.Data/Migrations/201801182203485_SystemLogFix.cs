namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemLogFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysAppEvent", "Trace", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysAppEvent", "Trace");
        }
    }
}
