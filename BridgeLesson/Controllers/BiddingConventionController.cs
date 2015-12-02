using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BridgeLesson.Models;

namespace BridgeLesson.Controllers
{
    public class BiddingConventionController : ApiController
    {
        private readonly BridgeLessonDbContext db = new BridgeLessonDbContext();

        // GET: api/BiddingConventions
        public async Task<IEnumerable<BiddingConvention>> GetBiddingConventions()
        {

            var biddingConventions = await db.BiddingConventions.ToListAsync();
            return biddingConventions;
        }

        // GET: api/BiddingConventions/5
        [ResponseType(typeof(List<BiddingConvention>))]
        public async Task<IHttpActionResult> GetBiddingConvention(long id)
        {
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            if (biddingConvention == null)
            {
                return NotFound();
            }

            return Ok(biddingConvention);
        }

        // PUT: api/BiddingConventions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBiddingConvention(long id, BiddingConvention biddingConvention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != biddingConvention.Id)
            {
                return BadRequest();
            }

            db.Entry(biddingConvention).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiddingConventionExists(id))
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

        // POST: api/BiddingConventions
        [ResponseType(typeof(BiddingConvention))]
        public async Task<IHttpActionResult> PostBiddingConvention(BiddingConvention biddingConvention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BiddingConventions.Add(biddingConvention);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = biddingConvention.Id }, biddingConvention);
        }

        // DELETE: api/BiddingConventions/5
        [ResponseType(typeof(BiddingConvention))]
        public async Task<IHttpActionResult> DeleteBiddingConvention(long id)
        {
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            if (biddingConvention == null)
            {
                return NotFound();
            }

            db.BiddingConventions.Remove(biddingConvention);
            await db.SaveChangesAsync();

            return Ok(biddingConvention);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BiddingConventionExists(long id)
        {
            return db.BiddingConventions.Count(e => e.Id == id) > 0;
        }
    }
}