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
    public class AuthorizationsController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/Authorizations
        public IQueryable<Authorization> GetAuthorizations()
        {
            return db.Authorizations;
        }

        // GET: api/Authorizations/5
        [ResponseType(typeof(Authorization))]
        public IHttpActionResult GetAuthorization(int id)
        {
            Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return NotFound();
            }

            return Ok(authorization);
        }

        // PUT: api/Authorizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthorization(int id, Authorization authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != authorization.ID)
            {
                return BadRequest();
            }

            db.Entry(authorization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizationExists(id))
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

        // POST: api/Authorizations
        [ResponseType(typeof(Authorization))]
        public IHttpActionResult PostAuthorization(Authorization authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authorizations.Add(authorization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = authorization.ID }, authorization);
        }

        // DELETE: api/Authorizations/5
        [ResponseType(typeof(Authorization))]
        public IHttpActionResult DeleteAuthorization(int id)
        {
            Authorization authorization = db.Authorizations.Find(id);
            if (authorization == null)
            {
                return NotFound();
            }

            db.Authorizations.Remove(authorization);
            db.SaveChanges();

            return Ok(authorization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorizationExists(int id)
        {
            return db.Authorizations.Count(e => e.ID == id) > 0;
        }
    }
}