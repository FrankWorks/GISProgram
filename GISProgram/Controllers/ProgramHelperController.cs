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
    public class ProgramHelperController : Controller
    {
        private ModelCode db = new ModelCode();

        // GET: ProgramHelper
        public async Task<ActionResult> Index()
        {
            return View(await db.vwProgramHelpers.ToListAsync());
        }

        // GET: ProgramHelper/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwProgramHelper vwProgramHelper = await db.vwProgramHelpers.FindAsync(id);
            if (vwProgramHelper == null)
            {
                return HttpNotFound();
            }
            return View(vwProgramHelper);
        }

        // GET: ProgramHelper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramHelper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LocationName,URLFriendlyName,ProgramCategory,ProgramName,ProgramDescription,MinAge,MaxAge,DisplayAge,FrequencyType,Frequency")] vwProgramHelper vwProgramHelper)
        {
            if (ModelState.IsValid)
            {
                db.vwProgramHelpers.Add(vwProgramHelper);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vwProgramHelper);
        }

        // GET: ProgramHelper/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwProgramHelper vwProgramHelper = await db.vwProgramHelpers.FindAsync(id);
            if (vwProgramHelper == null)
            {
                return HttpNotFound();
            }
            return View(vwProgramHelper);
        }

        // POST: ProgramHelper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LocationName,URLFriendlyName,ProgramCategory,ProgramName,ProgramDescription,MinAge,MaxAge,DisplayAge,FrequencyType,Frequency")] vwProgramHelper vwProgramHelper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwProgramHelper).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vwProgramHelper);
        }

        // GET: ProgramHelper/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwProgramHelper vwProgramHelper = await db.vwProgramHelpers.FindAsync(id);
            if (vwProgramHelper == null)
            {
                return HttpNotFound();
            }
            return View(vwProgramHelper);
        }

        // POST: ProgramHelper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            vwProgramHelper vwProgramHelper = await db.vwProgramHelpers.FindAsync(id);
            db.vwProgramHelpers.Remove(vwProgramHelper);
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
