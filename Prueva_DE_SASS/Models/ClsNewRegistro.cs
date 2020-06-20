using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prueva_DE_SASS.Models
{
    public class ClsNewRegistro
    {


        public int Cod_Usuario { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Required]
        [Display(Name = "Forma de Pago")]
        public int Cod_Pago { get; set; }


        public int Cod_Rol { get; set; }


    }


    [MetadataType(typeof(ClsNewRegistro))]
    public partial class Usuarios
    {


    }



}