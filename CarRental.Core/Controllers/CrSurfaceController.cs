using System.Linq;
using System.Web.Mvc;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Classes.Concrete;
using CarRental.Core.Models;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;
using DateTime = System.DateTime;

namespace CarRental.Core.Controllers
{
    public class CrSurfaceController : SurfaceController
    {
        private readonly IDbRents<RentDbModel> _dbRents;
        private readonly IDbReceives<ReceiveDbModel> _dbReceives;

        public CrSurfaceController(IDbRents<RentDbModel> dbRents, IDbReceives<ReceiveDbModel> dbReceives)
        {
            _dbRents = dbRents;
            _dbReceives = dbReceives;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRentForm(ReportFormUpload model)
        {
            if (ModelState.IsValid)
            {
                model.RentForm.Date = DateTime.Now;
                _dbRents.Insert(model.RentForm);

                var thankYouPage = CurrentPage.Children.FirstOrDefault();
                if (thankYouPage != null)
                    return Redirect(thankYouPage.Url);
            }

            else
            {
                string message;
                if (model != null && model.RentForm != null)
                    message = string.Format("Could not rent {0}", model.RentForm.RegistrationNumber);

                else
                    message = "Could not rent car";

                LogHelper.Warn<CrSurfaceController>(message);
            }

            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitReceiveForm(ReceiveFormUpload model)
        {
            if (ModelState.IsValid)
            {
                _dbReceives.Insert(model.ReceiveForm);

                var thankYouPage = CurrentPage.Children.FirstOrDefault();
                if (thankYouPage != null)
                {
                    var url = string.Format("{0}?id={1}", thankYouPage.Url, model.ReceiveForm.BookingId);
                    return Redirect(url);
                }
            }

            else
            {
                var message = "Could not receive car";
                LogHelper.Warn<CrSurfaceController>(message);
            }

            return new EmptyResult();
        }
    }
}