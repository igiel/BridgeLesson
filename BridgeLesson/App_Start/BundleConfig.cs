using System.Web.Optimization;

namespace BridgeLesson
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //    "~/Scripts/knockout-{version}.js",
            //    "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/angular/angular.min.js",
                "~/Scripts/angular/angular-sanitize.min.js",
                "~/Scripts/app/app.js",
                "~/Scripts/app/directives.js",
                "~/Scripts/app/filters.js",
                "~/Scripts/sammy-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .IncludeDirectory("~/Scripts/controllers", "*.js", true)
                .IncludeDirectory("~/Scripts/services", "*.js", true)
                .IncludeDirectory("~/Scripts/templates", "*.html", true)
                );

            bundles.Add(new ScriptBundle("~/bundles/angularTreeView").Include(
                "~/Scripts/angular/angular.treeview.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/angularTreeView").Include(
                 "~/Content/angular.treeview.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}
