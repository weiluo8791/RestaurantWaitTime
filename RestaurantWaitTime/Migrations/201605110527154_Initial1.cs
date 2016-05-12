namespace RestaurantWaitTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "preferLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "preferLocation");
        }
    }
}
