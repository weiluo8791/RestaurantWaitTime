using System.Data.Entity;

namespace RestaurantWaitTime.Models
{
    public class RestaurantWaitTimeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RestaurantWaitTimeContext() : base("name=RestaurantWaitTimeContext")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<WaitTime> WaitTimes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public System.Data.Entity.DbSet<RestaurantWaitTime.Models.RestaurantUser> RestaurantUsers { get; set; }
    }
}
