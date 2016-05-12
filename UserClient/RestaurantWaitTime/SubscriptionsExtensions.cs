﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using UserClient;
using UserClient.Models;

namespace UserClient
{
    public static partial class SubscriptionsExtensions
    {
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static Subscription DeleteSubscriptionById(this ISubscriptions operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISubscriptions)s).DeleteSubscriptionByIdAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Subscription> DeleteSubscriptionByIdAsync(this ISubscriptions operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.Subscription> result = await operations.DeleteSubscriptionByIdWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static Subscription GetSubscriptionById(this ISubscriptions operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISubscriptions)s).GetSubscriptionByIdAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Subscription> GetSubscriptionByIdAsync(this ISubscriptions operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.Subscription> result = await operations.GetSubscriptionByIdWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        public static IList<Subscription> GetSubscriptions(this ISubscriptions operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISubscriptions)s).GetSubscriptionsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<Subscription>> GetSubscriptionsAsync(this ISubscriptions operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<UserClient.Models.Subscription>> result = await operations.GetSubscriptionsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='subscription'>
        /// Required.
        /// </param>
        public static Subscription PostSubscriptionBySubscription(this ISubscriptions operations, Subscription subscription)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISubscriptions)s).PostSubscriptionBySubscriptionAsync(subscription);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='subscription'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Subscription> PostSubscriptionBySubscriptionAsync(this ISubscriptions operations, Subscription subscription, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<UserClient.Models.Subscription> result = await operations.PostSubscriptionBySubscriptionWithOperationResponseAsync(subscription, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='subscription'>
        /// Required.
        /// </param>
        public static object PutSubscriptionByIdAndSubscription(this ISubscriptions operations, string id, Subscription subscription)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((ISubscriptions)s).PutSubscriptionByIdAndSubscriptionAsync(id, subscription);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the UserClient.ISubscriptions.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='subscription'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<object> PutSubscriptionByIdAndSubscriptionAsync(this ISubscriptions operations, string id, Subscription subscription, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<object> result = await operations.PutSubscriptionByIdAndSubscriptionWithOperationResponseAsync(id, subscription, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
