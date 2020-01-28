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
using Coopera.Data;
using CooperaApi.Models;

namespace CooperaApi.Controllers
{
    public class FilliersController : ApiController
    {
        private CoopEntities db = new CoopEntities();

        // GET: api/Filliers
        public IHttpActionResult GetFilliers()
        {
            var filliers = from f in db.Filliers.ToList() select new FillieresModel(f);

            return Ok(filliers);
        }

        // GET: api/Filliers/5
        [ResponseType(typeof(Filliers))]
        public IHttpActionResult GetFilliers(int id)
        {
            Filliers filliers = db.Filliers.Find(id);
            if (filliers == null)
            {
                return NotFound();
            }

            return Ok(new FillieresModel(filliers));
        }

        // PUT: api/Filliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilliers(int id, Filliers filliers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filliers.Id)
            {
                return BadRequest();
            }

            db.Entry(filliers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilliersExists(id))
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

        // POST: api/Filliers
        [ResponseType(typeof(Filliers))]
        public IHttpActionResult PostFilliers(Filliers filliers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filliers.Add(filliers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = filliers.Id }, filliers);
        }

        // DELETE: api/Filliers/5
        [ResponseType(typeof(Filliers))]
        public IHttpActionResult DeleteFilliers(int id)
        {
            Filliers filliers = db.Filliers.Find(id);
            if (filliers == null)
            {
                return NotFound();
            }

            db.Filliers.Remove(filliers);
            db.SaveChanges();

            return Ok(filliers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilliersExists(int id)
        {
            return db.Filliers.Count(e => e.Id == id) > 0;
        }
    }
}