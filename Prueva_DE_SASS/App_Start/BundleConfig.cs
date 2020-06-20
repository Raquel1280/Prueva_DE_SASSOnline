using System.Web;
using System.Web.Optimization;

namespace Prueva_DE_SASS
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                             "~/Scripts/jquery.nivo.slider.js",/*se añadio para el slauders*/
                            "~/Scripts/jquery-3.3.1.min.js", /*se añadio para el slauders*/
                            "~/Scripts/Js_Menu/jquery-3.5.min.js",/*se añadio para el Menu*/
                            "~/Scripts/Js_Menu/main.js",/*se añadio para el Menu*/
                            "~/Scripts/Js_Menu/skel.min.js",/*se añadio para el Menu*/
                            "~/Scripts/Js_Menu/util.js",/*se añadio para el Menu*/
                            "~/Scripts/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(

                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/Mis_Estilos.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
