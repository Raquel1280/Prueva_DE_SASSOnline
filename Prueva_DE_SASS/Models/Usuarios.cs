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
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Renta_Usuario_Musica = new HashSet<Renta_Usuario_Musica>();
            this.Renta_Usuario_Peliculas = new HashSet<Renta_Usuario_Peliculas>();
            this.Renta_Usuario_Videos = new HashSet<Renta_Usuario_Videos>();
        }
    
        public int Cod_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public int Cod_Pago { get; set; }
        public int Cod_Rol { get; set; }
    
        public virtual Forma_D_Pago Forma_D_Pago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Usuario_Musica> Renta_Usuario_Musica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Usuario_Peliculas> Renta_Usuario_Peliculas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Usuario_Videos> Renta_Usuario_Videos { get; set; }
        public virtual Rol Rol { get; set; }
    }
}