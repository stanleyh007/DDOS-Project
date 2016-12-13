using System.Web;
using System.Web.Optimization;

namespace DeveloperDOtnetStoreProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /*
         * //General
         * Bundling and Minification minimize static script or css files loading time therby minimize page loading time.
           MVC framework provides ScriptBundle, StyleBundle and DynamicFolderBundle classes.
           Create script or css bundles in the BundleConfig class included in App_Start folder.
           Use wildcard {version} to render available version files at runtime.

           //StyleBundle
           StyleBundle does minification of CSS files.
           Use Styles.Render("bundle name") method to include style bundles in a razor view.

           //ScriptBundle
           ScriptBundle does minification of JavaScript files.
           Use Scripts.Render("bundle name") method to include script bundle in a razor view.
         */

        //Bundling is a new feature in ASP.NET 4.5 that makes it easy to combine or bundle multiple files into a single file. 
        //You can create CSS, JavaScript and other bundles. Fewer files means fewer HTTP requests and that can improve first page load  performance.

        public static void RegisterBundles(BundleCollection bundles)
        {
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
                      "~/Content/site.css"));
        }
    }
}
