using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Newtonsoft.Json;

namespace RestaurantWaitTime.Models
{

    [CustomValidation(typeof(Restaurant), "ValidateRestaurantDetail")]
    public class Restaurant
    {        
        [Key]
        [JsonIgnore]
        [Column(Order = 1)]
        public string RestaurantId { get; set; }
        [Required]
        [Column(Order = 2)]
        public string Name { get; set; }
        [Column(Order = 3)]
        public string Address { get; set; }
        [Required]
        [Column(Order = 4)]
        public string City { get; set; }
        [Required]
        [Column(Order = 5)]
        public string State { get; set; }
        [Required]
        [Column(Order = 6)]
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
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
        [Key]
        [Column(Order = 1)]
        public string RestaurantId { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public int GroupNumber { get; set; }
        [Key]
        [Required]
        [Column(Order = 3)]
        public DateTime WaitDateTime { get; set; }
        [Required]
        public int Wait { get; set; }

        public static ValidationResult ValidateWaitTime(WaitTime waitTime, ValidationContext ctx)
        {
            return ValidationResult.Success;
        }
    }

    [CustomValidation(typeof(User), "ValidateUser")]
    public class User
    {
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