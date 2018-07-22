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
    public class ServiceAddressesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/ServiceAddresses
        public IQueryable<ServiceAddress> GetServiceAddresses()
        {
            return db.ServiceAddresses;
        }

        // GET: api/ServiceAddresses/5
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult GetServiceAddress(int id)
        {
            ServiceAddress serviceAddress = db.ServiceAddresses.Find(id);
            if (serviceAddress == null)
            {
                return NotFound();
            }

            return Ok(serviceAddress);
        }

        // PUT: api/ServiceAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceAddress(int id, ServiceAddress serviceAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceAddress.ID)
            {
                return BadRequest();
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

        // POST: api/ServiceAddresses
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult PostServiceAddress(ServiceAddress serviceAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceAddresses.Add(serviceAddress);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceAddress.ID }, serviceAddress);
        }

        // DELETE: api/ServiceAddresses/5
        [ResponseType(typeof(ServiceAddress))]
        public IHttpActionResult DeleteServiceAddress(int id)
        {
            ServiceAddress serviceAddress = db.ServiceAddresses.Find(id);
            if (serviceAddress == null)
            {
                return NotFound();
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