using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class MusicaController : Controller
    {
        // GET: Musica
        public ActionResult IndexPrincipal()
        {
            //try
            //{ 

            //    using (var conexion = new Servicio_OnlineEntities())
            //    {
            //        var sentencia = from M in conexion.Musica
            //                        join G in conexion.Genero_Vid_Music on M.Cod_Genero equals G.Cod_Genero
            //                        join I in conexion.Idioma on M.Cod_Idioma equals I.Cod_Idioma

            //                        orderby M.Cod_Genero descending

            //                        select new ClsPartialMusicas
            //                        {
            //                            Cod_Musica = M.Cod_Musica,
            //                            Nombre = M.Nombre,
            //                            Artista = M.Artista,
            //                            Duracion = M.Duracion,
            //                            Fecha_Estreno = M.Fecha_Estreno,
            //                            Precio = M.Precio,
            //                            Portada = M.Portada,
            //                            NombreGeneroMusica = G.Genero,
            //                            NombreIdiomaMusica = I.Idioma1

            //                        };

            //        return View(sentencia.ToList());
            //    }


            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            using (var conexion=new Servicio_OnlineEntities())
            {
                ViewBag.Message = "Encuentra tu musica ";
                List<Musica> litarmusica =conexion.Musica.Where(m =>m.Fecha_Estreno == "2019" && m.Fecha_Estreno == "2019").ToList();

                return View(litarmusica);
            }



               

        }

        public ActionResult Electronica()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    ViewBag.Message = "Encontraras los Exitos de la musica electronica";
                    //usamos operaciiones linquiu y landan
                    List<Musica> lista_G_Electronicas = conexion.Musica.Where(m => m.Cod_Genero == 1).ToList();
                    return View(lista_G_Electronicas);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
           
        }


        public ActionResult Urbana()
        {
            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica Urbana";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Musica> listar_G_urbanos = conexion.Musica.Where(a => a.Cod_Genero == 1002).ToList();
                    return View(listar_G_urbanos);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "" + ex);
                return View();
            }
           
        }

        public ActionResult Tecno()
        {
            try
            {
                using (var conexion=new Servicio_OnlineEntities())
                {
                    List<Musica> Listar_G_Tecno = conexion.Musica.Where(a => a.Cod_Genero == 2003).ToList();
                    return View(Listar_G_Tecno);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }
        public ActionResult Rap_Hip_Hop()
        {
            ViewBag.Message = "Encontraras los Exitos de la musica Rap y Hip-Hop";
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Musica> Listar_G_Rap = conexion.Musica.Where(a => a.Cod_Genero == 2).ToList();

                    return View(Listar_G_Rap);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }

        public ActionResult Romanticas()
        {
            try
            {
                ViewBag.Message = "Encontraras los mejores Exitos de la musica Romantica";
                using (var conexion=new Servicio_OnlineEntities())
                {
                    List<Musica> listar_G_Romantica = conexion.Musica.Where(a => a.Cod_Genero == 2002).ToList();
                    return View(listar_G_Romantica);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }


        public ActionResult Salsa()
        {
            try
            {
                ViewBag.Message = "Encontraras los Mejores Exitos dela Salsa";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Musica> listar_G_salsa = conexion.Musica.Where(a => a.Cod_Genero ==3003).ToList();
                    return View(listar_G_salsa);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }
        }



        public ActionResult Baladas()
        {
            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Musica> listar_G_Baladas = conexion.Musica.Where(a => a.Cod_Genero ==3004).ToList();
                    return View(listar_G_Baladas);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

        public ActionResult Ska()
        {

            try
            {
                ViewBag.Message = "Encontraras los Exitos de la musica";
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Musica> listar_G_Romantica = conexion.Musica.Where(a => a.Cod_Genero == 3002).ToList();
                    return View(listar_G_Romantica);

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

        public ActionResult MostrarDetallesMusica(int Cod_Musica)
        {

            try
            {
                using (var conexion=new Servicio_OnlineEntities())
                {
                    var objeto = conexion.Musica.Find(Cod_Musica);


                    if (objeto!=null)
                    {
                        return View(objeto);
                    }
                    else
                    {
                        return HttpNotFound();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }   
}