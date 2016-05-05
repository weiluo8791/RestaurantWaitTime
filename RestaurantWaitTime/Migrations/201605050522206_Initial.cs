namespace RestaurantWaitTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                        Phone = c.String(),
                        WebSite = c.String(),
                        Email = c.String(),
                        Hours = c.String(),
                        Cuisine = c.String(),
                        Capacity = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.RestaurantUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdpId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdpId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.WaitTimes",
                c => new
                    {
                        RestaurantId = c.String(nullable: false, maxLength: 128),
                        GroupNumber = c.Int(nullable: false),
                        WaitDateTime = c.DateTime(nullable: false),
                        Wait = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RestaurantId, t.GroupNumber, t.WaitDateTime });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WaitTimes");
            DropTable("dbo.Users");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.RestaurantUsers");
            DropTable("dbo.Restaurants");
        }
    }
}
