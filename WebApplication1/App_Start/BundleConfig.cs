using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryAndJqueryUI").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/nouislider.min.js",
                      "~/Scripts/slick.min.js"));

            bundles.Add(new StyleBundle("~/Content/Template_electro/electro/").Include(
                      "~/Content/Template_electro/electro/bootstrap.css",
                      "~/Content/Template_electro/electro/style.css",
                      "~/Content/Template_electro/electro/slick.css",
                      "~/Content/Template_electro/electro/slick-theme.css",
                      "~/Content/Template_electro/electro/nouislider.min.css",
                      "~/Content/Template_electro/electro/font-awesome.min.css")                      
                      );
        }
    }
}
