using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueva_DE_SASS.Models;
using Prueva_DE_SASS.Clase;
using System.Data.Entity;

namespace Prueva_DE_SASS.Controllers
{
    public class MantenimientoController : Controller
    {

        // GET: Mantenimiento
        public ActionResult MantenerMuestra()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {


                    var sentencia = from P in conexion.Peliculas
                                    join G in conexion.GeneroPelicula on P.Cod_Genero equals G.Cod_Genero
                                    join I in conexion.Idioma on P.Cod_Idioma equals I.Cod_Idioma orderby P.Cod_Pelicula descending

                                    select new ClsParcialPelicula
                                    {
                                        Cod_Pelicula = P.Cod_Pelicula,
                                        Nombre = P.Nombre,
                                        Actores = P.Actores,
                                        Director = P.Director,
                                        Descripcion = P.Descripcion,
                                        Duracion = P.Duracion,
                                        Precio = P.Precio,
                                        Fecha_Estreno = P.Fecha_Estreno,
                                        Portada = P.Portada,
                                        NombreGeneropelicula = G.Genero,
                                        NombreIdiomapelicula = I.Idioma1

                                    };

                    return View(sentencia.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        /*****************************************METODOS para ingresar*********************************************************************/
        [HttpGet]
        public ActionResult Ingresar()
        {
            ViewBag.Message = ("Estas por ingresar las imagenes");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ingresar(ClsParcialPelicula objeto)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    if (!ModelState.IsValid)
                    {
                        
                        var picture = string.Empty;
                        var folder = "~/Content/images/Peliculas";

                        if (objeto.imagefile != null)
                        {
                
                            picture = FileHelpers.UploadPhoto(objeto.imagefile, folder);

                            picture = string.Format("{0}/{1}", folder, picture);

                        }

                        var variable = MetodoPelicula(objeto);

                        variable.Portada = picture;

                        conexion.Peliculas.Add(variable);

                        conexion.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    return View(objeto);
                }


            }
            catch (Exception er)
            {

                ModelState.AddModelError("", "Error al almacenar" + er);
                return View();
            }

        }

        private Peliculas MetodoPelicula(ClsParcialPelicula objeto)
        {
            return new Peliculas
            {
                Cod_Pelicula = objeto.Cod_Pelicula,
                Nombre = objeto.Nombre,
                Actores = objeto.Actores,
                Director = objeto.Director,
                Descripcion = objeto.Descripcion,
                Duracion = objeto.Duracion,
                Precio = objeto.Precio,
                Fecha_Estreno = objeto.Fecha_Estreno,
                Portada = objeto.Portada,
                Cod_Genero = objeto.Cod_Genero,

                Cod_Idioma = objeto.Cod_Idioma



            };
        }
  
        [HttpGet]
        //aqui este recibira un parametro que es el Cod_Pelicula
        public ActionResult Editar(int Cod_Pelicula)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {

                try
                {
                    var objpelicula = conexion.Peliculas.Find(Cod_Pelicula);


                    return View(miotrometodo(objpelicula));

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                    return View();
                }
            }

        }

        private ClsParcialPelicula miotrometodo(Peliculas objpelicula)
        {
            return new ClsParcialPelicula
            {

                Cod_Pelicula = objpelicula.Cod_Pelicula,
                Nombre = objpelicula.Nombre,
                Actores = objpelicula.Actores,
                Director = objpelicula.Director,
                Descripcion = objpelicula.Descripcion,
                Duracion = objpelicula.Duracion,
                Precio = objpelicula.Precio,
                Fecha_Estreno = objpelicula.Fecha_Estreno,
                Portada = objpelicula.Portada,
                Cod_Genero = objpelicula.Cod_Genero,
                Cod_Idioma = objpelicula.Cod_Idioma


            };
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(ClsParcialPelicula objpelicula)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    //aqui siempre validamos que siempre el formulaio no tenga campos vacios 
                    if (ModelState.IsValid)
                    {

                        //en este caso inicialisamos la la variable picture no como vacia sino con lo que trae (la imagen que se le ingreso) ya que se esta editando
                        //por logica trae una imagen y sie el usuario no cambia la imagen pues siempre la tendra 
                        var picture = objpelicula.Portada;
                        var folder = "~/Content/images/Peliculas";

                        //aqui en el if validamos que el usuario no  cambio la foto pues siempre la tendra la q tenia anteriormente(el upload esta bacio)
                        if (objpelicula.imagefile != null)
                        {
                            // pero si la cambio me subira la foto
                            picture = FileHelpers.UploadPhoto(objpelicula.imagefile, folder);

                            //y aqui en este ultimo picture me debuelve el nombre de la imagen y con su extencion y ete nombre me lo concatena con 
                            //el nombre de la carpeta Content mas el nombre de la carpeta en donde estara la imagen subida
                            picture = string.Format("{0}/{1}", folder, picture);

                        }



                        var mivariable = MetodoPelicula(objpelicula);

                        //ya que todo estaben mi variable  le asigno lo que tiene el  MetodoPelicula 
                        mivariable.Portada = picture;

                        //pues aqui realisamos el cambio dela imagen biej ala imagen nueva  
                        conexion.Entry(mivariable).State = EntityState.Modified;
                        //aqui guardamos todo en la base de datos 
                        conexion.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(objpelicula);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                return View();
            }


        }
        /**********************************************************************************************************************************/



        /**********************************************METODO PARA Observar los detalles************************************************************************************/

        public ActionResult Detalles(int Cod_Pelicula)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    var objpelicula = conexion.Peliculas.Find(Cod_Pelicula);

                    if (objpelicula == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View(objpelicula);

                    }

                }


            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Error al solicitar detalles");
                return View();
            }

        }
        /**********************************************************************************************************************************/

        /***************************************** Metodo para Eliminar los registros ****************************************************************/


        public ActionResult Eliminar(int Cod_Pelicula)
        {
            try
            {
                using (var objconexion = new Servicio_OnlineEntities())
                {
                    var obj = objconexion.Peliculas.Find(Cod_Pelicula);
                    objconexion.Peliculas.Remove(obj);
                    objconexion.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "No se realizo la eliminacion del archivo");
                return View();
            }

        }
        /**********************************************************************************************************************************/


        //*********************************este codigoservira para un buscador por primer letra del nombre*********************************

        public ActionResult Index(string searching)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {
                return View(conexion.Peliculas.Where(a => a.Nombre.Contains(searching) || searching == null).ToList());


                //en este con starswidhtle indicamos q nos muestre por el primer letra q
                //    ingresamos si ingresamos batman me mostrara solo os q empiesen  con b en cambio
                //con el .Contains nos mostraria todos los que poseen b
                //return View(conexion.Peliculas.Where(a => a.Nombre.StartsWith(searching) || searching == null).ToList());

            }

    }



        /**********************************************************************************************************************************/


    }

}


