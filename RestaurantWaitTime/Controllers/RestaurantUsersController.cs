using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class RestaurantUsersController : ApiController
    {
        private readonly RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

//        [HttpGet]
//        [Route("api/GetAllRestaurantUsers")]
//        public IQueryable GetAllRestaurantUsers()
//        {
//            return _db.RestaurantUsers
//                .Select(r => new
//                {
//                    r.UserId,
//                    r.IdpId,
//                    r.Name,
//                    r.Type,
//                    r.Email
//                });
//        }

        [HttpGet]
        [Authorize]
        [Route("api/GetAllRestaurantUsers")]
        public async Task<HttpResponseMessage> GetAllRestaurantUsers()
        {
            string idpUserId = await GetIdpUser();

            return Request.CreateResponse(HttpStatusCode.OK,_db.RestaurantUsers
                .Select(r => new
                {
                    r.UserId,
                    r.IdpId,
                    r.Name,
                    r.Type,
                    r.Email
                }).ToList());
        }

        [Route("api/GetRestaurantUser/{userId}")]
        [ResponseType(typeof(RestaurantUser))]
        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurantUser(string userId)
        {
            User user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [ResponseType(typeof(void))]
        [HttpPatch]
        public async Task<IHttpActionResult> PutUser(string userId, Delta<RestaurantUser> patch)
        {

            RestaurantUser restaurantUser = await _db.RestaurantUsers.FindAsync(userId);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            try
            {
                patch.Patch(restaurantUser);
                _db.Entry(restaurantUser).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantUserExists(userId))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(RestaurantUser))]
        [HttpPost]
        public async Task<IHttpActionResult> PostUser(RestaurantUser restaurantUser)
        {
            restaurantUser.UserId = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.RestaurantUsers.Add(restaurantUser);

            try
            {
                await _db.SaveChangesAsync();
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

        [ResponseType(typeof(User))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            RestaurantUser restaurantUser = await _db.RestaurantUsers.FindAsync(id);
            if (restaurantUser == null)
            {
                return NotFound();
            }

            _db.RestaurantUsers.Remove(restaurantUser);
            await _db.SaveChangesAsync();

            return Ok(restaurantUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantUserExists(string id)
        {
            return _db.RestaurantUsers.Count(e => e.UserId == id) > 0;
        }

        private bool IsRegistrated(string currentIdpUserId)
        {
            return _db.RestaurantUsers
                .Where(i => i.IdpId == currentIdpUserId)
                .Select(i => i.IdpId).ToList().Any();
        }


        private string CheckUserType(string idpUserId)
        {
            IQueryable<RestaurantUser> query = _db.RestaurantUsers;
            var result = query.Where(i => i.IdpId == idpUserId).Select(i => i.Type).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Get Idpuser from Credentials
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