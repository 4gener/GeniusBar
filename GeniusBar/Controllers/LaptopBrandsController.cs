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
    public class LaptopBrandsController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/LaptopBrands
        public IQueryable<LaptopBrand> GetLaptopBrands()
        {
            return db.LaptopBrands;
        }

        // GET: api/LaptopBrands/5
        [ResponseType(typeof(LaptopBrand))]
        public IHttpActionResult GetLaptopBrand(int id)
        {
            LaptopBrand laptopBrand = db.LaptopBrands.Find(id);
            if (laptopBrand == null)
            {
                return NotFound();
            }

            return Ok(laptopBrand);
        }

        // PUT: api/LaptopBrands/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaptopBrand(int id, LaptopBrand laptopBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laptopBrand.ID)
            {
                return BadRequest();
            }

            db.Entry(laptopBrand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopBrandExists(id))
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

        // POST: api/LaptopBrands
        [ResponseType(typeof(LaptopBrand))]
        public IHttpActionResult PostLaptopBrand(LaptopBrand laptopBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LaptopBrands.Add(laptopBrand);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = laptopBrand.ID }, laptopBrand);
        }

        // DELETE: api/LaptopBrands/5
        [ResponseType(typeof(LaptopBrand))]
        public IHttpActionResult DeleteLaptopBrand(int id)
        {
            LaptopBrand laptopBrand = db.LaptopBrands.Find(id);
            if (laptopBrand == null)
            {
                return NotFound();
            }

            db.LaptopBrands.Remove(laptopBrand);
            db.SaveChanges();

            return Ok(laptopBrand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaptopBrandExists(int id)
        {
            return db.LaptopBrands.Count(e => e.ID == id) > 0;
        }
    }
}