#define DEBUGMODE

using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string[] css = new string[] {
                "~/Content/style.css",
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/bootstrap/bootstrap-theme.css",
                "~/Content/bootstrap/ui-bootstrap-csp.css",
                "~/Content/font-awesome.css",
            };

            string[] js = new string[] {
                "~/Scripts/jquery-3.1.1.min.js",
                "~/Scripts/angular.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-ui-router.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular-translate.js",
                "~/Scripts/angular-route.js",

                "~/app/app.js",
                "~/app/app-route.js",

                //"~/app/controllers/mainController.js",
                "~/app/controllers/globalController.js"//,
                //"~/app/controllers/loginController.js"
            };

            bundles.Add(new StyleBundle("~/css").Include(css));
            bundles.Add(new ScriptBundle("~/js").Include(js));


#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = false;
#endif




            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
            // gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
