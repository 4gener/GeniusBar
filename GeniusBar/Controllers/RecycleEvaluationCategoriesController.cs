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
    public class RecycleEvaluationCategoriesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RecycleEvaluationCategories
        public IQueryable<RecycleEvaluationCategory> GetRecycleEvaluationCategories()
        {
            return db.RecycleEvaluationCategories;
        }

        // GET: api/RecycleEvaluationCategories/5
        [ResponseType(typeof(RecycleEvaluationCategory))]
        public IHttpActionResult GetRecycleEvaluationCategory(int id)
        {
            RecycleEvaluationCategory recycleEvaluationCategory = db.RecycleEvaluationCategories.Find(id);
            if (recycleEvaluationCategory == null)
            {
                return NotFound();
            }

            return Ok(recycleEvaluationCategory);
        }

        // PUT: api/RecycleEvaluationCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecycleEvaluationCategory(int id, RecycleEvaluationCategory recycleEvaluationCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recycleEvaluationCategory.ID)
            {
                return BadRequest();
            }

            db.Entry(recycleEvaluationCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecycleEvaluationCategoryExists(id))
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

        // POST: api/RecycleEvaluationCategories
        [ResponseType(typeof(RecycleEvaluationCategory))]
        public IHttpActionResult PostRecycleEvaluationCategory(RecycleEvaluationCategory recycleEvaluationCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecycleEvaluationCategories.Add(recycleEvaluationCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recycleEvaluationCategory.ID }, recycleEvaluationCategory);
        }

        // DELETE: api/RecycleEvaluationCategories/5
        [ResponseType(typeof(RecycleEvaluationCategory))]
        public IHttpActionResult DeleteRecycleEvaluationCategory(int id)
        {
            RecycleEvaluationCategory recycleEvaluationCategory = db.RecycleEvaluationCategories.Find(id);
            if (recycleEvaluationCategory == null)
            {
                return NotFound();
            }

            db.RecycleEvaluationCategories.Remove(recycleEvaluationCategory);
            db.SaveChanges();

            return Ok(recycleEvaluationCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecycleEvaluationCategoryExists(int id)
        {
            return db.RecycleEvaluationCategories.Count(e => e.ID == id) > 0;
        }
    }
}