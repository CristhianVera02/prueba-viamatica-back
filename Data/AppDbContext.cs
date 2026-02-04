using Microsoft.EntityFrameworkCore;
using Prueba_viamatica.Models.DTOs.SalaCine;
using Prueba_viamatica.Models.Entities;

namespace Prueba_viamatica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<SalaCine> SalasCine { get; set; }
        public DbSet<PeliculaSalaCine> PeliculaSalaCine { get; set; }
        public DbSet<SalaDisponibilidadDto> SalaDisponibilidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);
                entity.ToTable("pelicula");
            });

            modelBuilder.Entity<SalaCine>(entity =>
            {
                entity.HasKey(e => e.IdSala);
                entity.ToTable("sala_cine");
            });

            modelBuilder.Entity<PeliculaSalaCine>(entity =>
            {
                entity.HasKey(e => e.IdPeliculaSala);
                entity.ToTable("pelicula_salacine");

                entity.HasOne(ps => ps.Pelicula)
                      .WithMany(p => p.PeliculasSalaCine)
                      .HasForeignKey(ps => ps.IdPelicula);

                entity.HasOne(ps => ps.SalaCine)
                      .WithMany(s => s.PeliculasSalaCine)
                      .HasForeignKey(ps => ps.IdSalaCine);
            });

            modelBuilder.Entity<SalaDisponibilidadDto>()
                .HasNoKey();

            modelBuilder.Entity<Pelicula>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<SalaCine>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<PeliculaSalaCine>().HasQueryFilter(ps => !ps.IsDeleted);
        }

    }
}
