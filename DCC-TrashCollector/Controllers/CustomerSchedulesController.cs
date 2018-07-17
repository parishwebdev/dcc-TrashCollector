using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCC_TrashCollector.Models;

namespace DCC_TrashCollector.Controllers
{
    public class CustomerSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerSchedules
        public ActionResult Index()
        {
            var customerSchedules = db.CustomerSchedules.Include(c => c.Day);
            return View(customerSchedules.ToList());
        }

        // GET: CustomerSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSchedule customerSchedule = db.CustomerSchedules.Find(id);
            if (customerSchedule == null)
            {
                return HttpNotFound();
            }
            return View(customerSchedule);
        }

        // GET: CustomerSchedules/Create
        public ActionResult Create()
        {
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen");
            return View();
        }

        // POST: CustomerSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerScheduleId,DayId,Pickedup,ExtraPickUpDate,TempStartDate,TempEndDate")] CustomerSchedule customerSchedule)
        {
            if (ModelState.IsValid)
            {
                db.CustomerSchedules.Add(customerSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customerSchedule.DayId);
            return View(customerSchedule);
        }

        // GET: CustomerSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSchedule customerSchedule = db.CustomerSchedules.Find(id);
            if (customerSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customerSchedule.DayId);
            return View(customerSchedule);
        }

        // POST: CustomerSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerScheduleId,DayId,Pickedup,ExtraPickUpDate,TempStartDate,TempEndDate")] CustomerSchedule customerSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customerSchedule.DayId);
            return View(customerSchedule);
        }

        // GET: CustomerSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerSchedule customerSchedule = db.CustomerSchedules.Find(id);
            if (customerSchedule == null)
            {
                return HttpNotFound();
            }
            return View(customerSchedule);
        }

        // POST: CustomerSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerSchedule customerSchedule = db.CustomerSchedules.Find(id);
            db.CustomerSchedules.Remove(customerSchedule);
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
