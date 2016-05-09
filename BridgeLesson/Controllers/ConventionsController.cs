using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BridgeLesson.Models;

namespace BridgeLesson.Controllers
{
    public class ConventionsController : Controller
    {
        private BridgeLessonDbContext db = new BridgeLessonDbContext();

        // GET: Conventions
        public async Task<ActionResult> Index()
        {
            return View(await db.BiddingConventions.ToListAsync());
        }

       
        // GET: Conventions/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            if (biddingConvention == null)
            {
                return HttpNotFound();
            }
            return View(biddingConvention);
        }

        // GET: Conventions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conventions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,CreationDate")] BiddingConvention biddingConvention)
        {
            if (ModelState.IsValid)
            {
                db.BiddingConventions.Add(biddingConvention);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(biddingConvention);
        }

        // GET: Conventions/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            if (biddingConvention == null)
            {
                return HttpNotFound();
            }
            return View(biddingConvention);
        }

        // POST: Conventions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,CreationDate")] BiddingConvention biddingConvention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biddingConvention).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(biddingConvention);
        }

        // GET: Conventions/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            if (biddingConvention == null)
            {
                return HttpNotFound();
            }
            return View(biddingConvention);
        }

        // POST: Conventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            BiddingConvention biddingConvention = await db.BiddingConventions.FindAsync(id);
            db.BiddingConventions.Remove(biddingConvention);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public PartialViewResult ManageSystemConventions()
        {
            return PartialView();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
