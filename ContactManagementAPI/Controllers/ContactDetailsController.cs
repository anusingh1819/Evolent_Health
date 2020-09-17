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
using ContactManagementAPI.Models;

namespace ContactManagementAPI.Controllers
{
    public class ContactDetailsController : ApiController
    {
        private ContactEntities db = new ContactEntities();

        // GET: api/ContactDetails
        public IQueryable<ContactDetail> GetContactDetails()
        {
            return db.ContactDetails;
        }

        // GET: api/ContactDetails/5
        [ResponseType(typeof(ContactDetail))]
        public IHttpActionResult GetContactDetail(int id)
        {
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return Ok(contactDetail);
        }

        // PUT: api/ContactDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactDetail(int id, ContactDetail contactDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            ContactDetail contactDetails = new ContactDetail();
            contactDetails.Id = contactDetail.Id;
            contactDetails.First_Name = contactDetail.First_Name.Replace(" ", "");
            contactDetails.Last_Name = contactDetail.Last_Name.Replace(" ", "");
            contactDetails.Email = contactDetail.Email.Replace(" ", "");
            contactDetails.Phone_Number = contactDetail.Phone_Number.Replace(" ", "");
            contactDetails.Status = contactDetail.Status;

            if (id != contactDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(contactDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(id))
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

        // POST: api/ContactDetails
        [ResponseType(typeof(ContactDetail))]
        public IHttpActionResult PostContactDetail(ContactDetail contactDetail)
        {
            ContactDetail contactDetails = new ContactDetail();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            contactDetails.Id = contactDetail.Id;
            contactDetails.First_Name = contactDetail.First_Name.Replace(" ", "");
            contactDetails.Last_Name = contactDetail.Last_Name.Replace(" ", "");
            contactDetails.Email = contactDetail.Email.Replace(" ", "");
            contactDetails.Phone_Number = contactDetail.Phone_Number.Replace(" ", "");
            contactDetails.Status = contactDetail.Status;

            db.ContactDetails.Add(contactDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactDetail.Id }, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [ResponseType(typeof(ContactDetail))]
        public IHttpActionResult DeleteContactDetail(int id)
        {
            ContactDetail contactDetail = db.ContactDetails.Find(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            db.ContactDetails.Remove(contactDetail);
            db.SaveChanges();

            return Ok(contactDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactDetailExists(int id)
        {
            return db.ContactDetails.Count(e => e.Id == id) > 0;
        }
    }
}