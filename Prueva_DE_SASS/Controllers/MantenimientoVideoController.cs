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
    public class MantenimientoVideoController : Controller
    {
        // GET: MantenimientoVideo
        public ActionResult IndexVideo(string searching)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {
                return View(conexion.Videos.Where(a => a.Nombre.Contains(searching) || searching == null).ToList());


                //en este con starswidhtle indicamos q nos muestre por el primer letra q
                //    ingresamos si ingresamos batman me mostrara solo os q empiesen  con b en cambio
                //con el .Contains nos mostraria todos los que poseen b
                //return View(conexion.Peliculas.Where(a => a.Nombre.StartsWith(searching) || searching == null).ToList());

            }



    }


        /***********************************Este metodo es para Agregar ala base de datos********************/
        [HttpGet]
        public ActionResult AgregarVideo()
        {
            return View();
        }


        [ValidateAntiForgeryToken]//este codigo se encarga que la informcion llegue al formulario correcto
        [HttpPost]
        public ActionResult AgregarVideo(ClsParcialVideo objeto )
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    if (!ModelState.IsValid)
                    {
                        //inicialisamos una variable picture para q este vacia
                        var picture = string.Empty;
                        var folder = "~/Content/images/Video";

                        //aqui en el if validamos que el usuario si selecciono una foto en el upload(si hay foto)
                        if (objeto.imagefile != null)
                        {
                            //aqui le desimos ala primera picture que me suba la foto que esta en mi imagefile
                            picture = FileHelpers.UploadPhoto(objeto.imagefile, folder);

                            //y aqui en este ultimo picture me debuelve el nombre de la imagen y con su extencion y ete nombre me lo concatena con 
                            //el nombre de la carpeta Content mas el nombre de la carpeta en donde estara la imagen subida
                            picture = string.Format("{0}/{1}", folder, picture);

                        }

                        var variable = MetodoVideo(objeto);

                        //ya que todo estaben mi variable  le asigno lo que tiene el  MetodoPelicula 
                        variable.Portada = picture;

                        conexion.Videos.Add(variable);
                        //aqui guardamos todo en la base de datos 
                        conexion.SaveChanges();
                        return RedirectToAction("IndexVideo");

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
        private Videos MetodoVideo(ClsParcialVideo objeto1)
        {
            return new Videos
            {
                Cod_Video = objeto1.Cod_Video,
                Nombre = objeto1.Nombre,
                Artista = objeto1.Artista,
                Duracion = objeto1.Duracion,
                Fecha_Estreno = objeto1.Fecha_Estreno,
                Precio =Convert.ToDecimal(objeto1.Precio),
                Portada = objeto1.Portada,
                Cod_Genero=objeto1.Cod_Genero,
                Cod_Idioma = objeto1.Cod_Idioma


            };
        }



        /**************************************************************************************************/


        /********************************************************metodo para Editar********************************************************************/
        public ActionResult EditarVideo(int Cod_Video)
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

                    var objvideo2 = conexion.Videos.Find(Cod_Video);

                    //validamos que lo q tiene mi variable objpelicula tiene algun valor 
                    //if (objpelicula==null)
                    //{
                    //    return HttpNotFound();
                    //}

                    return View(miotrometodoVideo(objvideo2));

                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                    return View();
                }
            }
        }

        private ClsParcialVideo miotrometodoVideo(Videos objvideo2)
        {
            return new ClsParcialVideo
            {

                Cod_Video = objvideo2.Cod_Video,
                Nombre = objvideo2.Nombre,
                Artista = objvideo2.Artista,
                Duracion = objvideo2.Duracion,
                Fecha_Estreno = objvideo2.Fecha_Estreno,
                Precio = objvideo2.Precio,
                Portada = objvideo2.Portada,
                Cod_Genero = objvideo2.Cod_Genero,
                Cod_Idioma = objvideo2.Cod_Idioma

            };
        }
        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarVideo(ClsParcialVideo objetovideo)
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
                        var picture = objetovideo.Portada;
                        var folder = "~/Content/images/Video";

                        //aqui en el if validamos que el usuario no  cambio la foto pues siempre la tendra la q tenia anteriormente(el upload esta bacio)
                        if (objetovideo.imagefile != null)
                        {
                            // pero si la cambio me subira la foto
                            picture = FileHelpers.UploadPhoto(objetovideo.imagefile, folder);

                            //y aqui en este ultimo picture me debuelve el nombre de la imagen y con su extencion y ete nombre me lo concatena con 
                            //el nombre de la carpeta Content mas el nombre de la carpeta en donde estara la imagen subida
                            picture = string.Format("{0}/{1}", folder, picture);

                        }



                        var mivariable = MetodoVideo(objetovideo);

                        //ya que todo estaben mi variable  le asigno lo que tiene el  MetodoPelicula 
                        mivariable.Portada = picture;

                        //pues aqui realisamos el cambio dela imagen biej ala imagen nueva  
                        conexion.Entry(mivariable).State = EntityState.Modified;
                        //aqui guardamos todo en la base de datos 
                        conexion.SaveChanges();
                        return RedirectToAction("IndexVideo");
                    }

                    return View(objetovideo);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Lo sentimos no se realizo la modificacion que esperaba");
                return View();
            }
        }

        /**************************************************************************************************************************/





        /******************************************Metodo para Detalles **********************************************************************/

        public ActionResult DetallesVideo(int Cod_Video)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    var objvideo3 = conexion.Videos.Find(Cod_Video);

                    if (objvideo3 == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return View(objvideo3);
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al solicitar detalles");
                return View();
            }


        }


        /**************************************************************************************************************************/


        /******************************************Metodo para Eliminar **********************************************************************/
         public ActionResult EliminarVideo(int Cod_Video)
        {
            try
            {
                using (var objconexion = new Servicio_OnlineEntities())
                {
                    var obj = objconexion.Videos.Find(Cod_Video);
                    objconexion.Videos.Remove(obj);
                    objconexion.SaveChanges();
                    return RedirectToAction("IndexVideo");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "No se realizo la eliminacion del archivo");
                return View();
            }
        }


        /**************************************************************************************************************************/








       







    }
}