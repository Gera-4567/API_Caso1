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
    public class UsuariosController : ApiController
    {
        private DBCaso1Entities db = new DBCaso1Entities();

        // GET: api/Usuarios
        public IQueryable<t001_usuarios> Gett001_usuarios()
        {
            return db.t001_usuarios;
        }

        // GET: api/Usuarios?email=""
        public t001_usuarios Getusuario(string email)
        {
            try
            {
                var user = db.t001_usuarios.SingleOrDefault(u => u.email == email);
                //var password = db.t001_usuarios.SingleOrDefault(p => p.pass_usuario == pass_usuario);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(t001_usuarios))]
        public IHttpActionResult Gett001_usuarios(int id)
        {
            t001_usuarios t001_usuarios = db.t001_usuarios.Find(id);
            if (t001_usuarios == null)
            {
                return NotFound();
            }

            return Ok(t001_usuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putt001_usuarios(int id, t001_usuarios t001_usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t001_usuarios.id_usuario)
            {
                return BadRequest();
            }

            db.Entry(t001_usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!t001_usuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(t001_usuarios))]
        public IHttpActionResult Postt001_usuarios(t001_usuarios t001_usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.t001_usuarios.Add(t001_usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = t001_usuarios.id_usuario }, t001_usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(t001_usuarios))]
        public IHttpActionResult Deletet001_usuarios(int id)
        {
            t001_usuarios t001_usuarios = db.t001_usuarios.Find(id);
            if (t001_usuarios == null)
            {
                return NotFound();
            }

            db.t001_usuarios.Remove(t001_usuarios);
            db.SaveChanges();

            return Ok(t001_usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool t001_usuariosExists(int id)
        {
            return db.t001_usuarios.Count(e => e.id_usuario == id) > 0;
        }
    }
}