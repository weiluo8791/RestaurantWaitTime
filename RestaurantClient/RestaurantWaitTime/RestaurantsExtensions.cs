﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using RestaurantClient;
using RestaurantClient.Models;

namespace RestaurantClient
{
    public static partial class RestaurantsExtensions
    {
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        public static Restaurant DeleteRestaurantByRestaurantid(this IRestaurants operations, string restaurantId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).DeleteRestaurantByRestaurantidAsync(restaurantId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Restaurant> DeleteRestaurantByRestaurantidAsync(this IRestaurants operations, string restaurantId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<RestaurantClient.Models.Restaurant> result = await operations.DeleteRestaurantByRestaurantidWithOperationResponseAsync(restaurantId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        public static IList<string> GetAllRestaurants(this IRestaurants operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).GetAllRestaurantsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<string>> GetAllRestaurantsAsync(this IRestaurants operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<string>> result = await operations.GetAllRestaurantsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        public static Restaurant GetRestaurantByRestaurantid(this IRestaurants operations, string restaurantId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).GetRestaurantByRestaurantidAsync(restaurantId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Restaurant> GetRestaurantByRestaurantidAsync(this IRestaurants operations, string restaurantId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<RestaurantClient.Models.Restaurant> result = await operations.GetRestaurantByRestaurantidWithOperationResponseAsync(restaurantId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='zip'>
        /// Required.
        /// </param>
        public static IList<string> GetRestaurantsByZipByZip(this IRestaurants operations, string zip)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).GetRestaurantsByZipByZipAsync(zip);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='zip'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<string>> GetRestaurantsByZipByZipAsync(this IRestaurants operations, string zip, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<string>> result = await operations.GetRestaurantsByZipByZipWithOperationResponseAsync(zip, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        public static Restaurant GetSubscribedRestaurants(this IRestaurants operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).GetSubscribedRestaurantsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Restaurant> GetSubscribedRestaurantsAsync(this IRestaurants operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<RestaurantClient.Models.Restaurant> result = await operations.GetSubscribedRestaurantsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='item'>
        /// Required.
        /// </param>
        public static Restaurant PostRestaurantByItem(this IRestaurants operations, Restaurant item)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).PostRestaurantByItemAsync(item);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='item'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Restaurant> PostRestaurantByItemAsync(this IRestaurants operations, Restaurant item, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<RestaurantClient.Models.Restaurant> result = await operations.PostRestaurantByItemWithOperationResponseAsync(item, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        /// <param name='patch'>
        /// Required.
        /// </param>
        public static object UpdateRestaurantByRestaurantidAndPatch(this IRestaurants operations, string restaurantId, string patch)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurants)s).UpdateRestaurantByRestaurantidAndPatchAsync(restaurantId, patch);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the RestaurantClient.IRestaurants.
        /// </param>
        /// <param name='restaurantId'>
        /// Required.
        /// </param>
        /// <param name='patch'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> UpdateRestaurantByRestaurantidAndPatchAsync(this IRestaurants operations, string restaurantId, string patch, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.UpdateRestaurantByRestaurantidAndPatchWithOperationResponseAsync(restaurantId, patch, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
