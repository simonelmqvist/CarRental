﻿using System.Collections.Generic;
using System.Linq;
using Examine;
using Umbraco.Core;

namespace CarRental.Core
{
    public class ExamineEventsEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var provider = ExamineManager.Instance.IndexProviderCollection["ExternalIndexer"];
            if (provider != null)
            {
                provider.NodeIndexing += NodeIndexing;
            }
        }

        private void NodeIndexing(object sender, IndexingNodeEventArgs e)
        {
            // Don't index pages where "robotIndex" is set to TRUE
            e.Cancel = DisallowSearchEngineIndexing(e.Fields);
        }


        private static bool DisallowSearchEngineIndexing(IDictionary<string, string> fields)
        {
            var field = fields.SingleOrDefault(f => f.Key == "robotsIndex");
            return field.Equals(default(KeyValuePair<string, string>)) || field.Value == "1"; // 1 = true, 0 = false
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) { }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) { }
    }
}