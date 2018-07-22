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
    public class RecycleEvaluationChoicesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RecycleEvaluationChoices
        public IQueryable<RecycleEvaluationChoice> GetRecycleEvaluationChoices()
        {
            return db.RecycleEvaluationChoices;
        }

        // GET: api/RecycleEvaluationChoices/5
        [ResponseType(typeof(RecycleEvaluationChoice))]
        public IHttpActionResult GetRecycleEvaluationChoice(int id)
        {
            RecycleEvaluationChoice recycleEvaluationChoice = db.RecycleEvaluationChoices.Find(id);
            if (recycleEvaluationChoice == null)
            {
                return NotFound();
            }

            return Ok(recycleEvaluationChoice);
        }

        // PUT: api/RecycleEvaluationChoices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecycleEvaluationChoice(int id, RecycleEvaluationChoice recycleEvaluationChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recycleEvaluationChoice.ID)
            {
                return BadRequest();
            }

            db.Entry(recycleEvaluationChoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleEvaluationChoiceExists(id))
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

        // POST: api/RecycleEvaluationChoices
        [ResponseType(typeof(RecycleEvaluationChoice))]
        public IHttpActionResult PostRecycleEvaluationChoice(RecycleEvaluationChoice recycleEvaluationChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecycleEvaluationChoices.Add(recycleEvaluationChoice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recycleEvaluationChoice.ID }, recycleEvaluationChoice);
        }

        // DELETE: api/RecycleEvaluationChoices/5
        [ResponseType(typeof(RecycleEvaluationChoice))]
        public IHttpActionResult DeleteRecycleEvaluationChoice(int id)
        {
            RecycleEvaluationChoice recycleEvaluationChoice = db.RecycleEvaluationChoices.Find(id);
            if (recycleEvaluationChoice == null)
            {
                return NotFound();
            }

            db.RecycleEvaluationChoices.Remove(recycleEvaluationChoice);
            db.SaveChanges();

            return Ok(recycleEvaluationChoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecycleEvaluationChoiceExists(int id)
        {
            return db.RecycleEvaluationChoices.Count(e => e.ID == id) > 0;
        }
    }
}