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
    public class BusinessSubCatageoriesController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: BusinessSubCatageories
        public ActionResult Index()
        {
            var businessSubCatageories = db.BusinessSubCatageories.Include(b => b.BusinessCatageory);
            return View(businessSubCatageories.ToList());
        }

        // GET: BusinessSubCatageories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessSubCatageory businessSubCatageory = db.BusinessSubCatageories.Find(id);
            if (businessSubCatageory == null)
            {
                return HttpNotFound();
            }
            return View(businessSubCatageory);
        }

        // GET: BusinessSubCatageories/Create
        public ActionResult Create()
        {
            ViewBag.BussinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name");
            return View();
        }

        // POST: BusinessSubCatageories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BussinessCatageoryId")] BusinessSubCatageory businessSubCatageory)
        {
            if (ModelState.IsValid)
            {
                db.BusinessSubCatageories.Add(businessSubCatageory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BussinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", businessSubCatageory.BussinessCatageoryId);
            return View(businessSubCatageory);
        }

        // GET: BusinessSubCatageories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessSubCatageory businessSubCatageory = db.BusinessSubCatageories.Find(id);
            if (businessSubCatageory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BussinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", businessSubCatageory.BussinessCatageoryId);
            return View(businessSubCatageory);
        }

        // POST: BusinessSubCatageories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BussinessCatageoryId")] BusinessSubCatageory businessSubCatageory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessSubCatageory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BussinessCatageoryId = new SelectList(db.BusinessCatageories, "Id", "Name", businessSubCatageory.BussinessCatageoryId);
            return View(businessSubCatageory);
        }

        // GET: BusinessSubCatageories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessSubCatageory businessSubCatageory = db.BusinessSubCatageories.Find(id);
            if (businessSubCatageory == null)
            {
                return HttpNotFound();
            }
            return View(businessSubCatageory);
        }

        // POST: BusinessSubCatageories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessSubCatageory businessSubCatageory = db.BusinessSubCatageories.Find(id);
            db.BusinessSubCatageories.Remove(businessSubCatageory);
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
