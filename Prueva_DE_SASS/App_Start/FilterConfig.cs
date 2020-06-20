using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new filters.VerificarSesion());

        }
    }
}
