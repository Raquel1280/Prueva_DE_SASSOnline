using Prueva_DE_SASS.Clase;
using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class MantenimientoMusicaController : Controller
    {
        // GET: MantenimientoMusica
        public ActionResult IndexMusica(string searching)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {
                return View(conexion.Musica.Where(a => a.Nombre.Contains(searching) || searching == null).ToList());


                //en este con starswidhtle indicamos q nos muestre por el primer letra q
                //    ingresamos si ingresamos batman me mostrara solo os q empiesen  con b en cambio
                //con el .Contains nos mostraria todos los que poseen b
                //return View(conexion.Peliculas.Where(a => a.Nombre.StartsWith(searching) || searching == null).ToList());

            }





    }

        /*********************************Metodo para ingresar ala base de datos******************************************************/
        [HttpGet]
        public ActionResult Ingresar()
        {
            return View();

        }

      
        [ValidateAntiForgeryToken]//este codigo se encarga que la informcion llegue al formulario correcto
        [HttpPost]
        public ActionResult Ingresar(ClsPartialMusicas objeto)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    if (!ModelState.IsValid)
                    {
                        //inicialisamos una variable picture para q este vacia
                        var picture = string.Empty;
                        var folder = "~/Content/images/Musica";

                        //aqui en el if validamos que el usuario si selecciono una foto en el upload(si hay foto)
                        if (objeto.imagefile != null)
                        {
                            //aqui le desimos ala primera picture que me suba la foto que esta en mi imagefile
                            picture = FileHelpers.UploadPhoto(objeto.imagefile, folder);

                            //y aqui en este ultimo picture me debuelve el nombre de la imagen y con su extencion y ete nombre me lo concatena con 
                            //el nombre de la carpeta Content mas el nombre de la carpeta en donde estara la imagen subida
                            picture = string.Format("{0}/{1}", folder, picture);

                        }

                        var variable = MetodoMusica(objeto);

                        //ya que todo estaben mi variable  le asigno lo que tiene el  MetodoPelicula 
                        variable.Portada = picture;

                        conexion.Musica.Add(variable);
                        //aqui guardamos todo en la base de datos 
                        conexion.SaveChanges();
                        return RedirectToAction("IndexMusica");

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


        //este metodo me convertira la imagen 
        private Musica MetodoMusica(ClsPartialMusicas objeto)
        {
            return new Musica
            {
                Cod_Musica = objeto.Cod_Musica,
                Nombre = objeto.Nombre,
                Artista = objeto.Artista,
                Duracion = objeto.Duracion,
                Fecha_Estreno = objeto.Fecha_Estreno,
                Precio = objeto.Precio,
                Portada = objeto.Portada,
                Cod_Genero = objeto.Cod_Genero,
                Cod_Idioma = objeto.Cod_Idioma


            };
        }
        /**************************************************************************************************************/

        /********************************************************metodo para Editar********************************************************************/
        [HttpGet]
        public ActionResult EditarMusic(int Cod_Musica)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {

                try
                {
                    //validamos q nuestra codigo no sea nullo o mas bien dicho que exista 
                    //if (Cod_Pelicula==null)
                    //{
                    //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

                    //}

                    var objmusica = conexion.Musica.Find(Cod_Musica);

                    //validamos que lo q tiene mi variable objpelicula tiene algun valor 
                    //if (objpelicula==null)
                    //{
                    //    return HttpNotFound();
                    //}

                    return View(miotrometodoMusica(objmusica));

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                    return View();
                }
            }
        }

        private ClsPartialMusicas miotrometodoMusica(Musica objmusica)
        {
            return new ClsPartialMusicas
            {

                Cod_Musica = objmusica.Cod_Musica,
                Nombre = objmusica.Nombre,
                Artista = objmusica.Artista,
                Duracion = objmusica.Duracion,
                Fecha_Estreno = objmusica.Fecha_Estreno,
                Precio = objmusica.Precio,
                Portada = objmusica.Portada,
                Cod_Genero = objmusica.Cod_Genero,
                Cod_Idioma = objmusica.Cod_Idioma

            };

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditarMusic(ClsPartialMusicas objmusica)
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
                        var picture = objmusica.Portada;
                        var folder = "~/Content/images/Musica";

                        //aqui en el if validamos que el usuario no  cambio la foto pues siempre la tendra la q tenia anteriormente(el upload esta bacio)
                        if (objmusica.imagefile != null)
                        {
                            // pero si la cambio me subira la foto
                            picture = FileHelpers.UploadPhoto(objmusica.imagefile, folder);

                            //y aqui en este ultimo picture me debuelve el nombre de la imagen y con su extencion y ete nombre me lo concatena con 
                            //el nombre de la carpeta Content mas el nombre de la carpeta en donde estara la imagen subida
                            picture = string.Format("{0}/{1}", folder, picture);

                        }



                        var mivariable = MetodoMusica(objmusica);

                        //ya que todo estaben mi variable  le asigno lo que tiene el  MetodoPelicula 
                        mivariable.Portada = picture;

                        //pues aqui realisamos el cambio dela imagen biej ala imagen nueva  
                        conexion.Entry(mivariable).State = EntityState.Modified;
                        //aqui guardamos todo en la base de datos 
                        conexion.SaveChanges();
                        return RedirectToAction("IndexMusica");
                    }

                    return View(objmusica);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                return View();
            }

        }

        /****************************************************************************************************************************/

        /*********************************Metodo para Detalles ******************************************************/
       
        public ActionResult DellallesMusic(int Cod_Musica)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    var objmusica = conexion.Musica.Find(Cod_Musica);

                    if (objmusica == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View(objmusica);
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al solicitar detalles");
                return View();
            }

        }

        /****************************************************************************************************************************/



        /****************************************Metodo para eliminar Musica************************************************************************************/

        public ActionResult EliminarMusic(int Cod_Musica)
        {
            try
            {
                using (var objconexion = new Servicio_OnlineEntities())
                {
                    var obj = objconexion.Musica.Find(Cod_Musica);
                    objconexion.Musica.Remove(obj);
                    objconexion.SaveChanges();
                    return RedirectToAction("IndexMusica");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "No se realizo la eliminacion del archivo");
                return View();
            }
        }


        /****************************************************************************************************************************/


    }
}