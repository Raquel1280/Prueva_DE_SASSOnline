//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueva_DE_SASS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Peliculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Peliculas()
        {
            this.Renta_Usuario_Peliculas = new HashSet<Renta_Usuario_Peliculas>();
        }
    
        public int Cod_Pelicula { get; set; }
        public string Nombre { get; set; }
        public string Actores { get; set; }
        public string Director { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public decimal Precio { get; set; }
        public string Fecha_Estreno { get; set; }
        public string Portada { get; set; }
        public int Cod_Genero { get; set; }
        public int Cod_Idioma { get; set; }
    
        public virtual GeneroPelicula GeneroPelicula { get; set; }
        public virtual Idioma Idioma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Usuario_Peliculas> Renta_Usuario_Peliculas { get; set; }
    }
}
