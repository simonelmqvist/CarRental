using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace CarRental.Core.ViewModels
{
    public class ReturnedViewModel : RenderModel
    {
        public ReturnedViewModel(IPublishedContent content, CultureInfo culture) : base(content, culture) { }

        public ReturnedViewModel(IPublishedContent content) : base(content) { }

        public IPublishedContent CurrentPage { get; set; }

        public double Price { get; set; }
    }
}