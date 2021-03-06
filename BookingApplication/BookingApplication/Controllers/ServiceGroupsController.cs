﻿using System;
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
    public class ServiceGroupsController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: ServiceGroups
        public ActionResult Index()
        {
            return View(db.ServiceGroups.ToList());
        }

        // GET: ServiceGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGroup serviceGroup = db.ServiceGroups.Find(id);
            if (serviceGroup == null)
            {
                return HttpNotFound();
            }
            return View(serviceGroup);
        }

        // GET: ServiceGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] ServiceGroup serviceGroup)
        {
            if (ModelState.IsValid)
            {
                db.ServiceGroups.Add(serviceGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceGroup);
        }

        // GET: ServiceGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGroup serviceGroup = db.ServiceGroups.Find(id);
            if (serviceGroup == null)
            {
                return HttpNotFound();
            }
            return View(serviceGroup);
        }

        // POST: ServiceGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ServiceGroup serviceGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceGroup);
        }

        // GET: ServiceGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGroup serviceGroup = db.ServiceGroups.Find(id);
            if (serviceGroup == null)
            {
                return HttpNotFound();
            }
            return View(serviceGroup);
        }

        // POST: ServiceGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceGroup serviceGroup = db.ServiceGroups.Find(id);
            db.ServiceGroups.Remove(serviceGroup);
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
