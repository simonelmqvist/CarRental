using System.Linq;
using System.Web.Mvc;
using CarRental.Core.Classes;
using CarRental.Core.ViewModels;
using Umbraco.Web.Mvc;

namespace CarRental.Core.Controllers
{
    public class ReceiveController : RenderMvcController
    {
        public ActionResult Index()
        {
            var model = new ReceiveFormViewModel(CurrentPage)
            {
                CurrentPage = CurrentPage
            };

            var formPage = CoreHelpers.CurrentSite().Children.FirstOrDefault(x => x.DocumentTypeAlias == "receive");
            if (formPage == null)
                return CurrentTemplate(model);

            return CurrentTemplate(model);
        }
    }
}