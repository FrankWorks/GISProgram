using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GISProgram.Models;

namespace GISProgram.Controllers
{
    public class ProgramsR1Controller : Controller
    {
        private ISDGIS db = new ISDGIS();

        // GET: ProgramsR1
        public async Task<ActionResult> Index()
        {
            var programs = db.Programs.Include(p => p.Location).Include(p => p.Location1).Include(p => p.ProgramCategory).Include(p => p.ProgramCategory1);
            return View(await programs.ToListAsync());
        }

        // GET: ProgramsR1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: ProgramsR1/Create
        public ActionResult Create()
        {
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name");
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name");
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1");
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1");
            return View();
        }

        // POST: ProgramsR1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "programID,locationID,name,type,description,minAge,maxAge,displayAge,feeStructure,registrationRequired,registrationFee,frequencyType,frequency,specialCriteria,programCategoryID")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            return View(program);
        }

        // GET: ProgramsR1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            return View(program);
        }

        // POST: ProgramsR1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "programID,locationID,name,type,description,minAge,maxAge,displayAge,feeStructure,registrationRequired,registrationFee,frequencyType,frequency,specialCriteria,programCategoryID")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.locationID = new SelectList(db.Locations, "locationID", "name", program.locationID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            ViewBag.programCategoryID = new SelectList(db.ProgramCategories, "programCategoryID", "programCategory1", program.programCategoryID);
            return View(program);
        }

        // GET: ProgramsR1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: ProgramsR1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Program program = await db.Programs.FindAsync(id);
            db.Programs.Remove(program);
            await db.SaveChangesAsync();
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
