using Prueva_DE_SASS.Controllers;
using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.filters
{
    public class VerificarSesion : ActionFilterAttribute
    {

        private Usuarios NuestroUsuario;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {

                base.OnActionExecuting(filterContext);


                NuestroUsuario = (Usuarios)HttpContext.Current.Session["User"];

                if (NuestroUsuario != null)
                    {
                        if (filterContext.Controller is AccesoController ==false)
                        {
                            //filterContext.HttpContext.Response.Redirect("/Acceso/Login");

                        }

                    else if (NuestroUsuario == null)
                    {
                        if (filterContext.Controller is AccesoController == false)
                        {
                            filterContext.HttpContext.Response.Redirect("/Acceso/Login");

                        }
                    }
                }
      

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }





        }
    }
}