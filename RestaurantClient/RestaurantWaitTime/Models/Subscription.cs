﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace RestaurantClient.Models
{
    public partial class Subscription
    {
        private string _feedBack;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string FeedBack
        {
            get { return this._feedBack; }
            set { this._feedBack = value; }
        }
        
        private string _id;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private string _preferLocation;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string PreferLocation
        {
            get { return this._preferLocation; }
            set { this._preferLocation = value; }
        }
        
        private int? _rating;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Rating
        {
            get { return this._rating; }
            set { this._rating = value; }
        }
        
        private string _restaurantId;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string RestaurantId
        {
            get { return this._restaurantId; }
            set { this._restaurantId = value; }
        }
        
        private string _userId;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Subscription class.
        /// </summary>
        public Subscription()
        {
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken feedBackValue = inputObject["FeedBack"];
                if (feedBackValue != null && feedBackValue.Type != JTokenType.Null)
                {
                    this.FeedBack = ((string)feedBackValue);
                }
                JToken idValue = inputObject["Id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((string)idValue);
                }
                JToken preferLocationValue = inputObject["preferLocation"];
                if (preferLocationValue != null && preferLocationValue.Type != JTokenType.Null)
                {
                    this.PreferLocation = ((string)preferLocationValue);
                }
                JToken ratingValue = inputObject["Rating"];
                if (ratingValue != null && ratingValue.Type != JTokenType.Null)
                {
                    this.Rating = ((int)ratingValue);
                }
                JToken restaurantIdValue = inputObject["RestaurantId"];
                if (restaurantIdValue != null && restaurantIdValue.Type != JTokenType.Null)
                {
                    this.RestaurantId = ((string)restaurantIdValue);
                }
                JToken userIdValue = inputObject["UserId"];
                if (userIdValue != null && userIdValue.Type != JTokenType.Null)
                {
                    this.UserId = ((string)userIdValue);
                }
            }
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type Subscription
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Id == null)
            {
                throw new ArgumentNullException("Id");
            }
            if (this.PreferLocation == null)
            {
                throw new ArgumentNullException("PreferLocation");
            }
            if (this.RestaurantId == null)
            {
                throw new ArgumentNullException("RestaurantId");
            }
            if (this.UserId == null)
            {
                throw new ArgumentNullException("UserId");
            }
            if (this.FeedBack != null)
            {
                outputObject["FeedBack"] = this.FeedBack;
            }
            if (this.Id != null)
            {
                outputObject["Id"] = this.Id;
            }
            if (this.PreferLocation != null)
            {
                outputObject["preferLocation"] = this.PreferLocation;
            }
            if (this.Rating != null)
            {
                outputObject["Rating"] = this.Rating.Value;
            }
            if (this.RestaurantId != null)
            {
                outputObject["RestaurantId"] = this.RestaurantId;
            }
            if (this.UserId != null)
            {
                outputObject["UserId"] = this.UserId;
            }
            return outputObject;
        }
    }
}
