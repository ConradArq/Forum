namespace Forum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String(nullable: false));
        }
    }
}
