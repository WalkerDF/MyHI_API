using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyHI_API.Models.Inspections;

namespace MyHI_API.Controllers {
	public class InspectionsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Inspections
        public IQueryable<Inspection> GetInspections()
        {
            return db.Inspections;
        }

        // GET: api/Inspections/5
        [ResponseType(typeof(Inspection))]
        public IHttpActionResult GetInspection(Guid id)
        {
            Inspection inspection = db.Inspections.Find(id);
            if (inspection == null)
            {
                return NotFound();
            }

            return Ok(inspection);
        }

        // PUT: api/Inspections/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInspection(Guid id, Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inspection.InspectionID)
            {
                return BadRequest();
            }

            db.Entry(inspection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionExists(id))
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

        // POST: api/Inspections
        [ResponseType(typeof(Inspection))]
        public IHttpActionResult PostInspection(Inspection inspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inspections.Add(inspection);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InspectionExists(inspection.InspectionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inspection.InspectionID }, inspection);
        }

        // DELETE: api/Inspections/5
        [ResponseType(typeof(Inspection))]
        public IHttpActionResult DeleteInspection(Guid id)
        {
            Inspection inspection = db.Inspections.Find(id);
            if (inspection == null)
            {
                return NotFound();
            }

            db.Inspections.Remove(inspection);
            db.SaveChanges();

            return Ok(inspection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InspectionExists(Guid id)
        {
            return db.Inspections.Count(e => e.InspectionID == id) > 0;
        }
    }
}