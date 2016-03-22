using System.Web.Optimization;

namespace Musher.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script/modernizr").Include(
                        "~/Assets/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/script/app").Include(
                        "~/Assets/Scripts/jquery-{version}.js",
                        "~/Assets/Scripts/bootstrap.js",
                        "~/Assets/Scripts/respond.js",
                        "~/Assets/Scripts/select2.full.min.js",
                        "~/Assets/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/style/app").Include(
                      "~/Assets/Style/bootstrap.min.css",
                      "~/Assets/Style/select2.min.css",
                      "~/Assets/Style/app.css"));
        }
    }
}
