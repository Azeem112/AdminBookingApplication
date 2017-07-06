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
    public class Service_GroupController : Controller
    {
        private BussinessBookingEntities db = new BussinessBookingEntities();

        // GET: Service_Group
        public ActionResult Index()
        {
            var service_Group = db.Service_Group.Include(s => s.Service).Include(s => s.ServiceGroup);
            return View(service_Group.ToList());
        }

        // GET: Service_Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Group service_Group = db.Service_Group.Find(id);
            if (service_Group == null)
            {
                return HttpNotFound();
            }
            return View(service_Group);
        }

        // GET: Service_Group/Create
        public ActionResult Create()
        {
            ViewBag.ServiceID = new SelectList(db.Services, "Id", "Name");
            ViewBag.GroupID = new SelectList(db.ServiceGroups, "Id", "Name");
            return View();
        }

        // POST: Service_Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServiceID,GroupID")] Service_Group service_Group)
        {
            if (ModelState.IsValid)
            {
                db.Service_Group.Add(service_Group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceID = new SelectList(db.Services, "Id", "Name", service_Group.ServiceID);
            ViewBag.GroupID = new SelectList(db.ServiceGroups, "Id", "Name", service_Group.GroupID);
            return View(service_Group);
        }

        // GET: Service_Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Group service_Group = db.Service_Group.Find(id);
            if (service_Group == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceID = new SelectList(db.Services, "Id", "Name", service_Group.ServiceID);
            ViewBag.GroupID = new SelectList(db.ServiceGroups, "Id", "Name", service_Group.GroupID);
            return View(service_Group);
        }

        // POST: Service_Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceID,GroupID")] Service_Group service_Group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_Group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceID = new SelectList(db.Services, "Id", "Name", service_Group.ServiceID);
            ViewBag.GroupID = new SelectList(db.ServiceGroups, "Id", "Name", service_Group.GroupID);
            return View(service_Group);
        }

        // GET: Service_Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_Group service_Group = db.Service_Group.Find(id);
            if (service_Group == null)
            {
                return HttpNotFound();
            }
            return View(service_Group);
        }

        // POST: Service_Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_Group service_Group = db.Service_Group.Find(id);
            db.Service_Group.Remove(service_Group);
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
