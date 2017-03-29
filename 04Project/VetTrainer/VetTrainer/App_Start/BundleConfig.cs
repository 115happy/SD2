using System.Web;
using System.Web.Optimization;

namespace VetTrainer
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/dist/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/dist/js/vue.min.js",
                        "~/dist/js/axios.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/dist/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/dist/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/msgboxfeedback").Include(
                        "~/Src/js/feedback-message-box.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/dist/css/bootstrap.css",
                      "~/dist/css/common.css",
                      "~/dist/css/validation.css"));

            // 启用bundle使得js css传的速度更快，并自动变成min的格式
            BundleTable.EnableOptimizations = true;
        }
    }
}
