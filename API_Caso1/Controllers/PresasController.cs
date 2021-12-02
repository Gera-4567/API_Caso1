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
    public class PresasController : ApiController
    {
        private DBCaso1Entities db = new DBCaso1Entities();

        // GET: api/Presas
        public IQueryable<t004_presas> Gett004_presas()
        {
            return db.t004_presas;
        }

        // GET: api/Presas/5
        [ResponseType(typeof(t004_presas))]
        public IHttpActionResult Gett004_presas(int id)
        {
            t004_presas t004_presas = db.t004_presas.Find(id);
            if (t004_presas == null)
            {
                return NotFound();
            }

            return Ok(t004_presas);
        }

        // PUT: api/Presas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt004_presas(int id, t004_presas t004_presas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t004_presas.id_presa)
            {
                return BadRequest();
            }

            db.Entry(t004_presas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t004_presasExists(id))
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

        // POST: api/Presas
        [ResponseType(typeof(t004_presas))]
        public IHttpActionResult Postt004_presas(t004_presas t004_presas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t004_presas.Add(t004_presas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t004_presas.id_presa }, t004_presas);
        }

        // DELETE: api/Presas/5
        [ResponseType(typeof(t004_presas))]
        public IHttpActionResult Deletet004_presas(int id)
        {
            t004_presas t004_presas = db.t004_presas.Find(id);
            if (t004_presas == null)
            {
                return NotFound();
            }

            db.t004_presas.Remove(t004_presas);
            db.SaveChanges();

            return Ok(t004_presas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t004_presasExists(int id)
        {
            return db.t004_presas.Count(e => e.id_presa == id) > 0;
        }
    }
}