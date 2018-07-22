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
    public class Role_AuthorizationController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/Role_Authorization
        public IQueryable<Role_Authorization> GetRole_Authorization()
        {
            return db.Role_Authorization;
        }

        // GET: api/Role_Authorization/5
        [ResponseType(typeof(Role_Authorization))]
        public IHttpActionResult GetRole_Authorization(int id)
        {
            Role_Authorization role_Authorization = db.Role_Authorization.Find(id);
            if (role_Authorization == null)
            {
                return NotFound();
            }

            return Ok(role_Authorization);
        }

        // PUT: api/Role_Authorization/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole_Authorization(int id, Role_Authorization role_Authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role_Authorization.Role_ID)
            {
                return BadRequest();
            }

            db.Entry(role_Authorization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Role_AuthorizationExists(id))
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

        // POST: api/Role_Authorization
        [ResponseType(typeof(Role_Authorization))]
        public IHttpActionResult PostRole_Authorization(Role_Authorization role_Authorization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Role_Authorization.Add(role_Authorization);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Role_AuthorizationExists(role_Authorization.Role_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = role_Authorization.Role_ID }, role_Authorization);
        }

        // DELETE: api/Role_Authorization/5
        [ResponseType(typeof(Role_Authorization))]
        public IHttpActionResult DeleteRole_Authorization(int id)
        {
            Role_Authorization role_Authorization = db.Role_Authorization.Find(id);
            if (role_Authorization == null)
            {
                return NotFound();
            }

            db.Role_Authorization.Remove(role_Authorization);
            db.SaveChanges();

            return Ok(role_Authorization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Role_AuthorizationExists(int id)
        {
            return db.Role_Authorization.Count(e => e.Role_ID == id) > 0;
        }
    }
}