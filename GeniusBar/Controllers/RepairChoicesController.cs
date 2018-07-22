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
    public class RepairChoicesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RepairChoices
        public IQueryable<RepairChoice> GetRepairChoices()
        {
            return db.RepairChoices;
        }

        // GET: api/RepairChoices/5
        [ResponseType(typeof(RepairChoice))]
        public IHttpActionResult GetRepairChoice(int id)
        {
            RepairChoice repairChoice = db.RepairChoices.Find(id);
            if (repairChoice == null)
            {
                return NotFound();
            }

            return Ok(repairChoice);
        }

        // PUT: api/RepairChoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepairChoice(int id, RepairChoice repairChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repairChoice.ID)
            {
                return BadRequest();
            }

            db.Entry(repairChoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairChoiceExists(id))
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

        // POST: api/RepairChoices
        [ResponseType(typeof(RepairChoice))]
        public IHttpActionResult PostRepairChoice(RepairChoice repairChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepairChoices.Add(repairChoice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repairChoice.ID }, repairChoice);
        }

        // DELETE: api/RepairChoices/5
        [ResponseType(typeof(RepairChoice))]
        public IHttpActionResult DeleteRepairChoice(int id)
        {
            RepairChoice repairChoice = db.RepairChoices.Find(id);
            if (repairChoice == null)
            {
                return NotFound();
            }

            db.RepairChoices.Remove(repairChoice);
            db.SaveChanges();

            return Ok(repairChoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairChoiceExists(int id)
        {
            return db.RepairChoices.Count(e => e.ID == id) > 0;
        }
    }
}