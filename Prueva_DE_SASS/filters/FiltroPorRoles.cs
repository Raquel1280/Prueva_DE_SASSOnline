using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueva_DE_SASS.filters
{
    public class FiltroPorRoles: AuthorizeAttribute
    {

        private Usuarios NuestroUsuario;
        private Servicio_OnlineEntities conexion = new Servicio_OnlineEntities();
        private int Cod_Operaciones;


        public FiltroPorRoles(int Cod_Operaciones = 0)
        {
            this.Cod_Operaciones = Cod_Operaciones;
        }


        public override void OnAuthorization(AuthorizationContext filtercontext)
        {
            string nombreOperaciones = "";
            string nombreModulo = "";


            try
            {
                    NuestroUsuario = (Usuarios)HttpContext.Current.Session["User"];

                    var listaroperaciones = from objetoRoloperacion in conexion.Rol_Operaciones
                                            where objetoRoloperacion.Cod_Rol == NuestroUsuario.Cod_Rol &&
                                            objetoRoloperacion.Cod_Operaciones == Cod_Operaciones
                                            select objetoRoloperacion;


                    if (listaroperaciones.ToList().Count == 0)
                    {
                        var mioperacion = conexion.Operaciones.Find(Cod_Operaciones);
                        int? Cod_Modulo = mioperacion.Cod_Modulo;
                        nombreOperaciones = getNombreDeOperacion(Cod_Operaciones);
                        nombreModulo = obtenerNombredeModulos(Cod_Modulo);
                        nombreModulo = nombreModulo.Replace(' ', '+');
                        nombreOperaciones = nombreOperaciones.Replace(' ', '+');
                        //filtercontext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperaciones);
                        filtercontext.Result = new RedirectResult("~/Home/Index");
                    }

                

               

            }
            catch (Exception)
            {

                filtercontext.Result = new RedirectResult("~/Peliculas/IndexPrincipal");


            }




        }

        private string obtenerNombredeModulos(int? cod_Modulo)
        {

            var moduloparausuario = from Mymodulo in conexion.Modulo
                                    where Mymodulo.Cod_Modulo == cod_Modulo
                                    select Mymodulo.Nombre_Modulo;

            string nombredemimodulo;
            try
            {
                nombredemimodulo = moduloparausuario.First();
            }
            catch (Exception)
            {

                nombredemimodulo = "";
            }
            return nombredemimodulo;



        }



        private string getNombreDeOperacion(int cod_Operaciones)
        {
            var operacion = from obj2operacion in conexion.Operaciones
                            where obj2operacion.Cod_Operaciones == cod_Operaciones
                            select obj2operacion.Nombre_Operacion;
            string Minombreoperacion;
            try
            {
                Minombreoperacion = operacion.First();
            }
            catch (Exception)
            {

                Minombreoperacion = "";
            }

            return Minombreoperacion;

        }
    }
    }