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
    public class CustomerDetailsController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerDetails
        public ActionResult Index()
        {
            var customerDetails = db.CustomerDetails.Include(c => c.BusinessCatageory);
            return View(customerDetails.ToList());
        }

        // GET: CustomerDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerDetail);
        }

        // GET: CustomerDetails/Create
        public ActionResult Create()
        {
            ViewBag.BusinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name");
            return View();
        }

        // POST: CustomerDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BussinessName,BussinessWebsite,BusinessCatageoryId,SubCatageoryNo")] CustomerDetail customerDetail)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDetails.Add(customerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", customerDetail.BusinessCatageoryId);
            return View(customerDetail);
        }

        // GET: CustomerDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", customerDetail.BusinessCatageoryId);
            return View(customerDetail);
        }

        // POST: CustomerDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BussinessName,BussinessWebsite,BusinessCatageoryId,SubCatageoryNo")] CustomerDetail customerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", customerDetail.BusinessCatageoryId);
            return View(customerDetail);
        }

        // GET: CustomerDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            if (customerDetail == null)
            {
                return HttpNotFound();
            }
            return View(customerDetail);
        }

        // POST: CustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerDetail customerDetail = db.CustomerDetails.Find(id);
            db.CustomerDetails.Remove(customerDetail);
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
