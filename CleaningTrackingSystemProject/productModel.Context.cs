﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CleaningTrackingSystemProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cleaningDBEntities : DbContext
    {
        public cleaningDBEntities()
            : base("name=cleaningDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<basket> baskets { get; set; }
        public virtual DbSet<basketDetail> basketDetails { get; set; }
    }
}