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
    public class DepositosController : ApiController
    {
        private DBCaso1Entities db = new DBCaso1Entities();

        // GET: api/Depositos
        public IQueryable<t003_depositos> Gett003_depositos()
        {
            return db.t003_depositos;
        }

        // GET: api/Depositos/5
        [ResponseType(typeof(t003_depositos))]
        public IHttpActionResult Gett003_depositos(int id)
        {
            t003_depositos t003_depositos = db.t003_depositos.Find(id);
            if (t003_depositos == null)
            {
                return NotFound();
            }

            return Ok(t003_depositos);
        }

        // PUT: api/Depositos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt003_depositos(int id, t003_depositos t003_depositos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t003_depositos.id_deposito)
            {
                return BadRequest();
            }

            db.Entry(t003_depositos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t003_depositosExists(id))
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

        // POST: api/Depositos
        [ResponseType(typeof(t003_depositos))]
        public IHttpActionResult Postt003_depositos(t003_depositos t003_depositos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t003_depositos.Add(t003_depositos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t003_depositos.id_deposito }, t003_depositos);
        }

        // DELETE: api/Depositos/5
        [ResponseType(typeof(t003_depositos))]
        public IHttpActionResult Deletet003_depositos(int id)
        {
            t003_depositos t003_depositos = db.t003_depositos.Find(id);
            if (t003_depositos == null)
            {
                return NotFound();
            }

            db.t003_depositos.Remove(t003_depositos);
            db.SaveChanges();

            return Ok(t003_depositos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t003_depositosExists(int id)
        {
            return db.t003_depositos.Count(e => e.id_deposito == id) > 0;
        }
    }
}