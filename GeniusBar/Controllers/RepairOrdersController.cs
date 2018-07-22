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
    public class RepairOrdersController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RepairOrders
        public IQueryable<RepairOrder> GetRepairOrders()
        {
            return db.RepairOrders;
        }

        // GET: api/RepairOrders/5
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult GetRepairOrder(int id)
        {
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return Ok(repairOrder);
        }

        // PUT: api/RepairOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepairOrder(int id, RepairOrder repairOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repairOrder.ID)
            {
                return BadRequest();
            }

            db.Entry(repairOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(id))
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

        // POST: api/RepairOrders
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult PostRepairOrder(RepairOrder repairOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepairOrders.Add(repairOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repairOrder.ID }, repairOrder);
        }

        // DELETE: api/RepairOrders/5
        [ResponseType(typeof(RepairOrder))]
        public IHttpActionResult DeleteRepairOrder(int id)
        {
            RepairOrder repairOrder = db.RepairOrders.Find(id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            db.RepairOrders.Remove(repairOrder);
            db.SaveChanges();

            return Ok(repairOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairOrderExists(int id)
        {
            return db.RepairOrders.Count(e => e.ID == id) > 0;
        }
    }
}