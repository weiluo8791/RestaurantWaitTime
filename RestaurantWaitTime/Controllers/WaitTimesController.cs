using System;
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

    public class WaitTimeInput
    {
  
        public DateTime waitDateTime { get; set; }
        public string RestaurantId { get; set; }
        public int Group { get; set; }
        public int Wait { get; set; }
    }

    public class WaitTimesController : ApiController
    {   
        private readonly RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();


        // GET: api/WaitTimes/5
        [ResponseType(typeof(WaitTime))]
        [Route("api/GetCurrentWaitTime/{restaurantId}/{group}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentWaitTime(string restaurantId,int group)
        {
            var result = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .Where(a => a.Group == group)
                .OrderByDescending(a=>a.WaitDateTime)                
                .FirstAsync();

            return Ok(result);
        }

        // PUT: api/WaitTimes/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateCurrentWaitTime(string restaurantId, int group,int wait)
        {
            var id = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .Where(a => a.Group == group)
                .OrderByDescending(a => a.WaitDateTime)
                .Select(a => a.Id)
                .FirstAsync();

            if (id==null)
            {
                return BadRequest();
            }

            WaitTime waitTime = await _db.WaitTimes.FindAsync(id);

            if (waitTime == null)
            {
                return NotFound();
            }


            waitTime.Wait = wait;
            waitTime.WaitDateTime = DateTime.UtcNow;

            _db.Entry(waitTime).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaitTimeExists(id))
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

        // POST: api/WaitTimes
        public async Task<IHttpActionResult> PostWaitTime(WaitTime item)
        {
            item.Id = Guid.NewGuid().ToString();

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
                if (WaitTimeExists(item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        // DELETE: api/WaitTimes/5
        [ResponseType(typeof(WaitTime))]
        public async Task<IHttpActionResult> DeleteCurrentWaitTime(string restaurantId, int group)
        {

            var id = await _db.WaitTimes
                .Where(a => a.RestaurantId == restaurantId)
                .Where(a => a.Group == group)
                .OrderByDescending(a => a.WaitDateTime)
                .Select(a => a.Id)
                .FirstAsync();

            WaitTime waitTime = await _db.WaitTimes.FindAsync(id);

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
            return _db.WaitTimes.Count(e => e.Id == id) > 0;
        }
    }
}