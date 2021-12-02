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
using API_Caso1.Models;

namespace API_Caso1.Controllers
{
    public class TanquesController : ApiController
    {
        private DBCaso1Entities db = new DBCaso1Entities();

        // GET: api/Tanques
        public IQueryable<t005_tanques> Gett005_tanques()
        {
            return db.t005_tanques;
        }

        // GET: api/Tanques/5
        [ResponseType(typeof(t005_tanques))]
        public IHttpActionResult Gett005_tanques(int id)
        {
            t005_tanques t005_tanques = db.t005_tanques.Find(id);
            if (t005_tanques == null)
            {
                return NotFound();
            }

            return Ok(t005_tanques);
        }

        // PUT: api/Tanques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt005_tanques(int id, t005_tanques t005_tanques)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t005_tanques.id_tanque)
            {
                return BadRequest();
            }

            db.Entry(t005_tanques).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t005_tanquesExists(id))
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

        // POST: api/Tanques
        [ResponseType(typeof(t005_tanques))]
        public IHttpActionResult Postt005_tanques(t005_tanques t005_tanques)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t005_tanques.Add(t005_tanques);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t005_tanques.id_tanque }, t005_tanques);
        }

        // DELETE: api/Tanques/5
        [ResponseType(typeof(t005_tanques))]
        public IHttpActionResult Deletet005_tanques(int id)
        {
            t005_tanques t005_tanques = db.t005_tanques.Find(id);
            if (t005_tanques == null)
            {
                return NotFound();
            }

            db.t005_tanques.Remove(t005_tanques);
            db.SaveChanges();

            return Ok(t005_tanques);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t005_tanquesExists(int id)
        {
            return db.t005_tanques.Count(e => e.id_tanque == id) > 0;
        }
    }
}