using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server.Authentication;
using RestaurantWaitTime.Models;

namespace RestaurantWaitTime.Controllers
{
    public class SubscriptionsController : ApiController
    {
        private RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

        // GET: api/Subscriptions
        public IQueryable<Subscription> GetSubscriptions()
        {
            return _db.Subscriptions;
        }

        // GET: api/Subscriptions/5
        [Authorize]
        [HttpGet]
        [ResponseType(typeof(Subscription))]
        [Route("api/GetSubscriptionById/{id}")]
        public async Task<IHttpActionResult> GetSubscriptionById(string id)
        {
            Subscription subscription = await _db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        // PUT: api/Subscriptions/5
        [Authorize]
        [HttpPatch]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscription(string id, Delta<Subscription> patch)
        {
            Subscription subscription = await _db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            try
            {
                patch.Patch(subscription);
                _db.Entry(subscription).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Subscriptions
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(Subscription))]
        public async Task<IHttpActionResult> PostSubscription(Subscription subscription)
        {
            subscription.Id = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Subscriptions.Add(subscription);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriptionExists(subscription.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subscription.Id }, subscription);
        }

        // DELETE: api/Subscriptions/5
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(Subscription))]
        public async Task<IHttpActionResult> DeleteSubscription(string id)
        {
            Subscription subscription = await _db.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _db.Subscriptions.Remove(subscription);
            await _db.SaveChangesAsync();

            return Ok(subscription);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriptionExists(string id)
        {
            return _db.Subscriptions.Count(e => e.Id == id) > 0;
        }

        private async Task<string> GetIdpUser()
        {
            string userName = null;
            ClaimsPrincipal principal = User as ClaimsPrincipal;
            string provider = principal?.FindFirst("http://schemas.microsoft.com/identity/claims/identityprovider").Value;

            ProviderCredentials creds = null;
            if (string.Equals(provider, "facebook", StringComparison.OrdinalIgnoreCase))
            {
                creds = await User.GetAppServiceIdentityAsync<FacebookCredentials>(Request);
            }
            else if (string.Equals(provider, "google", StringComparison.OrdinalIgnoreCase))
            {
                creds = await User.GetAppServiceIdentityAsync<GoogleCredentials>(Request);
            }
            else if (string.Equals(provider, "twitter", StringComparison.OrdinalIgnoreCase))
            {
                creds = await User.GetAppServiceIdentityAsync<TwitterCredentials>(Request);
            }

            if (creds != null)
            {
                userName = $"{creds.Provider}:{creds.UserId.ToUpper()}";
            }

            return userName;
        }
    }
}