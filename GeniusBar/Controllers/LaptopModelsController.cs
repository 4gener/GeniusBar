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
    public class LaptopModelsController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/LaptopModels
        public IQueryable<LaptopModel> GetLaptopModels()
        {
            return db.LaptopModels;
        }

        // GET: api/LaptopModels/5
        [ResponseType(typeof(LaptopModel))]
        public IHttpActionResult GetLaptopModel(int id)
        {
            LaptopModel laptopModel = db.LaptopModels.Find(id);
            if (laptopModel == null)
            {
                return NotFound();
            }

            return Ok(laptopModel);
        }
        
        
        // GET: api/LaptopModels/{id}
        [Route("api/LaptopModels/route")]
        [ResponseType(typeof(LaptopModel))]
        public IHttpActionResult GetLaptopModelBrandID(int brandID)
        {
            var laptopModel = db.LaptopModels.Where(e=>e.Brand_ID == brandID);
            if (laptopModel == null)
            {
                return NotFound();
            }

            return Ok(laptopModel.ToList());
        }

        // PUT: api/LaptopModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaptopModel(int id, LaptopModel laptopModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laptopModel.ID)
            {
                return BadRequest();
            }

            db.Entry(laptopModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaptopModelExists(id))
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

        // POST: api/LaptopModels
        [ResponseType(typeof(LaptopModel))]
        public IHttpActionResult PostLaptopModel(LaptopModel laptopModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LaptopModels.Add(laptopModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = laptopModel.ID }, laptopModel);
        }

        // DELETE: api/LaptopModels/5
        [ResponseType(typeof(LaptopModel))]
        public IHttpActionResult DeleteLaptopModel(int id)
        {
            LaptopModel laptopModel = db.LaptopModels.Find(id);
            if (laptopModel == null)
            {
                return NotFound();
            }

            db.LaptopModels.Remove(laptopModel);
            db.SaveChanges();

            return Ok(laptopModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaptopModelExists(int id)
        {
            return db.LaptopModels.Count(e => e.ID == id) > 0;
        }
    }
}