using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueva_DE_SASS.Models
{
    //esta clase sirve para realisar validaciones en el lado del servidor 
    //Tambien creamos es ta clase ya que mostraremos datos de diferetes tablas  (usaremos realciones )
    public class ClsParcialPelicula
    {
        public int Cod_Pelicula { get; set; }

        [Display(Name = "Ingresar Nombre")]
      
        public string Nombre { get; set; }

       
        [Display(Name = "Actores")]
        [DataType(DataType.MultilineText)]
        [StringLength(900), Required]
        public string Actores { get; set; }

        [Display(Name = "Director")]
        [DataType(DataType.MultilineText)]
        [StringLength(1000), Required]
        public string Director { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1000), Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Duracion de la Pelicula")]
        public string Duracion { get; set; }

        [Required]
        [Display(Name = "Precio de Renta")]
        //[DisplayFormat(DataFormatString = "{0:$#,# }")]
        //[DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        //[Required]
        [Display(Name ="Fecha de estreno")]
        //[StringLength(4,ErrorMessage ="Ingrese 4 Digitos",MinimumLength =5)]
        [StringLength(4), Required]
        public string Fecha_Estreno { get; set; }

        //imagen se usara para guardar la ruta de la imagen
 
        [Display(Name = "Elegir imagen")]
       
        public string Portada { get; set; }

        [Required]
        [Display(Name ="Genero")]
        public int Cod_Genero { get; set; }
        [Required]
        [Display(Name ="Idioma")]
        public int Cod_Idioma { get; set; }

    
        //creamos esta variable para obtener la imagen 
        [Display(Name = "image")]
        public HttpPostedFileBase imagefile { get; set; }

        //creamos esta variable para obtener el nombre del genero de nuestra peliculas
        public string NombreGeneropelicula { get; set; }

        public string NombreIdiomapelicula { get; set; }




    }

    [MetadataType(typeof(ClsParcialPelicula))]
    public partial class Peliculas
    {

        [Display(Name = "Imagen")]
        public HttpPostedFileBase imagefile { get; set; }


        //creamos esta variable para obtener el nombre del genero de nuestra peliculas
        public string NombreGeneropelicula { get; set; }

        public string NombreIdiomapelicula { get; set; }




    }

}