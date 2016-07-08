using System.Web.Optimization;

namespace DriveMe.GUI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  
                      "~/Content/bootstrap.css",
                      "~/Content/ui-bootstrap.css",
                      "~/Content/site.css"));

          bundles.Add(new StyleBundle("~/Content/material").Include(

                              "~/Content/angular-material.layouts.min.css",
                              "~/Content/angular-material.min.css",
                              "~/Content/materialicons.css",
                              "~/Content/material-datetimepicker.min.css"));
            
          bundles.Add(new ScriptBundle("~/scripts/angular").Include(
                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-route.min.js",
                    "~/Scripts/angular-ui/ui-bootstrap.min.js",
                    "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                    "~/Scripts/angular-animate.min.js",
                    "~/Scripts/angular/services/services.module.js"
                ));
            bundles.Add(new ScriptBundle("~/scripts/angular/routes").Include(
                    
                    "~/Scripts/angular/services/direction.service.js",
                    "~/Scripts/angular/services/address.service.js",
                    "~/Scripts/angular/services/maps.service.js",

                    "~/Scripts/angular/modules/route/route.module.js",
                    "~/Scripts/angular/modules/route/route.controller.js",
                    "~/Scripts/angular/modules/route/datepicker.controller.js",
                    "~/Scripts/angular/modules/route/route.directive.js"

                ));
            bundles.Add(new ScriptBundle("~/scripts/datetimepicker").Include(
                    "~/Scripts/custom/datetimepicker.js"
                ));
            bundles.Add(new ScriptBundle("~/scripts/angular/register").Include(
                     "~/Scripts/angular/modules/register/register.module.js",
                    "~/Scripts/angular/modules/register/register.controller.js"
                ));
            bundles.Add(new ScriptBundle("~/scripts/angular/register").Include(
                    "~/Scripts/angular/modules/register/register.module.js",
                   "~/Scripts/angular/modules/register/register.controller.js"
               ));

            bundles.Add(new ScriptBundle("~/scripts/angular/material").Include(
                    "~/Scripts/angular-aria/angular-aria.min.js",
                    "~/Scripts/moment.min.js",
                   "~/Scripts/angular-material/angular-material.min.js",
                   "~/Scripts/angular-material-datetimepicker.js"
               ));
        }
    }
}
