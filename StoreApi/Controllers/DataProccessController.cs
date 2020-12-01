using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    public class DataProccessController : ApiController
    {
        private storeEntities db = new storeEntities();

        // GET: api/DataProccess
        public IQueryable<data_proccess> Getdata_proccess()
        {
            return db.data_proccess;
        }

        // GET: api/DataProccess/5
        [ResponseType(typeof(data_proccess))]
        public async Task<IHttpActionResult> Getdata_proccess(int id)
        {
            data_proccess data_proccess = await db.data_proccess.FindAsync(id);
            if (data_proccess == null)
            {
                return NotFound();
            }

            return Ok(data_proccess);
        }

        // PUT: api/DataProccess/5
        [ResponseType(typeof(data_proccess))]
        public async Task<IHttpActionResult> Putdata_proccess(int id, data_proccess data_proccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != data_proccess.id)
            {
                return BadRequest();
            }

            db.Entry(data_proccess).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!data_proccessExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(data_proccess);
        }

        // POST: api/DataProccess
        [ResponseType(typeof(data_proccess))]
        public async Task<IHttpActionResult> Postdata_proccess(data_proccess data_proccess)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.data_proccess.Add(data_proccess);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (data_proccessExists(data_proccess.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = data_proccess.id }, data_proccess);
        }

        // DELETE: api/DataProccess/5
        [ResponseType(typeof(data_proccess))]
        public async Task<IHttpActionResult> Deletedata_proccess([FromUri]IEnumerable<int> ids)
        {
            data_proccess data_proccess = null;
            foreach (int id in ids)
            {
                data_proccess = await db.data_proccess.FindAsync(id);
                if (data_proccess == null)
                {
                    return NotFound();
                }

                db.data_proccess.Remove(data_proccess);
            }
            await db.SaveChangesAsync();
            return Ok(data_proccess);
        }
        [HttpGet]
        [Route("api/filter")]
        public List<data_proccess> Fliter(DateTime from, DateTime to)
        {
            //DateTime from = DateTime.Now;
            //DateTime to = DateTime.Now;
            List<data_proccess> data_Proccess_list = null;
            try
            {
                 data_Proccess_list = db.data_proccess.Where(data => data.date_process >= from
                  && data.date_process <= to).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return data_Proccess_list;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool data_proccessExists(int id)
        {
            return db.data_proccess.Count(e => e.id == id) > 0;
        }
    }
}