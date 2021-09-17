using Microsoft.EntityFrameworkCore;
using MvcComercio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcComercio.Data
{
    public class MvcComercioContexto : DbContext 
    {
        public MvcComercioContexto(DbContextOptions<MvcComercioContexto> options) : base(options)
        {

        }

        public DbSet<Artista> Artistas
        {
            get; set;
        }
        public DbSet<Cancion> Canciones
        {
            get; set;
        }
        public DbSet<Cliente> Clientes
        {
            get; set;
        }
        public DbSet<DetalleFactura> DetalleFacturas
        {
            get; set;
        }
        public DbSet<Disco> Discos
        {
            get; set;
        }
        public DbSet<Factura> Facturas
        {
            get; set;
        }
        public DbSet<GeneroMusical> GeneroMusicales
        {
            get; set;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // He puesto el nombre de las tablas en singular
            modelBuilder.Entity<Artista>().ToTable("Artista");
            modelBuilder.Entity<Cancion>().ToTable("Cancion");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<DetalleFactura>().ToTable("DetalleFactura");
            modelBuilder.Entity<Disco>().ToTable("Disco");
            modelBuilder.Entity<Factura>().ToTable("Factura");
            modelBuilder.Entity<GeneroMusical>().ToTable("GeneroMusical");

            // Deshabilito la eliminación en cascada en todas las relaciones
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
