using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingApplication.Models;

namespace BookingApplication.Controllers
{
    public class WorkingTimesController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: WorkingTimes
        public ActionResult Index()
        {
            return View(db.WorkingTimes.ToList());
        }

        // GET: WorkingTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTime workingTime = db.WorkingTimes.Find(id);
            if (workingTime == null)
            {
                return HttpNotFound();
            }
            return View(workingTime);
        }

        // GET: WorkingTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,isoff,StartTime,EndTime,LunchFrom,LunchToo")] WorkingTime workingTime)
        {
            if (ModelState.IsValid)
            {
                db.WorkingTimes.Add(workingTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workingTime);
        }

        // GET: WorkingTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTime workingTime = db.WorkingTimes.Find(id);
            if (workingTime == null)
            {
                return HttpNotFound();
            }
            return View(workingTime);
        }

        // POST: WorkingTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,isoff,StartTime,EndTime,LunchFrom,LunchToo")] WorkingTime workingTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workingTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workingTime);
        }

        // GET: WorkingTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkingTime workingTime = db.WorkingTimes.Find(id);
            if (workingTime == null)
            {
                return HttpNotFound();
            }
            return View(workingTime);
        }

        // POST: WorkingTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkingTime workingTime = db.WorkingTimes.Find(id);
            db.WorkingTimes.Remove(workingTime);
            db.SaveChanges();
            return RedirectToAction("Index");
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
