﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using UserClient;
using UserClient.Models;

namespace UserClient
{
    public static partial class RestaurantUsersExtensions
    {
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static User DeleteRestaurantUserById(this IRestaurantUsers operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).DeleteRestaurantUserByIdAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<User> DeleteRestaurantUserByIdAsync(this IRestaurantUsers operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.User> result = await operations.DeleteRestaurantUserByIdWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        public static string GetAllRestaurantUsers(this IRestaurantUsers operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).GetAllRestaurantUsersAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> GetAllRestaurantUsersAsync(this IRestaurantUsers operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.GetAllRestaurantUsersWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        public static string GetCurrentRestaurant(this IRestaurantUsers operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).GetCurrentRestaurantAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> GetCurrentRestaurantAsync(this IRestaurantUsers operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.GetCurrentRestaurantWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        public static RestaurantUser GetCurrentRestaurantUser(this IRestaurantUsers operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).GetCurrentRestaurantUserAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RestaurantUser> GetCurrentRestaurantUserAsync(this IRestaurantUsers operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.RestaurantUser> result = await operations.GetCurrentRestaurantUserWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='userId'>
        /// Required.
        /// </param>
        public static RestaurantUser GetRestaurantUserByIdByUserid(this IRestaurantUsers operations, string userId)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).GetRestaurantUserByIdByUseridAsync(userId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='userId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RestaurantUser> GetRestaurantUserByIdByUseridAsync(this IRestaurantUsers operations, string userId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.RestaurantUser> result = await operations.GetRestaurantUserByIdByUseridWithOperationResponseAsync(userId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='restaurantUser'>
        /// Required.
        /// </param>
        public static RestaurantUser PostUserByRestaurantuser(this IRestaurantUsers operations, RestaurantUser restaurantUser)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).PostUserByRestaurantuserAsync(restaurantUser);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='restaurantUser'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RestaurantUser> PostUserByRestaurantuserAsync(this IRestaurantUsers operations, RestaurantUser restaurantUser, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.RestaurantUser> result = await operations.PostUserByRestaurantuserWithOperationResponseAsync(restaurantUser, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='userId'>
        /// Required.
        /// </param>
        /// <param name='patch'>
        /// Required.
        /// </param>
        public static object PutUserByUseridAndPatch(this IRestaurantUsers operations, string userId, string patch)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IRestaurantUsers)s).PutUserByUseridAndPatchAsync(userId, patch);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.IRestaurantUsers.
        /// </param>
        /// <param name='userId'>
        /// Required.
        /// </param>
        /// <param name='patch'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PutUserByUseridAndPatchAsync(this IRestaurantUsers operations, string userId, string patch, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PutUserByUseridAndPatchWithOperationResponseAsync(userId, patch, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
