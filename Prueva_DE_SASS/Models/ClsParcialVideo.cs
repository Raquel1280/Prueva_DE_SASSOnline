using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueva_DE_SASS.Models
{
    public class ClsParcialVideo
    {


        [Display(Name = "Codigo")]
       
        public int Cod_Video { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Nombre del Video")]
        public string Nombre { get; set; }


        [Display(Name = "Artista/as")]
        [DataType(DataType.MultilineText)]
        [StringLength(100), Required]
        public string Artista { get; set; }

        [Required]
        [Display(Name = "Tiempo de Duracion")]
        public string Duracion { get; set; }

        [Required]
        [Display(Name = "Fecha de estreno")]
        [StringLength(4, ErrorMessage = "Ingrese 4 Digitos", MinimumLength = 4)]
        public string Fecha_Estreno { get; set; }

        [Required]
        [Display(Name = "Precio de Renta")]
        //[DisplayFormat(DataFormatString = "{0:$#,# }")]
       
        //[DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public string Portada { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int Cod_Genero { get; set; }

        [Required]
        [Display(Name = "Idioma")]
        public int Cod_Idioma { get; set; }



        //creamos esta variable para obtener la imagen de lamusica
        [Display(Name = "image")]
        public HttpPostedFileBase imagefile { get; set; }

        //creamos esta variable para obtener el nombre del genero de nuestra peliculas
        public string NombreGeneroVideo { get; set; }

        public string NombreIdiomaVideo { get; set; }


    }


    [MetadataType(typeof(ClsParcialVideo))]
    public partial class Videos{

        //creamos esta variable para obtener la imagen de lamusica
        [Display(Name = "image")]
        public HttpPostedFileBase imagefile { get; set; }


        //creamos esta variable para obtener el nombre del genero de nuestra peliculas
        public string NombreGeneroVideo { get; set; }

        public string NombreIdiomaVideo { get; set; }

    }


}