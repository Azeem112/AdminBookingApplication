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
    public class CustomerGalleriesController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: CustomerGalleries
        public ActionResult Index()
        {
            return View(db.CustomerGalleries.ToList());
        }

        // GET: CustomerGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGallery customerGallery = db.CustomerGalleries.Find(id);
            if (customerGallery == null)
            {
                return HttpNotFound();
            }
            return View(customerGallery);
        }

        // GET: CustomerGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image1,Image2,Image3,Image4,Image5")] CustomerGallery customerGallery)
        {
            if (ModelState.IsValid)
            {
                db.CustomerGalleries.Add(customerGallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerGallery);
        }

        // GET: CustomerGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGallery customerGallery = db.CustomerGalleries.Find(id);
            if (customerGallery == null)
            {
                return HttpNotFound();
            }
            return View(customerGallery);
        }

        // POST: CustomerGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image1,Image2,Image3,Image4,Image5")] CustomerGallery customerGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerGallery);
        }

        // GET: CustomerGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerGallery customerGallery = db.CustomerGalleries.Find(id);
            if (customerGallery == null)
            {
                return HttpNotFound();
            }
            return View(customerGallery);
        }

        // POST: CustomerGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerGallery customerGallery = db.CustomerGalleries.Find(id);
            db.CustomerGalleries.Remove(customerGallery);
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
