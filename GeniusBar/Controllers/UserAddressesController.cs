using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GeniusBar.Models;

namespace GeniusBar.Controllers
{
    public class UserAddressesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        private User getCooikedUser()
        {
            // To be implemented 
            // throw new System.NotImplementedException();
            
            var cookie = System.Web.HttpContext.Current.Request.Cookies["GB"];
            var user = db.Users.Where(e => e.COOKIE == cookie.Value).FirstOrDefault();
            return user;
        }

        // GET: api/user/address
        [Route("api/user/address")]
        [HttpGet]
        public IQueryable<ServiceAddress> GetUserAddresses()
        {
            User cookiedUser = getCooikedUser();

            return db.ServiceAddresses.Where(e => e.Customer_ID == cookiedUser.ID);
        }

        // GET: api/user/address/5
        [Route("api/user/address/{id}", Name="GetUserAddress")]
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult GetUserAddress(int id)
        {
            User cookiedUser = getCooikedUser();
            ServiceAddress serviceAddress = db.ServiceAddresses.FirstOrDefault(u => (u.Customer_ID == cookiedUser.ID) && (u.ID == id));
            if (serviceAddress == null)
            {
                return NotFound();
            }

            return Ok(serviceAddress);
        }

        // PUT: api/user/address/5
        [Route("api/user/address/{id}", Name = "PutUserAddress")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, ServiceAddress serviceAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceAddress.ID)
            {
                return BadRequest();
            }
            
            if (serviceAddress.User != getCooikedUser())
            {
                return Unauthorized();
            }

            db.Entry(serviceAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAddressExists(id))
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

        // POST: api/user/address/
        [Route("api/user/address/")]
        [HttpPost]
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult PostUserAddress(ServiceAddress serviceAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (serviceAddress.Customer_ID != getCooikedUser().ID)
            {
                return Unauthorized();
            }
            

            db.ServiceAddresses.Add(serviceAddress);
            db.SaveChanges();

            return CreatedAtRoute("GetUserAddress", new { id = serviceAddress.ID }, serviceAddress);
        }

        // DELETE: api/user/address/5
        [Route("api/user/address/{id}")]
        [HttpDelete]
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult DeleteUserAddress(int id)
        {
            ServiceAddress serviceAddress = db.ServiceAddresses.Find(id);
            if (serviceAddress == null)
            {
                return NotFound();
            }
            
            if (serviceAddress.Customer_ID != getCooikedUser().ID)
            {
                return Unauthorized();
            }

            db.ServiceAddresses.Remove(serviceAddress);
            db.SaveChanges();

            return Ok(serviceAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceAddressExists(int id)
        {
            return db.ServiceAddresses.Count(e => e.ID == id) > 0;
        }
    }
}