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
    public class GiftVouchersController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: GiftVouchers
        public ActionResult Index()
        {
            var giftVouchers = db.GiftVouchers.Include(g => g.Expire);
            return View(giftVouchers.ToList());
        }

        // GET: GiftVouchers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftVoucher giftVoucher = db.GiftVouchers.Find(id);
            if (giftVoucher == null)
            {
                return HttpNotFound();
            }
            return View(giftVoucher);
        }

        // GET: GiftVouchers/Create
        public ActionResult Create()
        {
            ViewBag.ExpireId = new SelectList(db.Expires, "Id", "Every");
            return View();
        }

        // POST: GiftVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Discount,Type,Name,Sku,Description,RedmeeOnline,Voided,ExpireId")] GiftVoucher giftVoucher)
        {
            if (ModelState.IsValid)
            {
                db.GiftVouchers.Add(giftVoucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpireId = new SelectList(db.Expires, "Id", "Every", giftVoucher.ExpireId);
            return View(giftVoucher);
        }

        // GET: GiftVouchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftVoucher giftVoucher = db.GiftVouchers.Find(id);
            if (giftVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpireId = new SelectList(db.Expires, "Id", "Every", giftVoucher.ExpireId);
            return View(giftVoucher);
        }

        // POST: GiftVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Discount,Type,Name,Sku,Description,RedmeeOnline,Voided,ExpireId")] GiftVoucher giftVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giftVoucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpireId = new SelectList(db.Expires, "Id", "Every", giftVoucher.ExpireId);
            return View(giftVoucher);
        }

        // GET: GiftVouchers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiftVoucher giftVoucher = db.GiftVouchers.Find(id);
            if (giftVoucher == null)
            {
                return HttpNotFound();
            }
            return View(giftVoucher);
        }

        // POST: GiftVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiftVoucher giftVoucher = db.GiftVouchers.Find(id);
            db.GiftVouchers.Remove(giftVoucher);
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
