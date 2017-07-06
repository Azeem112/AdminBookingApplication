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
    public class Customer_SubCatageoryController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: Customer_SubCatageory
        public ActionResult Index()
        {
            var customer_SubCatageory = db.Customer_SubCatageory.Include(c => c.BusinessSubCatageory).Include(c => c.Customer);
            return View(customer_SubCatageory.ToList());
        }

        // GET: Customer_SubCatageory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_SubCatageory customer_SubCatageory = db.Customer_SubCatageory.Find(id);
            if (customer_SubCatageory == null)
            {
                return HttpNotFound();
            }
            return View(customer_SubCatageory);
        }

        // GET: Customer_SubCatageory/Create
        public ActionResult Create()
        {
            ViewBag.SubCatageoryId = new SelectList(db.BusinessSubCatageories, "Id", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "Id");
            return View();
        }

        // POST: Customer_SubCatageory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerID,SubCatageoryId")] Customer_SubCatageory customer_SubCatageory)
        {
            if (ModelState.IsValid)
            {
                db.Customer_SubCatageory.Add(customer_SubCatageory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCatageoryId = new SelectList(db.BusinessSubCatageories, "Id", "Name", customer_SubCatageory.SubCatageoryId);
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "Id", customer_SubCatageory.CustomerID);
            return View(customer_SubCatageory);
        }

        // GET: Customer_SubCatageory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_SubCatageory customer_SubCatageory = db.Customer_SubCatageory.Find(id);
            if (customer_SubCatageory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCatageoryId = new SelectList(db.BusinessSubCatageories, "Id", "Name", customer_SubCatageory.SubCatageoryId);
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "Id", customer_SubCatageory.CustomerID);
            return View(customer_SubCatageory);
        }

        // POST: Customer_SubCatageory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerID,SubCatageoryId")] Customer_SubCatageory customer_SubCatageory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_SubCatageory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCatageoryId = new SelectList(db.BusinessSubCatageories, "Id", "Name", customer_SubCatageory.SubCatageoryId);
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "Id", customer_SubCatageory.CustomerID);
            return View(customer_SubCatageory);
        }

        // GET: Customer_SubCatageory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_SubCatageory customer_SubCatageory = db.Customer_SubCatageory.Find(id);
            if (customer_SubCatageory == null)
            {
                return HttpNotFound();
            }
            return View(customer_SubCatageory);
        }

        // POST: Customer_SubCatageory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_SubCatageory customer_SubCatageory = db.Customer_SubCatageory.Find(id);
            db.Customer_SubCatageory.Remove(customer_SubCatageory);
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
