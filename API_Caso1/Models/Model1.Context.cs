//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Caso1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBCaso1Entities : DbContext
    {
        public DBCaso1Entities()
            : base("name=DBCaso1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t001_usuarios> t001_usuarios { get; set; }
        public virtual DbSet<t002_colonias> t002_colonias { get; set; }
        public virtual DbSet<t003_depositos> t003_depositos { get; set; }
        public virtual DbSet<t004_presas> t004_presas { get; set; }
        public virtual DbSet<t005_tanques> t005_tanques { get; set; }
    }
}
