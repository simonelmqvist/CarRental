using System;
using System.Web.Mvc;
using CarRental.Core.Classes;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Classes.Concrete;
using CarRental.Core.ViewModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace CarRental.Core.Controllers
{
    public class ReturnedController : RenderMvcController
    {
        private readonly IDbRents<RentDbModel> _dbRents;
        private readonly IDbReceives<ReceiveDbModel> _dbReceives;

        public ReturnedController(IDbRents<RentDbModel> dbRents, IDbReceives<ReceiveDbModel> dbReceives)
        {
            _dbRents = dbRents;
            _dbReceives = dbReceives;
        }

        public ActionResult Index(int id)
        {
            var crHelper = new CarRentalHelper();
            var rent = (RentDbModel)_dbRents.GetByBookingId(id);
            var receive = (ReceiveDbModel)_dbReceives.GetByBookingId(id);

            var currentSite = CoreHelpers.CurrentSite();
            var baseRent = currentSite.GetPropertyValue<int>("baseRent");
            var baseKmPrice = currentSite.GetPropertyValue<int>("baseKmPrice");
            var price = crHelper.CalculatePrice(rent, receive, baseRent, baseKmPrice);

            var model = new ReturnedViewModel(CurrentPage)
            {
                CurrentPage = CurrentPage,
                Price = Math.Round(price)
            };

            return CurrentTemplate(model);
        }
    }
}