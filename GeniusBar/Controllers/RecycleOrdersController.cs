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
    public class RecycleOrdersController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RecycleOrders
        public IQueryable<RecycleOrder> GetRecycleOrders()
        {
            return db.RecycleOrders;
        }

        // GET: api/RecycleOrders/5
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult GetRecycleOrder(int id)
        {
            RecycleOrder recycleOrder = db.RecycleOrders.Find(id);
            if (recycleOrder == null)
            {
                return NotFound();
            }

            return Ok(recycleOrder);
        }

        // PUT: api/RecycleOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecycleOrder(int id, RecycleOrder recycleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recycleOrder.ID)
            {
                return BadRequest();
            }

            db.Entry(recycleOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleOrderExists(id))
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

        // POST: api/RecycleOrders
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult PostRecycleOrder(RecycleOrder recycleOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecycleOrders.Add(recycleOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recycleOrder.ID }, recycleOrder);
        }

        // DELETE: api/RecycleOrders/5
        [ResponseType(typeof(RecycleOrder))]
        public IHttpActionResult DeleteRecycleOrder(int id)
        {
            RecycleOrder recycleOrder = db.RecycleOrders.Find(id);
            if (recycleOrder == null)
            {
                return NotFound();
            }

            db.RecycleOrders.Remove(recycleOrder);
            db.SaveChanges();

            return Ok(recycleOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecycleOrderExists(int id)
        {
            return db.RecycleOrders.Count(e => e.ID == id) > 0;
        }
    }
}