using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Newtonsoft.Json;

namespace RestaurantWaitTime.Models
{

    [CustomValidation(typeof(Restaurant), "ValidateRestaurantDetail")]
    public class Restaurant
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        [Required]
        public string Hours { get; set; }
        public string Cuisine { get; set; }
        public string Capacity { get; set; }
        public static ValidationResult ValidateRestaurantDetail(Restaurant restaurant, ValidationContext ctx)
        {
            return ValidationResult.Success;
        }
    }


    [CustomValidation(typeof(WaitTime), "ValidateWaitTime")]
    public class WaitTime
    {
        [JsonIgnore]
        public string Id { get; set; }
        [Required]
        public string RestaurantId { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]
        public int Wait { get; set; }
        [Required]
        public DateTime WaitDateTime { get; set; }

        public static ValidationResult ValidateWaitTime(WaitTime waitTime, ValidationContext ctx)
        {
            return ValidationResult.Success;
        }
    }

    [CustomValidation(typeof(User), "ValidateUser")]
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string IdpId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }

        public static ValidationResult ValidateUser(User user, ValidationContext ctx)
        {
            return ValidationResult.Success;
        }
    }


    [CustomValidation(typeof(Subscription), "ValidateSubscription")]
    public class Subscription
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RestaurantId { get; set; }
        public int Rating { get; set; }
        public string FeedBack { get; set; }

        public static ValidationResult ValidateSubscription(Subscription subscription, ValidationContext ctx)
        {
            return ValidationResult.Success;
        }
    }

}