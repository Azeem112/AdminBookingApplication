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
    public class CustomerRegionsController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerRegions
        public ActionResult Index()
        {
            var customerRegions = db.CustomerRegions.Include(c => c.Country).Include(c => c.Currency);
            return View(customerRegions.ToList());
        }

        // GET: CustomerRegions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerRegion customerRegion = db.CustomerRegions.Find(id);
            if (customerRegion == null)
            {
                return HttpNotFound();
            }
            return View(customerRegion);
        }

        // GET: CustomerRegions/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "CurrencyName");
            return View();
        }

        // POST: CustomerRegions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CountryId,CurrencyId,TimeZone,DateFormate,TimeFormate")] CustomerRegion customerRegion)
        {
            if (ModelState.IsValid)
            {
                db.CustomerRegions.Add(customerRegion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerRegion.CountryId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "CurrencyName", customerRegion.CurrencyId);
            return View(customerRegion);
        }

        // GET: CustomerRegions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerRegion customerRegion = db.CustomerRegions.Find(id);
            if (customerRegion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerRegion.CountryId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "CurrencyName", customerRegion.CurrencyId);
            return View(customerRegion);
        }

        // POST: CustomerRegions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountryId,CurrencyId,TimeZone,DateFormate,TimeFormate")] CustomerRegion customerRegion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerRegion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerRegion.CountryId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "CurrencyName", customerRegion.CurrencyId);
            return View(customerRegion);
        }

        // GET: CustomerRegions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerRegion customerRegion = db.CustomerRegions.Find(id);
            if (customerRegion == null)
            {
                return HttpNotFound();
            }
            return View(customerRegion);
        }

        // POST: CustomerRegions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerRegion customerRegion = db.CustomerRegions.Find(id);
            db.CustomerRegions.Remove(customerRegion);
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
