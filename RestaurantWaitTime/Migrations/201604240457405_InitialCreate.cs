namespace RestaurantWaitTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RestaurantId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(),
                        WebSite = c.String(),
                        Email = c.String(),
                        Hours = c.String(nullable: false),
                        Cuisine = c.String(),
                        Capacity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false),
                        RestaurantId = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        FeedBack = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false),
                        IdpId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WaitTimes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RestaurantId = c.String(nullable: false),
                        Group = c.Int(nullable: false),
                        Wait = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WaitTimes");
            DropTable("dbo.Users");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Restaurants");
        }
    }
}
