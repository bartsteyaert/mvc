﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Tuincentrum.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TuinCentrumEntities : DbContext
    {
        public TuinCentrumEntities()
            : base("name=TuinCentrumEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Leverancier> Leveranciers { get; set; }
        public virtual DbSet<Plant> Planten { get; set; }
        public virtual DbSet<Soort> Soorten { get; set; }
    }
}
