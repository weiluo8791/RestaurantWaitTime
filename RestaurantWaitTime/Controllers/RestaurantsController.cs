using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using RestaurantWaitTime.Models;

namespace RestaurantWaitTime.Controllers
{
    public class RestaurantsController : ApiController
    {
        private readonly RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

        // GET: api/Restaurants
        [HttpGet]
        [Route("api/GetAllRestaurants")]
        public IQueryable GetAllRestaurants()
        {
            return _db.Restaurants
                .Select(r => new
                {
                    r.RestaurantId,r.Name,r.Address,r.City,r.State,
                    r.Zip, r.Phone,r.WebSite,r.Email, r.Hours, r.Cuisine, r.Capacity
                });
        }

        // GET: api/Restaurants/5
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

        // POST: api/Restaurants/5
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
    }
}