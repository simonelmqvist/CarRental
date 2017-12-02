using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using Umbraco.Core;
using Umbraco.Web;
using Autofac.Integration.WebApi;
using Camelonta.Utilities;
using CarRental.Core.Classes.Abstract;
using CarRental.Core.Classes.Concrete;

namespace CarRental.Core
{
    public class ApplicationEventHandler : IApplicationEventHandler
    {
        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) { }
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) { }
        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Register bundles
            RegisterBundles(BundleTable.Bundles);

            // Dependency Injection
            RegisterIoc();
        }

        private static void RegisterIoc()
        {
            var builder = new ContainerBuilder();

            // Register all controllers found in this assembly
            builder.RegisterInstance(ApplicationContext.Current).AsSelf();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);// Web API

            // Add types to be resolved
            builder.RegisterType<DbRents>().As<IDbRents<RentDbModel>>();

            // Configure Http and Controller Resolvers
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);// web api
            GlobalConfiguration.Configuration.DependencyResolver = resolver; // web api
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        void RegisterBundles(BundleCollection bundles)
        {
            // CSS
            const string cssPath = "~/css/";
            var cssFiles = new List<string>
            {
                "vendor/normalize.css", // Should be before base.css
                "vendor/bootstrap.css",
                "vendor/jquery.auto-complete.css", // Stylesheet for search
                
                "Bundled.css",

                "print.css"
            }.Select(cssFile => cssPath + cssFile).ToArray(); // Add CSS-path

            var styleBundle = bundles.GetBundleFor("~/bundles/styles");

            if (styleBundle == null)
            {
                // Always null initially (if no plugin adds files)
                styleBundle = new StyleBundle("~/bundles/styles").Include(cssFiles);
            }
            else
            {
                // If bundle is initialized in a plugin - it's NOT null (like in this case)
                styleBundle.Include(cssFiles);
            }

            styleBundle.Orderer = Bundles.AsIsBundleOrderer;
            bundles.Add(styleBundle);

            // Scripts
            const string scriptsPath = "~/scripts/";
            var jsFiles = new List<string>
            {
                "vendor/jquery-1.11.2.min.js",
                "vendor/modernizr.js",
                "vendor/js-cookie.2.0.js",
                "vendor/jquery.highlight.js", // Script for search
                "vendor/jquery.auto-complete.js", // Script for search
                

                "main.js",
                "nav.js",
                "helper.js",
                "video.js",
                "cookie-warning.js",
                "faq.js",
                "data-uniform-image-height.js"

            }.Select(jsFile => scriptsPath + jsFile).ToArray(); // Add scripts-path;
            var scriptBundle = new ScriptBundle("~/bundles/scripts").Include(jsFiles);
            scriptBundle.Orderer = Bundles.AsIsBundleOrderer;
            bundles.Add(scriptBundle);

            var ltIe9Files = new List<string>
            {
                 "vendor/ltie9/html5shiv.js",
                 "vendor/ltie9/respond.min.js" //Polyfill for media-queries. Needed for the bootstrap grid to function correctly.
            }.Select(jsFile => scriptsPath + jsFile).ToArray();
            bundles.Add(new ScriptBundle("~/bundles/ltIe9Scripts").Include(ltIe9Files));
        }
    }
}