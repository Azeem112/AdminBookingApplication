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
    public class CustomerSMSController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerSMS
        public ActionResult Index()
        {
            return View(db.CustomerSMS.ToList());
        }

        // GET: CustomerSMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSM customerSM = db.CustomerSMS.Find(id);
            if (customerSM == null)
            {
                return HttpNotFound();
            }
            return View(customerSM);
        }

        // GET: CustomerSMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerSMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PackageID,RemainingSMS")] CustomerSM customerSM)
        {
            if (ModelState.IsValid)
            {
                db.CustomerSMS.Add(customerSM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerSM);
        }

        // GET: CustomerSMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSM customerSM = db.CustomerSMS.Find(id);
            if (customerSM == null)
            {
                return HttpNotFound();
            }
            return View(customerSM);
        }

        // POST: CustomerSMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PackageID,RemainingSMS")] CustomerSM customerSM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerSM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerSM);
        }

        // GET: CustomerSMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSM customerSM = db.CustomerSMS.Find(id);
            if (customerSM == null)
            {
                return HttpNotFound();
            }
            return View(customerSM);
        }

        // POST: CustomerSMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerSM customerSM = db.CustomerSMS.Find(id);
            db.CustomerSMS.Remove(customerSM);
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
