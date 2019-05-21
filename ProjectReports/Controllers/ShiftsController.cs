using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectReports.Models;

namespace ProjectReports.Controllers
{
    public class ShiftsController : Controller
    {
        private ReportsModel db = new ReportsModel();

        // GET: Shifts
        public ActionResult Index()
        {
            return View(db.Shifts.ToList());
        }

        // GET: Shifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifts shifts = db.Shifts.Find(id);
            if (shifts == null)
            {
                return HttpNotFound();
            }
            return View(shifts);
        }

        // GET: Shifts/Create
        [HttpGet]
        public ActionResult Create()
        {
            var workers = db.Workers.ToList();

            IEnumerable<SelectListItem> workersDDL = from w in workers
                                                     select new SelectListItem
                                                     {
                                                         Text = w.FirstName + " " + w.LastName,
                                                         Value = w.Id.ToString()
                                                     };

            ViewBag.Workers = new SelectList(workersDDL, "Value", "Text");
            return View();
        }

        // POST: Shifts/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FristWorker,SecondWorker,TimeRange,Date")] Shifts shifts)
        {
            if (ModelState.IsValid)
            {
                db.Shifts.Add(shifts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shifts);
        }

        // GET: Shifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifts shifts = db.Shifts.Find(id);
            if (shifts == null)
            {
                return HttpNotFound();
            }
            return View(shifts);
        }

        // POST: Shifts/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FristWorker,SecondWorker,TimeRange,Date")] Shifts shifts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shifts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create", "Reports");
            }
            return View(shifts);
        }

        // GET: Shifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shifts shifts = db.Shifts.Find(id);
            if (shifts == null)
            {
                return HttpNotFound();
            }
            return View(shifts);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shifts shifts = db.Shifts.Find(id);
            db.Shifts.Remove(shifts);
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
