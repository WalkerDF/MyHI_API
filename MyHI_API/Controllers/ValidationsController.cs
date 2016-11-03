using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyHI_API.Models.Validations;

namespace MyHI_API.Controllers {
	public class ValidationsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Validations
        public IQueryable<Validation> GetValidations()
        {
            return db.Validations;
        }

        // GET: api/Validations/5
        [ResponseType(typeof(Validation))]
        public IHttpActionResult GetValidation(string id)
        {
            Validation validation = db.Validations.Find(id);
            if (validation == null)
            {
                return NotFound();
            }

            return Ok(validation);
        }

        // PUT: api/Validations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValidation(string id, Validation validation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != validation.ValidationID)
            {
                return BadRequest();
            }

            db.Entry(validation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidationExists(id))
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

        // POST: api/Validations
        [ResponseType(typeof(Validation))]
        public IHttpActionResult PostValidation(Validation validation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Validations.Add(validation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ValidationExists(validation.ValidationID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = validation.ValidationID }, validation);
        }

        // DELETE: api/Validations/5
        [ResponseType(typeof(Validation))]
        public IHttpActionResult DeleteValidation(string id)
        {
            Validation validation = db.Validations.Find(id);
            if (validation == null)
            {
                return NotFound();
            }

            db.Validations.Remove(validation);
            db.SaveChanges();

            return Ok(validation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ValidationExists(string id)
        {
            return db.Validations.Count(e => e.ValidationID == id) > 0;
        }
    }
}