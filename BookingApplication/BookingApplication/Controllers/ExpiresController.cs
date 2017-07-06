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
    public class ExpiresController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: Expires
        public ActionResult Index()
        {
            return View(db.Expires.ToList());
        }

        // GET: Expires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expire expire = db.Expires.Find(id);
            if (expire == null)
            {
                return HttpNotFound();
            }
            return View(expire);
        }

        // GET: Expires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,From,To,Every,Name")] Expire expire)
        {
            if (ModelState.IsValid)
            {
                db.Expires.Add(expire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expire);
        }

        // GET: Expires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expire expire = db.Expires.Find(id);
            if (expire == null)
            {
                return HttpNotFound();
            }
            return View(expire);
        }

        // POST: Expires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,From,To,Every,Name")] Expire expire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expire);
        }

        // GET: Expires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expire expire = db.Expires.Find(id);
            if (expire == null)
            {
                return HttpNotFound();
            }
            return View(expire);
        }

        // POST: Expires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expire expire = db.Expires.Find(id);
            db.Expires.Remove(expire);
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
