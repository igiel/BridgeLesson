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
                 "~/Content/bootstrap.css"
                 ,"~/Content/Site.css"
                 ));

            bundles.Add(new StyleBundle("~/Content/angularTreeView").Include(
                 "~/Content/angular.treeview.css"));
            BundleTable.EnableOptimizations = false;



            /*THEME ACME BUNDLES*/
            bundles.Add(new ScriptBundle("~/bundles/acmescripts")
                .Include("~/Content/themes/acme/js/common-scripts.js"));
            bundles.Add(new ScriptBundle("~/bundles/acmescripts-index")
                .Include(
                "~/Content/themes/acme/js/hover-dropdown.js",
                "~/Content/themes/acme/js/jquery.flexslider.js",
                "~/Content/themes/acme/assets/bxslider/jquery.bxslider.js",
                "~/Content/themes/acme/js/jquery.parallax-1.1.3.js",
                "~/Content/themes/acme/js/wow.min.js",
                "~/Content/themes/acme/assets/owlcarousel/owl.carousel.js",
                "~/Content/themes/acme/js/jquery.easing.min.js",
                "~/Content/themes/acme/js/link-hover.js",
                "~/Content/themes/acme/js/superfish.js",
                "~/Content/themes/acme/js/parallax-slider/jquery.cslider.js"));
            bundles.Add(new StyleBundle("~/bundles/acmestyles").Include(
                "~/Content/themes/acme/css/theme.css",
               "~/Content/themes/acme/css/bootstrap-reset.css",
               "~/Content/themes/acme/assets/font-awesome/~/Content/themes/acme/css/font-awesome.css",
                "~/Content/themes/acme/css/flexslider.css",
               "~/Content/themes/acme/assets/bxslider/jquery.bxslider.css",
                "~/Content/themes/acme/css/animate.css",
                "~/Content/themes/acme/assets/owlcarousel/owl.carousel.css",
                "~/Content/themes/acme/assets/owlcarousel/owl.theme.css",
               "~/Content/themes/acme/css/superfish.css",
               "~/Content/themes/acme/css/component.css",
               "~/Content/themes/acme/css/style.css",
               "~/Content/themes/acme/css/style-responsive.css",
               "~/Content/themes/acme/css/parallax-slider/parallax-slider.css"
                ));
        }
    }
}
