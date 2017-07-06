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
    public class CustomerBusinessDetailsController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerBusinessDetails
        public ActionResult Index()
        {
            return View(db.CustomerBusinessDetails.ToList());
        }

        // GET: CustomerBusinessDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBusinessDetail customerBusinessDetail = db.CustomerBusinessDetails.Find(id);
            if (customerBusinessDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerBusinessDetail);
        }

        // GET: CustomerBusinessDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerBusinessDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SRIET,VatNumber,APE,Description,Logo")] CustomerBusinessDetail customerBusinessDetail)
        {
            if (ModelState.IsValid)
            {
                db.CustomerBusinessDetails.Add(customerBusinessDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerBusinessDetail);
        }

        // GET: CustomerBusinessDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBusinessDetail customerBusinessDetail = db.CustomerBusinessDetails.Find(id);
            if (customerBusinessDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerBusinessDetail);
        }

        // POST: CustomerBusinessDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SRIET,VatNumber,APE,Description,Logo")] CustomerBusinessDetail customerBusinessDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerBusinessDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerBusinessDetail);
        }

        // GET: CustomerBusinessDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerBusinessDetail customerBusinessDetail = db.CustomerBusinessDetails.Find(id);
            if (customerBusinessDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerBusinessDetail);
        }

        // POST: CustomerBusinessDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerBusinessDetail customerBusinessDetail = db.CustomerBusinessDetails.Find(id);
            db.CustomerBusinessDetails.Remove(customerBusinessDetail);
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
