using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantWaitTime.Models;

namespace RestaurantWaitTime.Controllers
{
    public class RestaurantUsersController : ApiController
    {
        private RestaurantWaitTimeContext db = new RestaurantWaitTimeContext();

        // GET: api/RestaurantUsers
        public IQueryable<RestaurantUser> GetRestaurantUsers()
        {
            return db.RestaurantUsers;
        }

        // GET: api/RestaurantUsers/5
        [ResponseType(typeof(RestaurantUser))]
        public async Task<IHttpActionResult> GetRestaurantUser(string id)
        {
            RestaurantUser restaurantUser = await db.RestaurantUsers.FindAsync(id);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            return Ok(restaurantUser);
        }

        // PUT: api/RestaurantUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantUser(string id, RestaurantUser restaurantUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantUser.UserId)
            {
                return BadRequest();
            }

            db.Entry(restaurantUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestaurantUsers
        [ResponseType(typeof(RestaurantUser))]
        public async Task<IHttpActionResult> PostRestaurantUser(RestaurantUser restaurantUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantUsers.Add(restaurantUser);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RestaurantUserExists(restaurantUser.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = restaurantUser.UserId }, restaurantUser);
        }

        // DELETE: api/RestaurantUsers/5
        [ResponseType(typeof(RestaurantUser))]
        public async Task<IHttpActionResult> DeleteRestaurantUser(string id)
        {
            RestaurantUser restaurantUser = await db.RestaurantUsers.FindAsync(id);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            db.RestaurantUsers.Remove(restaurantUser);
            await db.SaveChangesAsync();

            return Ok(restaurantUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantUserExists(string id)
        {
            return db.RestaurantUsers.Count(e => e.UserId == id) > 0;
        }
    }
}