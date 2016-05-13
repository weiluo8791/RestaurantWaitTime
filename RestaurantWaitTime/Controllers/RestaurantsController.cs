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
    public class RestaurantsController : ApiController
    {
        private readonly RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

        // GET: api/Restaurants
        /// <summary>
        /// Get All Restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAllRestaurants")]
        public IQueryable GetAllRestaurants()
        {
            return _db.Restaurants
                .Select(r => new
                {
                    r.RestaurantId,
                    r.Name,
                    r.Address,
                    r.City,
                    r.State,
                    r.Zip,
                    r.Phone,
                    r.WebSite,
                    r.Email,
                    r.Hours,
                    r.Cuisine,
                    r.Capacity
                })
                .OrderBy(c => c.Name)
                //.OrderBy(c => Guid.NewGuid())
                .Take(50);
        }


        // GET: api/Restaurants/zip
        /// <summary>
        /// Get Restaurants by zip (not inuse)
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetRestaurantsByZip/{zip}")]
        public IQueryable GetRestaurantsByZip(string zip)
        {
            return _db.Restaurants
                .Select(r => new
                {
                    r.RestaurantId,
                    r.Name,
                    r.Address,
                    r.City,
                    r.State,
                    r.Zip,
                    r.Phone,
                    r.WebSite,
                    r.Email,
                    r.Hours,
                    r.Cuisine,
                    r.Capacity
                })
                .Where(c => c.Zip == zip)
                .OrderBy(c => c.Name)
                .Take(150);
        }

        // GET: api/Restaurants/5
        /// <summary>
        /// Get Restaurant by id
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [ResponseType(typeof(Restaurant))]
        [Route("api/GetRestaurant/{restaurantId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurant(string restaurantId)
        {
            var result = await _db.Restaurants
                .Where(a => a.RestaurantId == restaurantId)
                .FirstAsync();

            return Ok(result);
        }

        // GET: api/Restaurants/5
        /// <summary>
        /// Get Subscribed Restaurant from User and Subscription table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(Restaurant))]
        [Route("api/GetSubscribedRestaurants")]
        public async Task<IHttpActionResult> GetSubscribedRestaurants()
        {
            string idpId = await GetIdpUser();

            var userId = await _db.Users
                .Where(a => a.IdpId == idpId)
                .Select(a => a.UserId).FirstAsync();


            var result = await _db.Subscriptions
                 .Where(a => a.UserId == userId)
                 .Select(a => new { restaurantId =  a.RestaurantId})
                 .ToListAsync();

            var subRest = (
                from r in result
                join s in _db.Restaurants on r.restaurantId equals s.RestaurantId
                select new
                {
                    s.RestaurantId,
                    s.Name,
                    s.Address,
                    s.City,
                    s.State,
                    s.Phone,
                    s.Hours
                }).ToList();


            return Ok(subRest);
        }

        // POST: api/Restaurants/5
        /// <summary>
        /// Update Restaurant information
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <param name="patch"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(void))]
        [Route("api/UpdateRestaurant/{restaurantId}")]
        public async Task<IHttpActionResult> UpdateRestaurant(string restaurantId, Delta<Restaurant> patch)
        {

            Restaurant restaurant = await _db.Restaurants.FindAsync(restaurantId);
            if (restaurant == null)
            {
                return NotFound();
            }

            try
            {
                patch.Patch(restaurant);
                _db.Entry(restaurant).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurantId))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        /// <summary>
        /// Post a new Restaurant
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant item)
        {
            item.RestaurantId = Guid.NewGuid().ToString();
            //item.RestaurantId = item.City + "_" + Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Restaurants.Add(item);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantExists(item.RestaurantId))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = item.RestaurantId }, item);
        }

        // DELETE: api/Restaurants/5
        /// <summary>
        /// Delete a Restaurant by id
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> DeleteRestaurant(string restaurantId)
        {
            Restaurant restaurant = await _db.Restaurants.FindAsync(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            _db.Restaurants.Remove(restaurant);
            await _db.SaveChangesAsync();

            return Ok(restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(string id)
        {
            return _db.Restaurants.Count(e => e.RestaurantId == id) > 0;
        }

        /// <summary>
        /// Use to get idpId after log in
        /// </summary>
        /// <returns></returns>
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