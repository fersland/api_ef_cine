using csharp_apis_ef_cine.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_apis_ef_cine
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genero>().HasKey(g => g.Id);
            modelBuilder.Entity<Genero>().Property(g => g.Name).HasMaxLength(150);

            modelBuilder.Entity<Pelicula>().HasKey(p => p.Id);

            modelBuilder.Entity<Actor>().HasKey(a => a.Id);
            modelBuilder.Entity<Actor>().Property(a => a.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(a => a.Fortuna).HasPrecision(18, 2);
            modelBuilder.Entity<Actor>().Property(a => a.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Nominacion>().HasKey(n => n.Id);
            modelBuilder.Entity<Nominacion>().Property(n => n.Name).HasMaxLength(150);

            // LLAVE PRIMARIA COMPUESTA
            modelBuilder.Entity<PeliculaActor>().HasKey(pa => new { pa.ActorId, pa.PeliculaId });
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
        public DbSet<Genero> Generos => Set<Genero>();
        public DbSet<Actor> Actores => Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();
        public DbSet<Nominacion> Nominaciones => Set<Nominacion>();
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();
    }
}
