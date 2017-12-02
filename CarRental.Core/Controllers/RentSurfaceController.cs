using System;
using System.Linq;
using System.Web.Mvc;
using CarRental.Core.Classes;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Classes.Concrete;
using CarRental.Core.Models;
using CarRental.Core.ViewModels;
using umbraco;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using DateTime = System.DateTime;

namespace CarRental.Core.Controllers
{
    public class RentSurfaceController : SurfaceController
    {
        private readonly IDbRents<RentDbModel> _db;

        public RentSurfaceController(IDbRents<RentDbModel> db) { _db = db; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ReportFormUpload model)
        {
            if (ModelState.IsValid)
            {
                model.RentForm.Date = DateTime.Now;
                _db.Insert(model.RentForm);
                ViewBag.Message = "Bokning klar";
            }

            else
            {
                ViewBag.Message = "Något fel har uppstått. Kontakta support";
            }

            return CurrentUmbracoPage();
        }
    }
}
