//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cafeteriaweb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class cafeterias
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ingresar descripcion")]
        [StringLength(100)]
        public string descripcion { get; set; }
        [Required]
        public int id_campus { get; set; }
        [Required(ErrorMessage= "Ingresar nombre de persona encargada")]
        public string encargado { get; set; }
        public bool estado { get; set; }
    
        public virtual campus campus { get; set; }
    }
}
