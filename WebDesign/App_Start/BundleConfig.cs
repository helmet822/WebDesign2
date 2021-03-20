using System.Web.Optimization;

namespace WebDesign {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            // ScriptBundle: HTMLヘルパー @Scriptで記載するために必要
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                                "~/Scripts/umd/popper.js",
                                "~/Scripts/umd/tooltip.js"));

            bundles.Add(new ScriptBundle("~/bundles/colorbox").Include(
                                "~/Scripts/jquery.colorbox-min.js",
                                "~/Scripts/jquery.colorbox-ja.js"));

            // StyleBundle: HTMLヘルパー @Stylesで記載するために必要
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/popup.css",
                      "~/Content/common.css"));

            bundles.Add(new StyleBundle("~/Content/colorboxcss").Include(
                      "~/Content/colorbox.css"));
        }
    }
}