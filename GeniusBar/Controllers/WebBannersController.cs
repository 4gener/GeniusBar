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
    public class WebBannersController : ApiController
    {
        private GeniusBarContext db = new GeniusBarContext();

        // GET: api/WebBanners
        public IQueryable<WebBanner> GetWebBanners()
        {
            return db.WebBanners;
        }

        // GET: api/WebBanners/5
        [ResponseType(typeof(WebBanner))]
        public IHttpActionResult GetWebBanner(int id)
        {
            WebBanner webBanner = db.WebBanners.Find(id);
            if (webBanner == null)
            {
                return NotFound();
            }

            return Ok(webBanner);
        }

        // PUT: api/WebBanners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWebBanner(int id, WebBanner webBanner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webBanner.ID)
            {
                return BadRequest();
            }

            db.Entry(webBanner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebBannerExists(id))
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

        // POST: api/WebBanners
        [ResponseType(typeof(WebBanner))]
        public IHttpActionResult PostWebBanner(WebBanner webBanner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebBanners.Add(webBanner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = webBanner.ID }, webBanner);
        }

        // DELETE: api/WebBanners/5
        [ResponseType(typeof(WebBanner))]
        public IHttpActionResult DeleteWebBanner(int id)
        {
            WebBanner webBanner = db.WebBanners.Find(id);
            if (webBanner == null)
            {
                return NotFound();
            }

            db.WebBanners.Remove(webBanner);
            db.SaveChanges();

            return Ok(webBanner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebBannerExists(int id)
        {
            return db.WebBanners.Count(e => e.ID == id) > 0;
        }
    }
}