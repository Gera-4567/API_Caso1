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
    public class ColoniasController : ApiController
    {
        private DBCaso1Entities db = new DBCaso1Entities();

        // GET: api/Colonias
        public IQueryable<t002_colonias> Gett002_colonias()
        {
            return db.t002_colonias;
        }

        // GET: api/Colonias/5
        [ResponseType(typeof(t002_colonias))]
        public IHttpActionResult Gett002_colonias(int id)
        {
            t002_colonias t002_colonias = db.t002_colonias.Find(id);
            if (t002_colonias == null)
            {
                return NotFound();
            }

            return Ok(t002_colonias);
        }

        // PUT: api/Colonias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt002_colonias(int id, t002_colonias t002_colonias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t002_colonias.id_colonia)
            {
                return BadRequest();
            }

            db.Entry(t002_colonias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t002_coloniasExists(id))
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

        // POST: api/Colonias
        [ResponseType(typeof(t002_colonias))]
        public IHttpActionResult Postt002_colonias(t002_colonias t002_colonias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t002_colonias.Add(t002_colonias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t002_colonias.id_colonia }, t002_colonias);
        }

        // DELETE: api/Colonias/5
        [ResponseType(typeof(t002_colonias))]
        public IHttpActionResult Deletet002_colonias(int id)
        {
            t002_colonias t002_colonias = db.t002_colonias.Find(id);
            if (t002_colonias == null)
            {
                return NotFound();
            }

            db.t002_colonias.Remove(t002_colonias);
            db.SaveChanges();

            return Ok(t002_colonias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t002_coloniasExists(int id)
        {
            return db.t002_colonias.Count(e => e.id_colonia == id) > 0;
        }
    }
}