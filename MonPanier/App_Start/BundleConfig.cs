using System.Web;
using System.Web.Optimization;

namespace MonPanier
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/TwitterBootstrapMvcJs.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/MapRegion/css").Include(
                      "~/Content/jqvmap.css"));
            bundles.Add(new StyleBundle("~/MapRegion/jqueryModule").Include(
                      "~/Scripts/jquery.vmap.js",
                      "~/Scripts/jquery.vmap.france.js"
                      ));

            bundles.Add(new StyleBundle("~/Select2/css").Include(
                      "~/Content/select2.css",
                      "~/Content/select2-bootstrap.css"));
            bundles.Add(new StyleBundle("~/Select2/js").Include(
                      "~/Scripts/select2.js",
                      "~/Scripts/select2_locale_fr.js"
                      ));

            // Définissez EnableOptimizations sur False pour le débogage. Pour plus d'informations,
            // visitez http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
