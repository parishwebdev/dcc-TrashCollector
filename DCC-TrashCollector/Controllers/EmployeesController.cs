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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.ZipCode);
            return View(employees.ToList());
        }

        public ActionResult Portal(int? dayChoice)
        {
            //also if during pause period return 0 or null
            var customersPerZip = GetEmployeeCustomers();
            if (dayChoice == null)
            {
                var currentDayId = GetCurrentDayId();
                customersPerZip = customersPerZip.Where(c => c.DayId == currentDayId);
            }
            else
            {
                //Form Extra Days
                foreach(var cust in customersPerZip)
                { 
                       customersPerZip = customersPerZip.Where(c => c.DayId == dayChoice);
                }
               

            }
            
            return View(customersPerZip.ToList());
        }


        private int GetCurrentDayId(DateTime? dateTime)
        {
            //not part of userstories
                var currentDayString = dateTime.Value.DayOfWeek.ToString();
                var day = db.Days.Where(dy => dy.DayChoosen == currentDayString);

                return day.Single().DayId;
            
        }

        private int GetCurrentDayId()
        {
            //var currentDayString = DateTime.Now.DayOfWeek.ToString(); 
            var currentDayString = "Friday"; // change back to ^ later
            var day = db.Days.Where(dy => dy.DayChoosen == currentDayString);
            return day.SingleOrDefault().DayId;
        }


        private IEnumerable<Customer> GetEmployeeCustomers()
        {
            var currentUserId = User.Identity.GetUserId();
            Employee employee = db.Employees.SingleOrDefault(e => e.AspNetUserId == currentUserId);

            IEnumerable<Customer> customersPerZip = new List<Customer>();
            if (employee.AspNetUserId == currentUserId)
            {
                customersPerZip = db.Customers.Where(cust => cust.ZipId == employee.ZipId).Include(c => c.City)
                                   .Include(c => c.Day)
                                   .Include(c => c.State)
                                   .Include(c => c.ZipCode);
                
            }
            return customersPerZip;

        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,ZipId")] Employee employee)
        {
            if (ModelState.IsValid)
            {

                //Here want to save the currently logged in user id to employee model
                employee.AspNetUserId = User.Identity.GetUserId();
                //--------------------------
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index","Customers",null);
            }

            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip", employee.ZipId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip", employee.ZipId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,ZipId,AspNetUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZipId = new SelectList(db.ZipCodes, "ZipCodeId", "Zip", employee.ZipId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
