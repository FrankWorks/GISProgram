﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using GISProgram.Models;

namespace GISProgram.Controllers
{
    public class LocationController : Controller
    {
        private ISDGIS db = new ISDGIS();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LocationCategories1_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<LocationCategory1> locationcategories1 = db.LocationCategories1;
            DataSourceResult result = locationcategories1.ToDataSourceResult(request, c => new LocationViewModel 
            {
                name = c.name,
                programID = c.programID,
                programName = c.programName,
                type = c.type,
                programDescription = c.programDescription,
                displayAge = c.displayAge,
                feeStructure = c.feeStructure,
                registrationRequired = c.registrationRequired,
                registrationFee = c.registrationFee,
                frequencyType = c.frequencyType,
                frequency = c.frequency,
                specialCriteria = c.specialCriteria,
                programCategoryName = c.programCategoryName
            });

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationCategories1_Update([DataSourceRequest]DataSourceRequest request, LocationViewModel locationCategory1)
        {
            if (ModelState.IsValid)
            {
                var entity = new LocationCategory1
                {
                    //locationID = locationCategory1.locationID,
                    name = locationCategory1.name,
                    programID = locationCategory1.programID,
                    programName = locationCategory1.programName,
                    type = locationCategory1.type,
                    programDescription = locationCategory1.programDescription,
                    displayAge = locationCategory1.displayAge,
                    feeStructure = locationCategory1.feeStructure,
                    registrationRequired = locationCategory1.registrationRequired,
                    registrationFee = locationCategory1.registrationFee,
                    frequencyType = locationCategory1.frequencyType,
                    frequency = locationCategory1.frequency,
                    specialCriteria = locationCategory1.specialCriteria,
                    programCategoryName = locationCategory1.programCategoryName
                };

                db.LocationCategories1.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { locationCategory1 }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
