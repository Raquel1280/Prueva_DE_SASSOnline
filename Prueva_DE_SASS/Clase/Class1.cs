using Prueva_DE_SASS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueva_DE_SASS.Clase
{
    public class Class1
    {
        public static string mostrargenero(int Cod_Genero)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {

                return conexion.GeneroPelicula.Find(Cod_Genero).Genero;

            }

        }
        public static string mostraridioma(int Cod_Idioma)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {

                return conexion.Idioma.Find(Cod_Idioma).Idioma1;

            }

        }



        public static string generoMusicVideo(int Cod_Genero)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {
                return conexion.Genero_Vid_Music.Find(Cod_Genero).Genero;

            }

        }

        public static string mostrarpagos(int Cod_Pago)
        {
            using (var conexion = new Servicio_OnlineEntities())
            {
                return conexion.Forma_D_Pago.Find(Cod_Pago).Pago;

            }
        }
    


    }
}