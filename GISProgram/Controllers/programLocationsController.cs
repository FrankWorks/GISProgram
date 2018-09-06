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
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace GISProgram.Controllers
{
    public class programLocationsController : Controller
    {
        private ISDGIS db = new ISDGIS();

        // GET: programLocations
        public async Task<ActionResult> Index()
        {
            return View(await db.Locations.ToListAsync());
        }

        // GET: programLocations/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: programLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: programLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "locationID,name,description,address1,address2,city,state,zip,hours,phones,url,image_url,email,organization,latitude,longitude,point,isCounty,lms_post_id,lastUpdated,operatedByLabel,source,sourceID,nameUrlFriendly")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: programLocations/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: programLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "locationID,name,description,address1,address2,city,state,zip,hours,phones,url,image_url,email,organization,latitude,longitude,point,isCounty,lms_post_id,lastUpdated,operatedByLabel,source,sourceID,nameUrlFriendly")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: programLocations/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = await db.Locations.FindAsync(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: programLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Location location = await db.Locations.FindAsync(id);
            db.Locations.Remove(location);
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
        public ActionResult locationPrograms_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Location> programs = db.Locations.Where(d=>d.operatedByLabel == "County Operated Facility").OrderBy(d=>d.name) ;
            DataSourceResult result = programs.ToDataSourceResult(request, program => new programLocationViewModel
            {
                locationID = program.locationID,
                name = program.name
                //locationID = program.locationID,
                //parkName = db.Locations.Where(s => s.locationID == program.locationID).Select(s => s.name).First(),
                
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult locationProgramCategory_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<ProgramCategory> programs = db.ProgramCategories.OrderBy(d => d.programCategory1);
            DataSourceResult result = programs.ToDataSourceResult(request, program => new programLocationViewModel
            {
                locationID = program.programCategoryID,
                name = program.programCategory1
                //locationID = program.locationID,
                //parkName = db.Locations.Where(s => s.locationID == program.locationID).Select(s => s.name).First(),

            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
