using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using RestaurantWaitTime.Models;


namespace RestaurantWaitTime.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantWaitTime.Models.RestaurantWaitTimeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantWaitTime.Models.RestaurantWaitTimeContext context)
        {
            //load from file c:\Active_Food_Establishment.txt which contains restaurant from Boston
            //var allRestaurants = File.ReadAllLines("c:\\Active_Food_Establishment.txt").Select(a => a.Split(','));
            var allRestaurants = File.ReadAllLines("c:\\Active_Food_Establishment.txt")
                .Select(a => Regex.Split(a, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"));
            //                .Select(a =>a.Split('"')
            //                     .Select((element, index) => index % 2 == 0  // If even index
            //                                           ? element.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)  // Split the item
            //                                           : new[] { element })  // Keep the entire item
            //                     .SelectMany(element => element).ToList());
            foreach (var eachRestaurant in allRestaurants)
            {

                context.Restaurants.AddOrUpdate(x => x.RestaurantId,
                    new Restaurant()
                    {
                        RestaurantId = Guid.NewGuid().ToString(),
                        Name = eachRestaurant[0],
                        Address = eachRestaurant[1],
                        City = (eachRestaurant[2] != "") ? eachRestaurant[2] : "Unknown",
                        State = (eachRestaurant[3] != "") ? eachRestaurant[3] : "Unknown",
                        Zip = (eachRestaurant[4] != "") ? eachRestaurant[4] : "Unknown",
                        Phone = eachRestaurant[5],
                        Property_ID = eachRestaurant[6],
                        Location = eachRestaurant[7].Replace("\"", "").Replace("(", "").Replace(")", "")
                    });
            }
        }
    }
}
