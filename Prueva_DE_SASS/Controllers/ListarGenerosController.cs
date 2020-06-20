using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Prueva_DE_SASS.Controllers
{
    public class ListarGenerosController : Controller
    {
        // GET: Prueva01
        /*****************************Es para mostrar los generos de las peliculas  desde nuestra base de datos ***************************/

        public ActionResult ListarGeneroPelicula()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    return PartialView(conexion.GeneroPelicula.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }


        /*******************************************************/

        /*****************************Es para mostrar los idiomas de las peliculas  desde nuestra base de datos ***************************/

        public ActionResult listarIdiomaspeliculas()
        {
            try
            {
                using (var conexion=new Servicio_OnlineEntities())
                {
                    return PartialView(conexion.Idioma.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        /********************************************** **************************************************************/


        public ActionResult ListarGeneroVideo_Musica()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    return PartialView(conexion.Genero_Vid_Music.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        /********************************************************************************/




        public ActionResult ListarFormadeopago()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    return PartialView(conexion.Forma_D_Pago.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }


        }



    }
}