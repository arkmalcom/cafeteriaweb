﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cafeteriaEntities : DbContext
    {
        public cafeteriaEntities()
            : base("name=cafeteriaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<articulos> articulos { get; set; }
        public virtual DbSet<cafeterias> cafeterias { get; set; }
        public virtual DbSet<campus> campus { get; set; }
        public virtual DbSet<empleados> empleados { get; set; }
        public virtual DbSet<facturas> facturas { get; set; }
        public virtual DbSet<marcas> marcas { get; set; }
        public virtual DbSet<proveedores> proveedores { get; set; }
        public virtual DbSet<tipos_usuario> tipos_usuario { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
