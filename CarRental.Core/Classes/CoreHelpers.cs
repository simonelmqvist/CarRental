using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace CarRental.Core.Classes
{
    public class CoreHelpers
    {
        public static string RenderPartialToString(string viewName, object model, ControllerContext controllerContext)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controllerContext.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary();
            var tempData = new TempDataDictionary();
            viewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public static IPublishedContent CurrentSite()
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            return umbracoHelper.TypedContentAtRoot().FirstOrDefault();
        }

        public static List<SelectListItem> TextareaToSelectListItems(string textArea)
        {
            var listItems = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(textArea))
            {
                textArea = textArea.Replace("\r", "");
                var items = textArea.Split('\n').ToList();
                foreach (var item in items)
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = item,
                        Value = item
                    });
                }
            }

            return listItems;
        }

        public static List<string> TextareaToList(string textArea)
        {
            if (!string.IsNullOrEmpty(textArea))
            {
                textArea = textArea.Replace("\r", "");
                return textArea.Split('\n').ToList();
            }

            return new List<string>();
        }
    }
}