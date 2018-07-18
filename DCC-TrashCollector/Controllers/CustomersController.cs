using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DCC_TrashCollector.Models;
using Microsoft.AspNet.Identity;

namespace DCC_TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.City).Include(c => c.Day).Include(c => c.State).Include(c => c.ZipCode);
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
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen");
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name");
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Balance,DayId,Pickedup,ExtraPickUpDate,TempStartDate,TempEndDate,AspNetUserId,AddressLine,CityId,ZipId,StateId")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                //Here want to save the currently logged in user id to employee model
                customer.AspNetUserId = User.Identity.GetUserId();
                //--------------------------
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", customer.CityId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customer.DayId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", customer.StateId);
            ViewBag.ZipId = new SelectList(db.ZipCodes, "Zip", "ZipCodeId", customer.ZipId);
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
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", customer.CityId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customer.DayId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", customer.StateId);
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip", customer.ZipId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Balance,DayId,Pickedup,ExtraPickUpDate,TempStartDate,TempEndDate,AspNetUserId,AddressLine,CityId,ZipId,StateId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", customer.CityId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayChoosen", customer.DayId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", customer.StateId);
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip", customer.ZipId);
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
