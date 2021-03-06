﻿using System;
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
using RestaurantWaitTime.Models;
using Microsoft.Azure.Mobile.Server.Authentication;

namespace RestaurantWaitTime.Controllers
{
    public class UsersController : ApiController
    {
        private RestaurantWaitTimeContext _db = new RestaurantWaitTimeContext();

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("api/GetAllUsers")]
        public IQueryable GetAllUsers()
        {
            return _db.Users
                .Select(r => new
                {
                    r.UserId,
                    r.IdpId,
                    r.Name,
                    r.Type,
                    r.Email
                });
        }

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(User))]
        [Route("api/GetUser/{userId}")]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            User user = await _db.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Update User by id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="patch"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPatch]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(string userId, Delta<User> patch)
        {

            User user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                patch.Patch(user);
                _db.Entry(user).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userId))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Post a new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            user.UserId = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Users.Add(user);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            User user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return _db.Users.Count(e => e.UserId == id) > 0;
        }

        private bool IsRegistrated(string currentIdpUserId)
        {
            return _db.Users
                .Where(i => i.IdpId == currentIdpUserId)
                .Select(i => i.IdpId).ToList().Any();
        }

        private string CheckUserType(string idpUserId)
        {
            IQueryable<User> query = _db.Users;
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