namespace PruebaExamen.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<Posiciones> Posiciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipos>()
                .HasMany(e => e.Partidos)
                .WithRequired(e => e.Equipos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipos>()
                .HasMany(e => e.Posiciones)
                .WithRequired(e => e.Equipos)
                .WillCascadeOnDelete(false);
        }
    }
}
