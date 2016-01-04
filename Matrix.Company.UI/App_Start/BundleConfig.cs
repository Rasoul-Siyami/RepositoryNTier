using System.Web;
using System.Web.Optimization;
using Matrix.Company.Controllers;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer;

namespace Matrix.Company.UI.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            //**************************Admin Js***************************
            bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
                "~/Content/Admin/template.css",
                "~/Content/Admin/metrostyle.css"));

            bundles.Add(new ScriptBundle("~/bundles/Admin").IncludeDirectory(
                       "~/Scripts/Admin", "M*"));
            //*********************Redactor********************************
            bundles.Add(new ScriptBundle("~/bundles/redactor").IncludeDirectory(
                      "~/Scripts/redactor", "r*"));
            bundles.Add(new ScriptBundle("~/bundles/redactor/langs").IncludeDirectory(
                      "~/Scripts/redactor/langs", "fa.js"));
            bundles.Add(new StyleBundle("~/Content/redactor/css").Include(
                "~/Content/Froala/redactor.css"));
            //***************************************************************
            bundles.Add(new ScriptBundle("~/bundles/common").IncludeDirectory(
                       "~/Scripts/common", "Matrix.js"));
            //*****************************************************************
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //            "~/Scripts/bootstrapjs/bootstrap.js",
            //            "~/Scripts/bootstrapjs/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/Scripts/bootstrapjs/bootstrap-rtl.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/bootstrapcss/bootstrap.css",
                        "~/Content/bootstrapcss/bootstrap.min.css",
                        "~/Content/bootstrapcss/bootstrap-theme.css",
                        "~/Content/bootstrapcss/bootstrap-theme.min.css",
                        "~/Content/bootstrapcss/bootstrap-responsive.min.css"));
        }
    }
}