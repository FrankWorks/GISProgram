using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GISProgram.Models;

namespace GISProgram.Controllers
{
    public class tblParksController : Controller
    {
        private ModelCode db = new ModelCode();

        // GET: tblParks
        public ActionResult Index()
        {
            return View(db.tblParks.ToList());
        }

        // GET: tblParks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPark tblPark = db.tblParks.Find(id);
            if (tblPark == null)
            {
                return HttpNotFound();
            }
            return View(tblPark);
        }

        // GET: tblParks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblParks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParkName,Agency")] tblPark tblPark)
        {
            if (ModelState.IsValid)
            {
                db.tblParks.Add(tblPark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPark);
        }

        // GET: tblParks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPark tblPark = db.tblParks.Find(id);
            if (tblPark == null)
            {
                return HttpNotFound();
            }
            return View(tblPark);
        }

        // POST: tblParks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParkName,Agency")] tblPark tblPark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPark);
        }

        // GET: tblParks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPark tblPark = db.tblParks.Find(id);
            if (tblPark == null)
            {
                return HttpNotFound();
            }
            return View(tblPark);
        }

        // POST: tblParks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPark tblPark = db.tblParks.Find(id);
            db.tblParks.Remove(tblPark);
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
