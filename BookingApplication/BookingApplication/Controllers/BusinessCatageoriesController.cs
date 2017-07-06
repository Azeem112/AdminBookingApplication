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
    public class BusinessCatageoriesController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: BusinessCatageories
        public ActionResult Index()
        {
            return View(db.BusinessCatageories.ToList());
        }

        // GET: BusinessCatageories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCatageory businessCatageory = db.BusinessCatageories.Find(id);
            if (businessCatageory == null)
            {
                return HttpNotFound();
            }
            return View(businessCatageory);
        }

        // GET: BusinessCatageories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessCatageories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BusinessCatageory businessCatageory)
        {
            if (ModelState.IsValid)
            {
                db.BusinessCatageories.Add(businessCatageory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessCatageory);
        }

        // GET: BusinessCatageories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCatageory businessCatageory = db.BusinessCatageories.Find(id);
            if (businessCatageory == null)
            {
                return HttpNotFound();
            }
            return View(businessCatageory);
        }

        // POST: BusinessCatageories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BusinessCatageory businessCatageory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessCatageory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessCatageory);
        }

        // GET: BusinessCatageories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessCatageory businessCatageory = db.BusinessCatageories.Find(id);
            if (businessCatageory == null)
            {
                return HttpNotFound();
            }
            return View(businessCatageory);
        }

        // POST: BusinessCatageories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessCatageory businessCatageory = db.BusinessCatageories.Find(id);
            db.BusinessCatageories.Remove(businessCatageory);
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
