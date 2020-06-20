using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueva_DE_SASS.Models;

namespace Prueva_DE_SASS.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string pass)
        {

            try
            {

                using (var conexion = new Servicio_OnlineEntities())
                {
                    var sentencia = (from usuari in conexion.Usuarios
                                     where usuari.Correo == User.Trim() &&
                                     usuari.Contrasena == pass.Trim()
                                     select usuari).FirstOrDefault();

                    if (sentencia == null)
                    {
                        ViewBag.Message = "Usuario O contraseña invalida";
                        return View();
                    }

                    Session["User"] = sentencia;

                    Session["username"] = sentencia.Correo.ToString();
                    //Session["gender"] = sentencia.gender.ToString();


                }
                return RedirectToAction("Index", "Home");


            }
            catch (Exception)
            {

                ViewBag.Message = "No puedes ingresar ";
                return View();
            }
        }

        public ActionResult cerrarsesion()
        {
            Session["username"] = null;
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Nuevorgistro()
        {



            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Nuevorgistro(Usuarios objeto)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                //este using prectica_mvc etc abre la conexion de la base de datos y despues la cierra al mismo tiempo
                using (var dbobjeto = new Servicio_OnlineEntities())
                {
                    objeto.Cod_Rol =1;

                    //empesamos a agregar datos ala tabla Alumno de nuestra base de datos
                    dbobjeto.Usuarios.Add(objeto);
                    dbobjeto.SaveChanges();
                    return RedirectToAction("Login","Acceso");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", "Error al agregar el alumno" + error);
                return View();
            }

        }

      
    }
}