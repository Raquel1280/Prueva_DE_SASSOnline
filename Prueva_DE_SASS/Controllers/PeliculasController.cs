using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.Controllers
{
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult IndexPrincipal()
        {
            //    try
            //    {

            //        using (var conexion = new Servicio_OnlineEntities())
            //        {
            //            var sentencia = from P in conexion.Peliculas
            //                            join G in conexion.GeneroPelicula on P.Cod_Genero equals G.Cod_Genero
            //                            join I in conexion.Idioma on P.Cod_Idioma equals I.Cod_Idioma
            //                            where (P.Cod_Genero ==2)
            //                            orderby P.Cod_Pelicula descending

            //                            select new ClsParcialPelicula
            //                            {
            //                                Cod_Pelicula = P.Cod_Pelicula,
            //                                Nombre = P.Nombre,
            //                                Actores = P.Actores,
            //                                Director = P.Director,
            //                                Descripcion = P.Descripcion,
            //                                Duracion = P.Duracion,
            //                                Precio = P.Precio,
            //                                Fecha_Estreno = P.Fecha_Estreno,
            //                                Portada = P.Portada,
            //                                NombreGeneropelicula = G.Genero,
            //                                NombreIdiomapelicula = I.Idioma1

            //                            };

            //            return View(sentencia.ToList());
            //        }


            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            using (var conexion=new Servicio_OnlineEntities())
            {
                ViewBag.Message = "Peliculas mas Solicitadas";
                List<Peliculas> mispeliculas = conexion.Peliculas.Where(a=>a.Fecha_Estreno == "2019").ToList();
                return View(mispeliculas);
            }

        }

        public ActionResult Accion()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_accion = conexion.Peliculas.Where(p => p.Cod_Genero == 2).ToList();

                    return View(Listar_G_accion);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }



        public ActionResult Ciencia_Ficcion()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Ficcion = conexion.Peliculas.Where(p => p.Cod_Genero == 5).ToList();

                    return View(Listar_G_Ficcion);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

       

        public ActionResult Drama()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Drama = conexion.Peliculas.Where(p => p.Cod_Genero ==3).ToList();

                    return View(Listar_G_Drama);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }
      
        public ActionResult Aventura()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Aventura = conexion.Peliculas.Where(p => p.Cod_Genero == 4).ToList();

                    return View(Listar_G_Aventura);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

   

        public ActionResult Fantasia()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Fantasia = conexion.Peliculas.Where(p => p.Cod_Genero == 11).ToList();

                    return View(Listar_G_Fantasia);
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
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Romanticas = conexion.Peliculas.Where(p => p.Cod_Genero == 10).ToList();

                    return View(Listar_G_Romanticas);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

        public ActionResult Familiar()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Familiar = conexion.Peliculas.Where(p => p.Cod_Genero == 9).ToList();

                    return View(Listar_G_Familiar);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }

        public ActionResult Guerras()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Guerras = conexion.Peliculas.Where(p => p.Cod_Genero == 7).ToList();

                    return View(Listar_G_Guerras);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }


        public ActionResult Comedia()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Comedia = conexion.Peliculas.Where(p => p.Cod_Genero == 6).ToList();

                    return View(Listar_G_Comedia);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }



        public ActionResult Terror()
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {
                    List<Peliculas> Listar_G_Terror = conexion.Peliculas.Where(p => p.Cod_Genero == 1).ToList();

                    return View(Listar_G_Terror);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "" + ex);
                return View();
            }

        }





        public ActionResult DetallePeliculas(int Cod_Pelicula)
        {
            try
            {
                using (var conexion = new Servicio_OnlineEntities())
                {

                    var objvideo3 = conexion.Peliculas.Find(Cod_Pelicula);

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