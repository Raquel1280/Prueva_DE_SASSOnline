using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Prueva_DE_SASS.Models
{
    public class ClsPartialMusicas
    {

       [Display(Name ="Codigo")]
        public int Cod_Musica { get; set; }


        [Required]
        [Display(Name ="Nombre de la musica")]
        [DataType(DataType.MultilineText)]
        public string Nombre { get; set; }


        [Display(Name ="Artista/as")]
        [DataType(DataType.MultilineText)]
        [StringLength(600), Required]
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
        public string NombreGeneroMusica { get; set; }

        public string NombreIdiomaMusica{ get; set; }

    }



    [MetadataType(typeof(ClsPartialMusicas))]
    public partial class Musica
    {


        //creamos esta variable para obtener la imagen de lamusica
        [Display(Name = "image")]
        public HttpPostedFileBase imagefile { get; set; }

        //creamos esta variable para obtener el nombre del genero de nuestra peliculas
        public string NombreGeneroMusica { get; set; }

        public string NombreIdiomaMusica { get; set; }


    }



}