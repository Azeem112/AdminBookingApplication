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
    public class CustomersController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.CustomerBusinessDetail).Include(c => c.CustomerContact).Include(c => c.CustomerDetail).Include(c => c.CustomerGallery).Include(c => c.CustomerLocation).Include(c => c.CustomerRegion).Include(c => c.CustomerSM).Include(c => c.CustomerType).Include(c => c.User).Include(c => c.WorkingTime);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.BussinessID = new SelectList(db.CustomerBusinessDetails, "Id", "SRIET");
            ViewBag.ContactId = new SelectList(db.CustomerContacts, "Id", "BussinessEmail");
            ViewBag.DetailId = new SelectList(db.CustomerDetails, "Id", "BussinessName");
            ViewBag.GalleryID = new SelectList(db.CustomerGalleries, "Id", "Image1");
            ViewBag.LocationId = new SelectList(db.CustomerLocations, "Id", "City");
            ViewBag.RegionID = new SelectList(db.CustomerRegions, "Id", "TimeZone");
            ViewBag.SmsID = new SelectList(db.CustomerSMS, "Id", "Id");
            ViewBag.TypeID = new SelectList(db.CustomerTypes, "Id", "CompanyName");
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            ViewBag.WorkingID = new SelectList(db.WorkingTimes, "Id", "Day");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DetailId,LocationId,ContactId,BussinessID,GalleryID,RegionID,TypeID,SmsID,UserID,WorkingID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BussinessID = new SelectList(db.CustomerBusinessDetails, "Id", "SRIET", customer.BussinessID);
            ViewBag.ContactId = new SelectList(db.CustomerContacts, "Id", "BussinessEmail", customer.ContactId);
            ViewBag.DetailId = new SelectList(db.CustomerDetails, "Id", "BussinessName", customer.DetailId);
            ViewBag.GalleryID = new SelectList(db.CustomerGalleries, "Id", "Image1", customer.GalleryID);
            ViewBag.LocationId = new SelectList(db.CustomerLocations, "Id", "City", customer.LocationId);
            ViewBag.RegionID = new SelectList(db.CustomerRegions, "Id", "TimeZone", customer.RegionID);
            ViewBag.SmsID = new SelectList(db.CustomerSMS, "Id", "Id", customer.SmsID);
            ViewBag.TypeID = new SelectList(db.CustomerTypes, "Id", "CompanyName", customer.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", customer.UserID);
            ViewBag.WorkingID = new SelectList(db.WorkingTimes, "Id", "Day", customer.WorkingID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BussinessID = new SelectList(db.CustomerBusinessDetails, "Id", "SRIET", customer.BussinessID);
            ViewBag.ContactId = new SelectList(db.CustomerContacts, "Id", "BussinessEmail", customer.ContactId);
            ViewBag.DetailId = new SelectList(db.CustomerDetails, "Id", "BussinessName", customer.DetailId);
            ViewBag.GalleryID = new SelectList(db.CustomerGalleries, "Id", "Image1", customer.GalleryID);
            ViewBag.LocationId = new SelectList(db.CustomerLocations, "Id", "City", customer.LocationId);
            ViewBag.RegionID = new SelectList(db.CustomerRegions, "Id", "TimeZone", customer.RegionID);
            ViewBag.SmsID = new SelectList(db.CustomerSMS, "Id", "Id", customer.SmsID);
            ViewBag.TypeID = new SelectList(db.CustomerTypes, "Id", "CompanyName", customer.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", customer.UserID);
            ViewBag.WorkingID = new SelectList(db.WorkingTimes, "Id", "Day", customer.WorkingID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DetailId,LocationId,ContactId,BussinessID,GalleryID,RegionID,TypeID,SmsID,UserID,WorkingID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BussinessID = new SelectList(db.CustomerBusinessDetails, "Id", "SRIET", customer.BussinessID);
            ViewBag.ContactId = new SelectList(db.CustomerContacts, "Id", "BussinessEmail", customer.ContactId);
            ViewBag.DetailId = new SelectList(db.CustomerDetails, "Id", "BussinessName", customer.DetailId);
            ViewBag.GalleryID = new SelectList(db.CustomerGalleries, "Id", "Image1", customer.GalleryID);
            ViewBag.LocationId = new SelectList(db.CustomerLocations, "Id", "City", customer.LocationId);
            ViewBag.RegionID = new SelectList(db.CustomerRegions, "Id", "TimeZone", customer.RegionID);
            ViewBag.SmsID = new SelectList(db.CustomerSMS, "Id", "Id", customer.SmsID);
            ViewBag.TypeID = new SelectList(db.CustomerTypes, "Id", "CompanyName", customer.TypeID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", customer.UserID);
            ViewBag.WorkingID = new SelectList(db.WorkingTimes, "Id", "Day", customer.WorkingID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
