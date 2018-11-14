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
    public class RecycleOrder_RecycleEvaluatonChoiceController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RecycleOrder_RecycleEvaluatonChoice
        public IQueryable<RecycleOrder_RecycleEvaluatonChoice> GetRecycleOrder_RecycleEvaluatonChoice()
        {
            return db.RecycleOrder_RecycleEvaluatonChoice;
        }

        // GET: api/RecycleOrder_RecycleEvaluatonChoice/5
        [ResponseType(typeof(RecycleOrder_RecycleEvaluatonChoice))]
        public IHttpActionResult GetRecycleOrder_RecycleEvaluatonChoice(int id)
        {
            RecycleOrder_RecycleEvaluatonChoice recycleOrder_RecycleEvaluatonChoice = db.RecycleOrder_RecycleEvaluatonChoice.Find(id);
            if (recycleOrder_RecycleEvaluatonChoice == null)
            {
                return NotFound();
            }

            return Ok(recycleOrder_RecycleEvaluatonChoice);
        }

        // PUT: api/RecycleOrder_RecycleEvaluatonChoice/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecycleOrder_RecycleEvaluatonChoice(int id, RecycleOrder_RecycleEvaluatonChoice recycleOrder_RecycleEvaluatonChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recycleOrder_RecycleEvaluatonChoice.Rec_order_ID)
            {
                return BadRequest();
            }

            db.Entry(recycleOrder_RecycleEvaluatonChoice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleOrder_RecycleEvaluatonChoiceExists(id))
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

        // POST: api/RecycleOrder_RecycleEvaluatonChoice
        [ResponseType(typeof(RecycleOrder_RecycleEvaluatonChoice))]
        public IHttpActionResult PostRecycleOrder_RecycleEvaluatonChoice(RecycleOrder_RecycleEvaluatonChoice recycleOrder_RecycleEvaluatonChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecycleOrder_RecycleEvaluatonChoice.Add(recycleOrder_RecycleEvaluatonChoice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RecycleOrder_RecycleEvaluatonChoiceExists(recycleOrder_RecycleEvaluatonChoice.Rec_order_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = recycleOrder_RecycleEvaluatonChoice.Rec_order_ID }, recycleOrder_RecycleEvaluatonChoice);
        }

        // DELETE: api/RecycleOrder_RecycleEvaluatonChoice/5
        [ResponseType(typeof(RecycleOrder_RecycleEvaluatonChoice))]
        public IHttpActionResult DeleteRecycleOrder_RecycleEvaluatonChoice(int id)
        {
            RecycleOrder_RecycleEvaluatonChoice recycleOrder_RecycleEvaluatonChoice = db.RecycleOrder_RecycleEvaluatonChoice.Find(id);
            if (recycleOrder_RecycleEvaluatonChoice == null)
            {
                return NotFound();
            }

            db.RecycleOrder_RecycleEvaluatonChoice.Remove(recycleOrder_RecycleEvaluatonChoice);
            db.SaveChanges();

            return Ok(recycleOrder_RecycleEvaluatonChoice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecycleOrder_RecycleEvaluatonChoiceExists(int id)
        {
            return db.RecycleOrder_RecycleEvaluatonChoice.Count(e => e.Rec_order_ID == id) > 0;
        }
    }
}