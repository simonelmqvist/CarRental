using System;
using System.Linq;
using System.Web.Mvc;
using CarRental.Core.Classes;
using CarRental.Core.Classes.Concrete;
using umbraco;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace CarRental.Core.Controllers
{
    public class RentSurfaceController : SurfaceController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RentForm model)
        {
            if (ModelState.IsValid)
            {
                 
            }

            ViewBag.Message = "Något fel har uppstått. Kontakta support";
            return CurrentUmbracoPage();
        }
    }
}
