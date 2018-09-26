using System;
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
using Infrastucture.VO;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;


namespace GISProgram.Controllers
{
    [Authorize]
    public class Grid1Controller : Controller
    {
        private ISDGIS db = new ISDGIS();
        //EmployeeVO employee = new EmployeeVO();
        //StaticProcessVO processVO = new StaticProcessVO();
        
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Programs_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Program> programs = db.Programs;
            DataSourceResult result = programs.ToDataSourceResult(request, program => new programViewModel
            {
                programID = program.programID,
                locationID = program.locationID,
                parkName = db.Locations.Where(s => s.locationID == program.locationID).Select(s => s.name).First(),
                name = program.name,
                type = program.type,
                description = program.description,
                //minAge = program.minAge,
                //maxAge = program.maxAge,
                displayAge = program.displayAge,
                feeStructure = program.feeStructure,
                registrationRequired = program.registrationRequired,
                registrationFee = program.registrationFee,
                frequencyType = program.frequencyType,
                frequency = program.frequency,
                specialCriteria = program.specialCriteria,
                programCategoryName = program.programCategoryID.ToString(),
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Create([DataSourceRequest]DataSourceRequest request, programViewModel program)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var entity = new Program
                {
                    locationID = long.Parse(program.parkName),
                    programCategoryID = int.Parse(program.programCategoryName),
                    name = program.name,
                    type = program.type,
                    description = program.description,
                    //minAge = program.minAge,
                    //maxAge = program.maxAge,
                    displayAge = program.displayAge,
                    feeStructure = program.feeStructure,
                    registrationRequired = false,
                    registrationFee = program.registrationFee,
                    frequencyType = program.frequencyType,
                    frequency = program.frequency,
                    specialCriteria = program.specialCriteria,
                };

                db.Programs.Add(entity);
                try
                {
                    db.SaveChanges();

                }
                catch (Exception ee)
                {

                    string mes = ee.InnerException.Message;
                    Exception d = new Exception();
                    object f = ee.InnerException.Data;
                    f = ee.InnerException.HelpLink;
                    f = ee.InnerException.HResult;
                    f = ee.InnerException.Source;
                    f = ee.HelpLink;
                    f = ee.HResult;
                    f = ee.Source;
                    f = ee.Data;
                    string tem = ee.StackTrace;
                    StaticProcessVO processVO = new StaticProcessVO(tem.ToString());
                }

                program.programID = entity.programID;
                var parkName = db.Locations.Where(s => s.locationID == entity.locationID).Select(s => s.name).First();
                StaticProcessVO procesVO = new StaticProcessVO("Program ID: " + entity.programID.ToString() + " : Program Name: " + entity.name.ToString() + " for " + parkName.ToString() + " Added by " +userId );

            }

            return Json(new[] { program }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Update([DataSourceRequest]DataSourceRequest request, programViewModel program)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var entity = new Program
                {
                    programID = (int)program.programID,
                    locationID = program.locationID,
                    name = program.name,
                    type = program.type,
                    description = program.description,
                    //minAge = program.minAge,
                    //maxAge = program.maxAge,
                    displayAge = program.displayAge,
                    feeStructure = program.feeStructure,
                    registrationRequired = (bool)program.registrationRequired,
                    registrationFee = program.registrationFee,
                    frequencyType = program.frequencyType,
                    frequency = program.frequency,
                    specialCriteria = program.specialCriteria,
                };

                db.Programs.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (Exception ee)
                    {

                        string mes = ee.InnerException.Message;
                        Exception d = new Exception();
                        object f = ee.InnerException.Data;
                        f = ee.InnerException.HelpLink;
                        f = ee.InnerException.HResult;
                        f = ee.InnerException.Source;
                        f = ee.HelpLink;
                        f = ee.HResult;
                        f = ee.Source;
                        f = ee.Data;
                        string tem = ee.StackTrace;
                        StaticProcessVO processVO = new StaticProcessVO(tem.ToString());
                    }


                    var parkName = db.Locations.Where(s => s.locationID == entity.locationID).Select(s => s.name).First();
                    StaticProcessVO procesVO = new StaticProcessVO("Program ID: " + entity.programID.ToString() + " : Program Name: " + entity.name.ToString() + " for " + parkName.ToString() + " Updated by " + userId);
            }

            return Json(new[] { program }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Programs_Destroy([DataSourceRequest]DataSourceRequest request, Program program)
        {
            string userId = User.Identity.Name;
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
                    locationID = program.locationID
                };

                db.Programs.Attach(entity);
                db.Programs.Remove(entity);

                    try
                    {
                        db.SaveChanges();

                    }
                    catch (Exception ee)
                    {

                        string mes = ee.InnerException.Message;
                        Exception d = new Exception();
                        object f = ee.InnerException.Data;
                        f = ee.InnerException.HelpLink;
                        f = ee.InnerException.HResult;
                        f = ee.InnerException.Source;
                        f = ee.HelpLink;
                        f = ee.HResult;
                        f = ee.Source;
                        f = ee.Data;
                        string tem = ee.StackTrace;
                        StaticProcessVO processVO = new StaticProcessVO(tem.ToString());
                    }


                    var parkName = db.Locations.Where(s => s.locationID == entity.locationID).Select(s => s.name).First();
                    StaticProcessVO procesVO = new StaticProcessVO("Program ID: " + entity.programID.ToString() + " : Program Name: " + entity.name.ToString() + " for " + parkName.ToString() + " Deleted by " + userId);

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
