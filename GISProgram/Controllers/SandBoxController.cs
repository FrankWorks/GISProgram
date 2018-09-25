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
    public class SandBoxController : Controller
    {
        private ISDGIS db = new ISDGIS();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Programs_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Program> programs = db.Programs;
            DataSourceResult result = programs.ToDataSourceResult(request, program => new {
                programID = program.programID,
                name = program.name,
                type = program.type,
                description = program.description,
                minAge = program.minAge,
                maxAge = program.maxAge,
                displayAge = program.displayAge,
                feeStructure = program.feeStructure,
                registrationRequired = program.registrationRequired,
                registrationFee = program.registrationFee,
                frequencyType = program.frequencyType,
                frequency = program.frequency,
                specialCriteria = program.specialCriteria,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Create([DataSourceRequest]DataSourceRequest request, Program program)
        {
            if (ModelState.IsValid)
            {
                var entity = new Program
                {
                    name = program.name,
                    type = program.type,
                    description = program.description,
                    minAge = program.minAge,
                    maxAge = program.maxAge,
                    displayAge = program.displayAge,
                    feeStructure = program.feeStructure,
                    registrationRequired = program.registrationRequired,
                    registrationFee = program.registrationFee,
                    frequencyType = program.frequencyType,
                    frequency = program.frequency,
                    specialCriteria = program.specialCriteria,
                    locationID = program.locationID
                };

                db.Programs.Add(entity);
                db.SaveChanges();
                program.programID = entity.programID;
            }

            return Json(new[] { program }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Update([DataSourceRequest]DataSourceRequest request, Program program)
        {
            if (ModelState.IsValid)
            {
                var entity = new Program
                {
                    programID = program.programID,
                    name = program.name,
                    type = program.type,
                    description = program.description,
                    minAge = program.minAge,
                    maxAge = program.maxAge,
                    displayAge = program.displayAge,
                    feeStructure = program.feeStructure,
                    registrationRequired = program.registrationRequired,
                    registrationFee = program.registrationFee,
                    frequencyType = program.frequencyType,
                    frequency = program.frequency,
                    specialCriteria = program.specialCriteria,
                };

                db.Programs.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { program }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Destroy([DataSourceRequest]DataSourceRequest request, Program program)
        {
            if (ModelState.IsValid)
            {
                var entity = new Program
                {
                    programID = program.programID,
                    name = program.name,
                    type = program.type,
                    description = program.description,
                    minAge = program.minAge,
                    maxAge = program.maxAge,
                    displayAge = program.displayAge,
                    feeStructure = program.feeStructure,
                    registrationRequired = program.registrationRequired,
                    registrationFee = program.registrationFee,
                    frequencyType = program.frequencyType,
                    frequency = program.frequency,
                    specialCriteria = program.specialCriteria,
                };

                db.Programs.Attach(entity);
                db.Programs.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { program }.ToDataSourceResult(request, ModelState));
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
