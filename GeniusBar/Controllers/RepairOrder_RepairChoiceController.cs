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
    public class RepairOrder_RepairChoiceController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RepairOrder_RepairChoice
        public IQueryable<RepairOrder_RepairChoice> GetRepairOrder_RepairChoice()
        {
            return db.RepairOrder_RepairChoice;
        }

        // GET: api/RepairOrder_RepairChoice/5
        [ResponseType(typeof(RepairOrder_RepairChoice))]
        public IHttpActionResult GetRepairOrder_RepairChoice(int id)
        {
            RepairOrder_RepairChoice repairOrder_RepairChoice = db.RepairOrder_RepairChoice.Find(id);
            if (repairOrder_RepairChoice == null)
            {
                return NotFound();
            }

            return Ok(repairOrder_RepairChoice);
        }

        // PUT: api/RepairOrder_RepairChoice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepairOrder_RepairChoice(int id, RepairOrder_RepairChoice repairOrder_RepairChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repairOrder_RepairChoice.Rep_order_ID)
            {
                return BadRequest();
            }

            db.Entry(repairOrder_RepairChoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrder_RepairChoiceExists(id))
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

        // POST: api/RepairOrder_RepairChoice
        [ResponseType(typeof(RepairOrder_RepairChoice))]
        public IHttpActionResult PostRepairOrder_RepairChoice(RepairOrder_RepairChoice repairOrder_RepairChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepairOrder_RepairChoice.Add(repairOrder_RepairChoice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RepairOrder_RepairChoiceExists(repairOrder_RepairChoice.Rep_order_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = repairOrder_RepairChoice.Rep_order_ID }, repairOrder_RepairChoice);
        }

        // DELETE: api/RepairOrder_RepairChoice/5
        [ResponseType(typeof(RepairOrder_RepairChoice))]
        public IHttpActionResult DeleteRepairOrder_RepairChoice(int id)
        {
            RepairOrder_RepairChoice repairOrder_RepairChoice = db.RepairOrder_RepairChoice.Find(id);
            if (repairOrder_RepairChoice == null)
            {
                return NotFound();
            }

            db.RepairOrder_RepairChoice.Remove(repairOrder_RepairChoice);
            db.SaveChanges();

            return Ok(repairOrder_RepairChoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairOrder_RepairChoiceExists(int id)
        {
            return db.RepairOrder_RepairChoice.Count(e => e.Rep_order_ID == id) > 0;
        }
    }
}