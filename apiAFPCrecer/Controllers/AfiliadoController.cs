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
using DAL.Data;
using DAL.Model;

namespace apiAFPCrecer.Controllers
{
    public class AfiliadoController : ApiController
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: api/Afiliado
        public IQueryable<Afiliados> GetAfiliados()
        {
            return db.Afiliados;
        }

        // GET: api/Afiliado/5
        [ResponseType(typeof(Afiliados))]
        public IHttpActionResult GetAfiliados(int id)
        {
            Afiliados afiliados = db.Afiliados.Find(id);
            if (afiliados == null)
            {
                return NotFound();
            }

            return Ok(afiliados);
        }

        // PUT: api/Afiliado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAfiliados(int id, Afiliados afiliados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afiliados.IdAfiliado)
            {
                return BadRequest();
            }

            db.Entry(afiliados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfiliadosExists(id))
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

        // POST: api/Afiliado
        [ResponseType(typeof(Afiliados))]
        public IHttpActionResult PostAfiliados(Afiliados afiliados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Afiliados.Add(afiliados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = afiliados.IdAfiliado }, afiliados);
        }

        // DELETE: api/Afiliado/5
        [ResponseType(typeof(Afiliados))]
        public IHttpActionResult DeleteAfiliados(int id)
        {
            Afiliados afiliados = db.Afiliados.Find(id);
            if (afiliados == null)
            {
                return NotFound();
            }

            db.Afiliados.Remove(afiliados);
            db.SaveChanges();

            return Ok(afiliados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AfiliadosExists(int id)
        {
            return db.Afiliados.Count(e => e.IdAfiliado == id) > 0;
        }
    }
}