using System.Web.Mvc;
using CarRental.Core.Classes;
using CarRental.Core.ViewModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace CarRental.Core.Controllers
{
    public class RentController : RenderMvcController
    {
        public ActionResult Index()
        {
            var model = new RentFormViewModel(CurrentPage)
            {
                CurrentPage = CurrentPage
            };

            var umbCategories = CoreHelpers.CurrentSite().GetPropertyValue<string>("carCategories");
            model.AllCarCategories = CoreHelpers.TextareaToSelectListItems(umbCategories);

            return CurrentTemplate(model);
        }
    }
}