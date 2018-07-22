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
    public class RepairCategoriesController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/RepairCategories
        public IQueryable<RepairCategory> GetRepairCategories()
        {
            return db.RepairCategories;
        }

        // GET: api/RepairCategories/5
        [ResponseType(typeof(RepairCategory))]
        public IHttpActionResult GetRepairCategory(int id)
        {
            RepairCategory repairCategory = db.RepairCategories.Find(id);
            if (repairCategory == null)
            {
                return NotFound();
            }

            return Ok(repairCategory);
        }

        // PUT: api/RepairCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepairCategory(int id, RepairCategory repairCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repairCategory.ID)
            {
                return BadRequest();
            }

            db.Entry(repairCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairCategoryExists(id))
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

        // POST: api/RepairCategories
        [ResponseType(typeof(RepairCategory))]
        public IHttpActionResult PostRepairCategory(RepairCategory repairCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepairCategories.Add(repairCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repairCategory.ID }, repairCategory);
        }

        // DELETE: api/RepairCategories/5
        [ResponseType(typeof(RepairCategory))]
        public IHttpActionResult DeleteRepairCategory(int id)
        {
            RepairCategory repairCategory = db.RepairCategories.Find(id);
            if (repairCategory == null)
            {
                return NotFound();
            }

            db.RepairCategories.Remove(repairCategory);
            db.SaveChanges();

            return Ok(repairCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairCategoryExists(int id)
        {
            return db.RepairCategories.Count(e => e.ID == id) > 0;
        }
    }
}