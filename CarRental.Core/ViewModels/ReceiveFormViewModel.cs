using System.Globalization;
using CarRental.Core.Classes.Concrete;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace CarRental.Core.ViewModels
{
    public class ReceiveFormViewModel : RenderModel
    {
        public ReceiveFormViewModel(IPublishedContent content, CultureInfo culture) : base(content, culture) { }

        public ReceiveFormViewModel(IPublishedContent content) : base(content) { }

        public ReceiveDbModel ReceiveForm { get; set; }

        public IPublishedContent CurrentPage { get; set; }
    }
}