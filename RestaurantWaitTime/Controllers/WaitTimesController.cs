using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RestaurantWaitTime.Models;

namespace RestaurantWaitTime.Controllers
{
    public class WaitTimesController : ApiController
    {
        private readonly RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

        [HttpGet]
        [ResponseType(typeof(WaitTime))]
        [Route("api/GetLatestRestaurantWaitTime/{restaurantId}")]
        public async Task<IHttpActionResult> GetLatestRestaurantWaitTime(string restaurantId)
        {
            var selectByGroup = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .GroupBy(a => a.GroupNumber).ToListAsync();

            List<WaitTime> result = selectByGroup.Select(element => element.OrderByDescending(a => a.WaitDateTime).First()).ToList();

            return Ok(result);
        }


        [HttpGet]
        [ResponseType(typeof(WaitTime))]
        [Route("api/GetLatestRestaurantWaitTimeByGroup/{restaurantId}/{group}")]
        public async Task<IHttpActionResult> GetLatestRestaurantWaitTimeByGroup(string restaurantId, int group)
        {
            var result = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .Where(a => a.GroupNumber == group)
                .OrderByDescending(a => a.WaitDateTime)
                .FirstAsync();

            return Ok(result);
        }

        // PUT: api/WaitTimes
        [HttpPut]
        [Authorize]
        [ResponseType(typeof(WaitTime))]
        public async Task<IHttpActionResult> PostWaitTime(WaitTime item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.WaitTimes.Add(item);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WaitTimeExists(item.RestaurantId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.RestaurantId }, item);
        }

        // DELETE: api/WaitTimes/5
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(WaitTime))]
        public async Task<IHttpActionResult> DeleteCurrentWaitTime(string restaurantId, int group)
        {

            var waitTime = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .Where(a => a.GroupNumber == group)
                .OrderByDescending(a => a.WaitDateTime)
                .FirstAsync();

            if (waitTime == null)
            {
                return NotFound();
            }

            _db.WaitTimes.Remove(waitTime);
            await _db.SaveChangesAsync();

            return Ok(waitTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WaitTimeExists(string id)
        {
            return _db.WaitTimes.Count(e => e.RestaurantId == id) > 0;
        }
    }
}