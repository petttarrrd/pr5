﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PR5_BaseEntities : DbContext
    {
        
        private static PR5_BaseEntities _context;
        public PR5_BaseEntities()
            : base("name=PR5_BaseEntities")
        {
        }
    public static PR5_BaseEntities Get_context()
        {
            if (_context == null) _context = new PR5_BaseEntities();

            return _context;
        } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<@class> @class { get; set; }
        public virtual DbSet<classroom> classroom { get; set; }
        public virtual DbSet<student> student { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
