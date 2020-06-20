using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult IndexPrincipal()
        {

            //try
            //{

            //    using (var conexion = new Servicio_OnlineEntities())
            //    {
            //        var sentencia = from V in conexion.Videos
            //                        join G in conexion.Genero_Vid_Music on V
            //                        .Cod_Genero equals G.Cod_Genero
            //                        join I in conexion.Idioma on V.Cod_Idioma equals I.Cod_Idioma

            //                        orderby V.Cod_Video descending

            //                        select new ClsParcialVideo
            //                        {
            //                            Cod_Video = V.Cod_Video,
            //                            Nombre = V.Nombre,
            //                            Artista = V.Artista,
            //                            Duracion = V.Duracion,
            //                            Fecha_Estreno = V.Fecha_Estreno,
            //                            Precio = V.Precio,
            //                            Portada = V.Portada,
            //                            NombreGeneroVideo = G.Genero,
            //                            NombreIdiomaVideo = I.Idioma1

            //                        };

            //        return View(sentencia.ToList());
            //    }


            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            using (var conexio=new Servicio_OnlineEntities())
            {
                ViewBag.Message = "Encuentra tus Videos Favoritos solo em MAXPRIME";
                List<Videos> listarmivideos = conexio.Videos.Where(a=> a.Fecha_Estreno == "2019").ToList();

                return View(listarmivideos);
            }


               
        }


        public ActionResult Electronicas()
        {

            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Videos> listar_G_Electronicas = conexion.Videos.Where(a => a.Cod_Genero ==1).ToList();
                    return View(listar_G_Electronicas);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }

        public ActionResult Reggae()
        {

            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Videos> listar_G_Reggae = conexion.Videos.Where(a => a.Cod_Genero ==3005).ToList();
                    return View(listar_G_Reggae);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }

        public ActionResult House()
        {

            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Videos> listar_G_House = conexion.Videos.Where(a => a.Cod_Genero == 3007).ToList();
                    return View(listar_G_House);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }

        public ActionResult Rock()
        {
            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Videos> listar_G_Rock = conexion.Videos.Where(a => a.Cod_Genero == 3008).ToList();
                    return View(listar_G_Rock);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }

        public ActionResult Rap()
        {

            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Videos> listar_G_Rap = conexion.Videos.Where(a => a.Cod_Genero ==2).ToList();
                    return View(listar_G_Rap);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }


        public ActionResult DetallesVideos(int Cod_Video)
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

    }
}