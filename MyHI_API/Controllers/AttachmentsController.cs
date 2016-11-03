using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MyHI_API.Models.Attachments;

namespace MyHI_API.Controllers {
	public class AttachmentsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Attachments
        public IQueryable<Attachment> GetAttachments()
        {
            return db.Attachments;
        }

        // GET: api/Attachments/5
        [ResponseType(typeof(Attachment))]
        public IHttpActionResult GetAttachment(Guid id)
        {
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return NotFound();
            }

            return Ok(attachment);
        }

        // PUT: api/Attachments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAttachment(Guid id, Attachment attachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attachment.AttachmentID)
            {
                return BadRequest();
            }

            db.Entry(attachment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttachmentExists(id))
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

        // POST: api/Attachments
        [ResponseType(typeof(Attachment))]
        public IHttpActionResult PostAttachment(Attachment attachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attachments.Add(attachment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AttachmentExists(attachment.AttachmentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = attachment.AttachmentID }, attachment);
        }

        // DELETE: api/Attachments/5
        [ResponseType(typeof(Attachment))]
        public IHttpActionResult DeleteAttachment(Guid id)
        {
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return NotFound();
            }

            db.Attachments.Remove(attachment);
            db.SaveChanges();

            return Ok(attachment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttachmentExists(Guid id)
        {
            return db.Attachments.Count(e => e.AttachmentID == id) > 0;
        }
    }
}