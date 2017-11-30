using System.Linq;
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

            var formPage = CoreHelpers.CurrentSite().Children.FirstOrDefault(x => x.DocumentTypeAlias == "rent");
            if (formPage == null)
                return CurrentTemplate(model);

            model.AllCarCategories = CoreHelpers.TextareaToSelectListItems(formPage.GetPropertyValue<string>("carCategories"));

            return CurrentTemplate(model);
        }
    }
}