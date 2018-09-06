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
    public class GridController : Controller
    {
        private ISDGIS db = new ISDGIS();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LocationCategories1_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<LocationCategory1> locationcategories1 = db.LocationCategories1;
            DataSourceResult result = locationcategories1.ToDataSourceResult(request, locationCategory1 => new {
                //locationID = locationCategory1.locationID,
                //name = locationCategory1.name,
                //description = locationCategory1.description,
                //address1 = locationCategory1.address1,
                //address2 = locationCategory1.address2,
                //city = locationCategory1.city,
                //state = locationCategory1.state,
                //zip = locationCategory1.zip,
                //hours = locationCategory1.hours,
                //phones = locationCategory1.phones,
                //url = locationCategory1.url,
                //image_url = locationCategory1.image_url,
                //email = locationCategory1.email,
                //organization = locationCategory1.organization,
                //latitude = locationCategory1.latitude,
                //longitude = locationCategory1.longitude,
                //lms_post_id = locationCategory1.lms_post_id,
                //lastUpdated = locationCategory1.lastUpdated,
                //operatedByLabel = locationCategory1.operatedByLabel,
                //source = locationCategory1.source,
                //sourceID = locationCategory1.sourceID,
                //nameUrlFriendly = locationCategory1.nameUrlFriendly,
                //programCategory = locationCategory1.programCategory,
                programID = locationCategory1.programID,
                programName = locationCategory1.programName,
                type = locationCategory1.type,
                programDescription = locationCategory1.programDescription,
                minAge = locationCategory1.minAge,
                maxAge = locationCategory1.maxAge,
                displayAge = locationCategory1.displayAge,
                feeStructure = locationCategory1.feeStructure,
                registrationRequired = locationCategory1.registrationRequired,
                registrationFee = locationCategory1.registrationFee,
                frequencyType = locationCategory1.frequencyType,
                frequency = locationCategory1.frequency,
                specialCriteria = locationCategory1.specialCriteria,
                programCategoryName = locationCategory1.programCategoryName
            });

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LocationCategories1_Update([DataSourceRequest]DataSourceRequest request, LocationCategory1 locationCategory1)
        {
            if (ModelState.IsValid)
            {
                var entity = new LocationCategory1
                {
                    locationID = locationCategory1.locationID,
                    name = locationCategory1.name,
                    description = locationCategory1.description,
                    address1 = locationCategory1.address1,
                    address2 = locationCategory1.address2,
                    city = locationCategory1.city,
                    state = locationCategory1.state,
                    zip = locationCategory1.zip,
                    hours = locationCategory1.hours,
                    phones = locationCategory1.phones,
                    url = locationCategory1.url,
                    image_url = locationCategory1.image_url,
                    email = locationCategory1.email,
                    organization = locationCategory1.organization,
                    latitude = locationCategory1.latitude,
                    longitude = locationCategory1.longitude,
                    lms_post_id = locationCategory1.lms_post_id,
                    lastUpdated = locationCategory1.lastUpdated,
                    operatedByLabel = locationCategory1.operatedByLabel,
                    source = locationCategory1.source,
                    sourceID = locationCategory1.sourceID,
                    nameUrlFriendly = locationCategory1.nameUrlFriendly,
                    programCategory = locationCategory1.programCategory,
                    programID = locationCategory1.programID,
                    programName = locationCategory1.programName,
                    type = locationCategory1.type,
                    programDescription = locationCategory1.programDescription,
                    minAge = locationCategory1.minAge,
                    maxAge = locationCategory1.maxAge,
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
