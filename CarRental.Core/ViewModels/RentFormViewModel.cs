using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using CarRental.Core.Classes.Concrete;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace CarRental.Core.ViewModels
{
    public class RentFormViewModel : RenderModel
    {
        public RentFormViewModel(IPublishedContent content, CultureInfo culture) : base(content, culture) { }

        public RentFormViewModel(IPublishedContent content) : base(content) { }

        public RentForm RentForm { get; set; }

        public IPublishedContent CurrentPage { get; set; }

        public List<SelectListItem> AllCarCategories { get; set; }
    }
}