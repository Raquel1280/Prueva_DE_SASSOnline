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
    
    public partial class Renta_Usuario_Videos
    {
        public int Cod_Renta_Usuario_Videos { get; set; }
        public int Cod_Video { get; set; }
        public int Cod_Usuario { get; set; }
        public int Cod_Dias { get; set; }
    
        public virtual Dias_A_Rentar Dias_A_Rentar { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Videos Videos { get; set; }
    }
}