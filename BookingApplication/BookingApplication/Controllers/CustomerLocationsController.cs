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
    public class CustomerLocationsController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerLocations
        public ActionResult Index()
        {
            return View(db.CustomerLocations.ToList());
        }

        // GET: CustomerLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLocation customerLocation = db.CustomerLocations.Find(id);
            if (customerLocation == null)
            {
                return HttpNotFound();
            }
            return View(customerLocation);
        }

        // GET: CustomerLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,ZipCode,State,CountryID,Latitude,Longitude,IntervensionZone,Radius")] CustomerLocation customerLocation)
        {
            if (ModelState.IsValid)
            {
                db.CustomerLocations.Add(customerLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerLocation);
        }

        // GET: CustomerLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLocation customerLocation = db.CustomerLocations.Find(id);
            if (customerLocation == null)
            {
                return HttpNotFound();
            }
            return View(customerLocation);
        }

        // POST: CustomerLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,ZipCode,State,CountryID,Latitude,Longitude,IntervensionZone,Radius")] CustomerLocation customerLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerLocation);
        }

        // GET: CustomerLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerLocation customerLocation = db.CustomerLocations.Find(id);
            if (customerLocation == null)
            {
                return HttpNotFound();
            }
            return View(customerLocation);
        }

        // POST: CustomerLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerLocation customerLocation = db.CustomerLocations.Find(id);
            db.CustomerLocations.Remove(customerLocation);
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
