using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    public class ClassDataController : ApiController
    {
        private storeEntities db = new storeEntities();

        // GET: api/ClassData
        public IQueryable<class_data> Getclass_data()
        {
            return db.class_data;
        }

        // GET: api/ClassData/5
        [ResponseType(typeof(class_data))]
        public async Task<IHttpActionResult> Getclass_data(int id)
        {
            class_data class_data = await db.class_data.FindAsync(id);
            if (class_data == null)
            {
                return NotFound();
            }

            return Ok(class_data);
        }

        // PUT: api/ClassData/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclass_data(int id, class_data class_data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != class_data.id)
            {
                return BadRequest();
            }

            db.Entry(class_data).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!class_dataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(class_data);
        }

        // POST: api/ClassData
        [ResponseType(typeof(class_data))]
        public async Task<IHttpActionResult> Postclass_data(class_data class_data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.class_data.Add(class_data);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = class_data.id }, class_data);
        }

        // DELETE: api/ClassData/5
        [ResponseType(typeof(class_data))]
        public async Task<IHttpActionResult> Deleteclass_data([FromUri]IEnumerable<int> ids)
        {
            class_data class_data = null;
            foreach (int id in ids)
            {
                class_data = await db.class_data.FindAsync(id);
                if (class_data == null)
                {
                    return NotFound();
                }

                db.class_data.Remove(class_data);
            }
            await db.SaveChangesAsync();
            return Ok(class_data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool class_dataExists(int id)
        {
            return db.class_data.Count(e => e.id == id) > 0;
        }
    }
}