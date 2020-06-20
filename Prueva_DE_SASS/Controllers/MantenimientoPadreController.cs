using Prueva_DE_SASS.filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class MantenimientoPadreController : Controller
    {
        // GET: MantenimientoPadre

        [FiltroPorRoles(Cod_Operaciones: 2)]
        public ActionResult M_Peliculas()
        {
            return View();
        }
    }
}